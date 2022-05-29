import { loadHomeView } from '../controller.js';
import { movies } from '../app.js';
import { buttonId } from '../app.js';
import { description, title, imgSrc } from './loadFilms.js';

export async function likeFunc(e) {
    let id = e.target.id;
    let likeId = await isLike(id, sessionStorage.getItem('ownerId'), e.target);
    if(e.target.textContent == 'Like') {
        e.target.textContent ='Unlike'
        likePostRequest(id);
    } else {
        e.target.textContent ='Like'
        unlikeRequest(likeId, id);
    }
}   

export async function editFunc(form) {
    form.querySelector('#title').value = title;
    form.querySelector('#desc').value = description;
    form.querySelector('#imageUrl').value = imgSrc;

    form.addEventListener('submit', async(e) => {
        e.preventDefault();
        let formData = new FormData(e.target);
        let title = formData.get('title');
        let description = formData.get('description');
        let img = formData.get('imageUrl');
        if(!title || !description || !img) {
            alert('You should fill all fields!')
            return;
        }

        const url = 'http://localhost:3030/data/movies/' + buttonId;
        let token = sessionStorage.getItem('authToken');
        try{
            const response = await fetch(url, {
                method: 'put',
                headers: {
                    'content-type': 'application/json',
                    'X-Authorization': token
                }, 
                body: JSON.stringify({title, description, img})
            })
    
            if(!response.ok) {
                throw new Error(await response.json().message);
            }
    
            window.location = '/index.html';
        }
        catch(error){
            alert(error.message);
        }
    })
}

export async function deleteFunc(e) {
    e.preventDefault();
    let id = e.target.id;
    let url = `http://localhost:3030/data/movies/` + id;
    let token = sessionStorage.getItem('authToken');
    try{
        let response = await fetch(url, {
            method: 'DELETE',
            headers: {
                'X-Authorization': token
            }
        })

        if(!response.ok) {
            throw new Error(await response.json().message);
        }

        window.location = '/index.html'
    }
    catch(error) {
        alert(error.message);
    }
    
}

export async function likeGetRequest(id) {
    let url = `http://localhost:3030/data/likes?where=movieId%3D%22${id}%22&distinct=_ownerId&count`;
    try{
        let response = await fetch(url)
        if(!response.ok) {
            throw new Error(await response.json().message);
        }

        let data = await response.json();
        return data;
    }
    catch(error) {
        alert(error.message);
    }
}

export async function likePostRequest(movieId) {
    
    let url = `http://localhost:3030/data/likes`;
    let token = sessionStorage.getItem('authToken');
    
    try{
        let response = await fetch(url, {
            method: 'POST',
            headers: {
                'X-Authorization': token
            },
            body: JSON.stringify({movieId})
        })

        if(!response.ok) {
            throw new Error(await response.json().message);
        }
         await response.json();
    
        let likes = await likeGetRequest(movieId);
        let likesElement = document.querySelector('#likes');
        likesElement.textContent = `Liked: ${likes}`;
    }
    catch(error) {
        alert(error.message);
    }
}

async function unlikeRequest(likeId, movieId) {
    let url = `http://localhost:3030/data/likes/` + likeId;
    let token = sessionStorage.getItem('authToken');
    try{
        let response = await fetch(url, {
            method: 'delete',
            headers: {
                'X-Authorization': token
            }
        })
        if(!response.ok) {
            throw new Error(await response.json().message);
        }
        await response.json();

        let likes = await likeGetRequest(movieId);
        let likesElement = document.querySelector('#likes');
        likesElement.textContent = `Liked: ${likes}`;
    }
    catch(error) {
        alert(error.message);
    }
}

export async function isLike(movieId, ownerId, likeButton) {
    const url = `http://localhost:3030/data/likes?where=movieId%3D%22${movieId}%22%20and%20_ownerId%3D%22${ownerId}%22`;
    try{
        const response = await fetch(url);
        if(!response.ok) {
            throw new Error(await response.json().message);
        }
        let likes = await response.json();
        if(likes.length > 0) {
            likeButton.textContent = 'Unlike';
        } else {
            likeButton.textContent = 'Like';
            return;
        }
            return likes[0]._id;
    }
    catch(error) {
        alert(error.message);
    }
}