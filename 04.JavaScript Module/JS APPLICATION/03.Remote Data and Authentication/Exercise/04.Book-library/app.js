let tBody = document.querySelector('tbody');
let loadButton = document.querySelector('#loadBooks').addEventListener('click', getAllBooks);
let createForm = document.querySelector('#createForm');
createForm.addEventListener('submit', postBook);
tBody.addEventListener('click', manipulations);
getAllBooks();
//Get all books
async function getAllBooks() {
    let data = await request('http://localhost:3030/jsonstore/collections/books');
    tBody.replaceChildren();
    Object.keys(data).forEach(key => {
        createBook(key, data[key])
      });
}


//Post book in the server
async function postBook(e) {
    e.preventDefault();
    let dataForm = new FormData(e.target);
    let title = dataForm.get('title').trim();
    let author = dataForm.get('author').trim();
    if(!title && !author) {
        alert('You must fill all fields!')
        return;
    }

    let book = {title, author};
    createForm.children[2].value = '';
    createForm.children[4].value = '';
    let data = await request('http://localhost:3030/jsonstore/collections/books', {
        method: 'post',
        body: JSON.stringify(book)
    })

    await createBook(data._id, data);
}

//Update info in the book.
async function updateBook(parent, book) {
    await request('http://localhost:3030/jsonstore/collections/books/' + parent.id, {
        method: 'put',
        body: JSON.stringify(book)
    })   
    
    
}

//Delete the book.
async function deleteBook(id) {
    await request('http://localhost:3030/jsonstore/collections/books/' + id, {
        method: 'delete',
    })
}

//Request 
async function request(url, options) {
    if (options && options.body) {
        Object.assign(options, {
            headers: {
                'Content-Type': 'application/json'
            }
        })
    }

    try{
        const response = await fetch(url, options);
        if (!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }
        return await response.json();

    } catch(error) {
        alert(error.message);
    }
    
}

// --- Delete/Edit
async function manipulations(e){
    e.preventDefault();
    const parent = e.target.parentElement.parentElement;
    if(e.target.textContent == 'Edit') {
        editBookElement(parent);
    } else if (e.target.textContent == 'Delete') {
        deleteBook(parent.id);
        parent.remove();
    }
}

//Create book
async function createBook(key, book) {
    let trElement = document.createElement('tr');
    trElement.id = key;
    let title = document.createElement('td');
    title.textContent = book.title;
    let author = document.createElement('td');
    author.textContent = book.author;
    let buttons = document.createElement('td');
    let editButton = document.createElement('button');
    editButton.textContent = 'Edit';
    let deleteButton = document.createElement('button');
    deleteButton.textContent = 'Delete';

    buttons.appendChild(editButton);
    buttons.appendChild(deleteButton);

    trElement.appendChild(title);
    trElement.appendChild(author);
    trElement.appendChild(buttons);
    
    tBody.appendChild(trElement);
}

//Edit book
async function editBookElement(parent) {
    let editForm = document.querySelector('#editForm');
    let book = await request('http://localhost:3030/jsonstore/collections/books/' + parent.id);
        createForm.style.display = 'none';
        editForm.style.display = 'block';

        editForm.children[2].value = book.title;
        editForm.children[4].value = book.author;

        //Submit button on edit form.
        editForm.addEventListener('submit', async(e) => {
            e.defaultPrevented();
            let form = new FormData(e.target);
            let title = form.get('title').trim();
            let author = form.get('author').trim();
            if(!title || !author) {
                alert('You must fill all fields!');
            }
            parent.children[0].textContent = title;
            parent.children[1].textContent = author;

            let book = {title, author};
            
            createForm.style.display = 'block';
            editForm.style.display = 'none';

            await updateBook(parent, book)
        })
}