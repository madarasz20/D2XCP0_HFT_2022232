let youngestauthor = {} ;
let oldestauthorcoll = {} ;
let connection = null;
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:20300/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("YoungestAuthor", (user, message) => {
        //getdata();
        console.log(user);
        console.log(message);
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

async function func_youngestauthor() {
     await fetch('http://localhost:20300/stat/youngestAuthor/')
        .then(x => x.json())
         .then(y => {
            youngestauthor = y;
            console.log(youngestauthor);
            disp_youngestAuthor();
        });
}

function disp_youngestAuthor() {
    document.getElementById('resultarea').innerHTML = "";
    document.getElementById('resultarea').innerHTML +=
        "<thead><tr><th>Author Name</th><th>Age</th></tr></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + youngestauthor.authorName + "</td><td>" + youngestauthor.age + "</td></tr>";

}


async function func_oldestauthor() {
    await fetch('http://localhost:20300/stat/oldestAuthor/')
        .then(x => x.json())
        .then(y => {
            oldestauthor = y;
            console.log(oldestauthor);
            disp_oldestAuthor();
        });
}

function disp_oldestAuthor() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><tr><th>Author Name</th><th>Age</th></tr></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + oldestauthor.authorName + "</td><td>" + oldestauthor.age + "</td></tr>";

}
