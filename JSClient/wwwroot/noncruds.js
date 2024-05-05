let youngestauthor = {} ;
let oldestauthorcoll = {};
let bestratedbook = {};
let bookwlt = {};
let mostexpbook = {};
let booksingenre = [];
let booksbyauthor = [];
let bookswithauthors = [];


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
    connection.on("OldestAuthor", (user, message) => {
        console.log(user);
        console.log(message);
    });
    connection.on("BestRatedBook", (user, message) => {
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
        "<thead><tr><th>Youngest Author's Name</th><th>Age</th></tr></thead > ";

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
        "<thead><tr><th>Oldest Author's Name</th><th>Age</th></tr></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + oldestauthor.authorName + "</td><td>" + oldestauthor.age + "</td></tr>";

}

async function func_bestratedbook() {
    await fetch('http://localhost:20300/stat/bestRatedBookInfo/')
        .then(x => x.json())
        .then(y => {
            bestratedbook = y;
            console.log(bestratedbook);
            disp_bestratedbook();
        });
}

function disp_bestratedbook() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><th>Best Rated Book</th></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>Title</td><td>Rating</td></tr>";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + bestratedbook.title + "</td><td>" + bestratedbook.rating + "</td></tr>";
}

async function func_bookwlt() {
    await fetch('http://localhost:20300/stat/longestTitleBookInfo/')
        .then(x => x.json())
        .then(y => {
            bookwlt = y;
            console.log(bookwlt);
            disp_bookwlt();
        });
}

function disp_bookwlt() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><th>Longest Title Book</th></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>Title</td><td>Title length</td></tr>";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + bookwlt.title + "</td><td>" + bookwlt.title.toString().length + "</td></tr>";
}
async function func_mostexpbook() {
    await fetch('http://localhost:20300/stat/mostExpensiveBookInfo/')
        .then(x => x.json())
        .then(y => {
            mostexpbook = y;
            console.log(mostexpbook);
            disp_mostexpbook();
        });
}

function disp_mostexpbook() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><th>Most Expensive Book</th></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>Title</td><td>Price</td></tr>";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>" + mostexpbook.title + "</td><td>" + mostexpbook.price + "</td></tr>";
}

async function func_booksingenre() {
    let id = document.getElementById('input_booksingenre').value;
    await fetch('http://localhost:20300/stat/booksInGenre/' + id)
        .then(x => x.json())
        .then(y => {
            booksingenre = y;
            console.log(booksingenre);
            disp_booksingenre();
        });
}

function disp_booksingenre() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><th>Books in the genre</th></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>Title</td><td>Genre</td></tr>";

    booksingenre.forEach(t => {
        document.getElementById('resultarea').innerHTML += 
            "<tr><td>" + t.title + "</td><td>" + t.genre.genreName + "</td></tr>";
    })
    
}

async function func_booksbyauthor() {
    let id = document.getElementById('input_booksbyauthor').value;
    await fetch('http://localhost:20300/stat/booksByAuthor/' + id)
        .then(x => x.json())
        .then(y => {
            booksbyauthor = y;
            console.log(booksbyauthor);
            disp_booksbyauthor();
        });
}

function disp_booksbyauthor() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><th>Books by this author</th></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>Title</td><td>Author</td></tr>";

    booksbyauthor.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.title + "</td><td>" + t.author.authorName + "</td></tr>";
    })

}

async function func_bookswithauthors() {
    await fetch('http://localhost:20300/stat/booksWithAuthor/')
        .then(x => x.json())
        .then(y => {
            bookswithauthors = y;
            console.log(bookswithauthors);
            disp_bookswithauthors();
        });
}

function disp_bookswithauthors() {
    document.getElementById('resultarea').innerHTML = "";

    document.getElementById('resultarea').innerHTML +=
        "<thead><th>Books and the Author</th></thead > ";

    document.getElementById('resultarea').innerHTML +=
        "<tr><td>Title</td><td>Author</td></tr>";

    bookswithauthors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.title + "</td><td>" + t.author.authorName + "</td></tr>";
    })

}