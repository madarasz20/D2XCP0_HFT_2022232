let authors = [];
let connection = null;

let authorIDtoUpdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:20300/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("AuthorCreated", (user, message) => {
        getdata();
    });
    connection.on("AuthorDeleted", (user, message) => {
        getdata();
    });
    connection.on("AuthorUpdated", (user, message) => {
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
    await fetch('http://localhost:20300/author')
        .then(x => x.json())
        .then(y => {
            authors = y;
            //console.log(authors);
            display();
        });

}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.authorID + "</td><td>" + t.authorName + 
        "</td><td>" +
        `<button type = "button" onclick = "remove(${t.authorID})">Delete</button>` + 
        `<button type = "button" onclick = "showupdate(${t.authorID})">Update</button>`
            + "</td></tr> ";
        console.log(t.authorName);
    });
}


function remove(id) {
    fetch('http://localhost:20300/author/' + id, {
        method: 'DELETE',
        headers: {'Content-Type': 'application/json',},
        body :null})
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
    document.getElementById('authornametoupdate').value = authors.find(t => t['authorID'] == id)['authorName'];
    document.getElementById('updateformdiv').style.display = 'flex';
    authorIDtoUpdate = id;
}

function create() {
    let name = document.getElementById('authorname').value;
    fetch('http://localhost:20300/author', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                authorName: name
            }),
        })
        .then(response => response)
        .then(data =>
        {
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
    let name = document.getElementById('authornametoupdate').value;
    fetch('http://localhost:20300/author', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                authorName: name,
                authorID: authorIDtoUpdate
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