﻿let youngestauthorcoll = {} ;
let connection = null;
setupSignalR();


//func_youngestauthor();




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
            //+=
            youngestauthorcoll = y;
            console.log(youngestauthorcoll);
            disp_youngestAuthor();
        });
}

function disp_youngestAuthor() {

    document.getElementById('resultarea').innerHTML +=
        "<thead><tr><th>Author Name</th><th>Age</th></tr></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + youngestauthorcoll.authorName + "</td><td>" + youngestauthorcoll.age + "</td></tr>";


    
}