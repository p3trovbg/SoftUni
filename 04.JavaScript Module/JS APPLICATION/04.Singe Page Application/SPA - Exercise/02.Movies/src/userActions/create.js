import { loadHomeView } from "../controller.js";

export async function create(form) {
    form.addEventListener('submit', async(e) => {
    e.preventDefault();
    let formData = new FormData(form);

    let title = formData.get('title').trim();
    let description = formData.get('description').trim();
    let img = formData.get('imageUrl').trim();

    if(!title || !description || !img) {
        alert('You should fill all fields!');
        return;
    }
    
    e.target.reset();
    await createRequest({title, description, img});
    })
}

async function createRequest(film) {
    try{
        let url = `http://localhost:3030/data/movies`;
        let token = sessionStorage.getItem('authToken');
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'content-type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify(film)
        })
        
        if(!response.ok) {
            throw new Error(await response.json().message);
        }
        window.location = '/index.html';
    }
    catch(error) {
        alert(error.message);
    }
}