import { html, render } from '../lit-html/lit-html.js';
import { bookViewTemplate } from './viewTamplate.js';
import { bookTamplate } from './bookTemplate.js';
export { html, del, addBook, loadBooks, editBook, editRequest }
const bookUrl = `http://localhost:3030/jsonstore/collections/books/`;

start();

async function start() {
    let body = document.querySelector('body');
    onRender(bookViewTemplate(), body);
}

function onRender(tamplate, section) {
    render(tamplate, section);
}

let editRequest;
function editBook(book, id) {
    let editForm = document.querySelector('#edit-form');
    let addForm = document.querySelector('#add-form');
    editForm.className = id;
    editForm.style.display = 'block';
    addForm.style.display = 'none';

    editForm.querySelector('[name="title"]').value = book.title;
    editForm.querySelector('[name="author"]').value = book.author;

    editRequest = async (e) => {
        e.preventDefault();
        let formData = new FormData(e.target);
        let title = formData.get('title').trim();
        let author = formData.get('author').trim();

        try {
            let response = await fetch(bookUrl + id, {
                method: 'put',
                headers: {
                    'content-type': 'application/json'
                },
                body: JSON.stringify({ title, author })
            })
            if (!response.ok) {
                throw new Error(await response.json().message)
            }
            await response.json();
        }
        catch (error) {
            alert(error.message);
        }

        e.target.style.display = 'none';
        addForm.style.display = 'block';
        await loadBooks();
    }
}



async function addBook(e) {
    e.preventDefault();
    let form = new FormData(e.target);
    let title = form.get('title').trim();
    let author = form.get('author').trim();

    if (!title || !author) {
        alert('You should fill all fields!');
        return;
    }

    e.target.reset();

    await fetch(bookUrl, {
        method: 'post',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({ title, author })
    })
    loadBooks();
}


async function loadBooks() {
    let books = await getBooks();
    let keys = Object.keys(books);
    let tBody = document.querySelector('tbody');

    onRender(keys.map(k => bookTamplate(books[k], k)), tBody);
}



async function del(id) {
    await fetch(bookUrl + id, {
        method: 'delete'
    })
    loadBooks();
}


async function getBooks() {
    const response = await fetch(bookUrl);
    const data = await response.json();

    return data;
}

async function getBook(id) {
    const response = await fetch(bookUrl + id);
    const data = await response.json();

    return data;
}