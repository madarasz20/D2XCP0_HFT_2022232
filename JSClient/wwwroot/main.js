const menu = document.getElementById('menu');

function linker(id) {
    switch (true) {
        case id == 'authors':
            window.location.href = "./index.html";
            break;
        case id == 'books':
            window.location.href = "./book.html";
            break;
        default:
    }
}