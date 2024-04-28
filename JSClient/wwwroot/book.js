let books = [];
let connection = null;

let bookIDtoUpdate = -1;

getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:20300/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("BookCreated", (user, message) => {
        getdata();
    });
    connection.on("BookDeleted", (user, message) => {
        getdata();
    });
    connection.on("BookUpdated", (user, message) => {
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
    await fetch('http://localhost:20300/book')
        .then(x => x.json())
        .then(y => {
            books = y;
            //console.log(authors);
            display();
        });

}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    books.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.bookID + "</td><td>" + t.title +
            "</td><td>" +
            `<button type = "button" onclick = "remove(${t.bookID})">Delete</button>` +
            `<button type = "button" onclick = "showupdate(${t.bookID})">Update</button>`
            + "</td></tr> ";
        console.log(t.title);
    });
}


function remove(id) {
    fetch('http://localhost:20300/book/' + id, {
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
    document.getElementById('booknametoupdate').value = books.find(t => t['bookID'] == id)['title'];
    document.getElementById('updateformdiv').style.display = 'flex';
    bookIDtoUpdate = id;
}

function create() {
    let name = document.getElementById('title').value;
    fetch('http://localhost:20300/book', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                title: name
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
    let name = document.getElementById('booknametoupdate').value;
    fetch('http://localhost:20300/book', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(
            {
                title: name,
                bookID: bookIDtoUpdate
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