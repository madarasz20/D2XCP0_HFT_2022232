let authors = [];

getdata();

async function getdata() {
    await fetch('http://localhost:20300/author')
        .then(x => x.json())
        .then(y => {
            authors = y;
            console.log(authors);
            display();
        });

}





function display() {
    document.getElementById('resultarea').innerHTML = "";
    authors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.authorID + "</td><td>" + t.authorName + 
        "</td><td>" +
        `<button type = "button" onclick = "remove(${t.authorID})">Delete</button>`
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