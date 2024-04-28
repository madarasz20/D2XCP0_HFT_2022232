let genres = [];
let connection = null;

let genreIDtoUpdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:20300/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("GenreCreated", (user, message) => {
        getdata();
    });
    connection.on("GenreDeleted", (user, message) => {
        getdata();
    });
    connection.on("GenreUpdated", (user, message) => {
        getdata();
    });
    connection.onclose(async () => {
        await start();
    });
    start();

}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
}

async function getdata() {
    await fetch('http://localhost:20300/genre')
        .then(x => x.json())
        .then(y => {
            genres = y;
            //console.log(authors);
            display();
        });

}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    genres.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.genreID + "</td><td>" + t.genreName +
            "</td><td>" +
            `<button type = "button" onclick = "remove(${t.genreID})">Delete</button>` +
            `<button type = "button" onclick = "showupdate(${t.genreID})">Update</button>`
            + "</td></tr> ";
        console.log(t.genreName);
    });
}


function remove(id) {
    fetch('http://localhost:20300/genre/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => {
            console.error('Error:', error);
        })
}
function showupdate(id) {
    document.getElementById('genrenametoupdate').value = genres.find(t => t['genreID'] == id)['genreName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    genreIDtoUpdate = id;
}

function create() {
    let name = document.getElementById('genreName').value;
    fetch('http://localhost:20300/genre', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                genreName: name
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
            /*            display();*/
        })
        .catch((error) => {
            console.error('Error:', error);
        })


}

function update() {
    document.getElementById('updateformdiv').style.dislay = 'none';
    let name = document.getElementById('genrenametoupdate').value;
    fetch('http://localhost:20300/genre', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                genreName: name,
                genreID: genreIDtoUpdate
            }),
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();

        })
        .catch((error) => {
            console.error('Error:', error);
        })


}