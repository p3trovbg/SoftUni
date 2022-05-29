import { movieSection } from "../app.js";
import { createElement } from "../createDomElement.js";
import { bar } from '../controller.js';
import {loadView } from '../loadView.js';
import { likeFunc, editFunc, deleteFunc, likeGetRequest, isLike } from "./manipulations.js";
export {description, title, imgSrc}

let title = '';
let imgSrc = '';
let description = '';

export async function loadAllFilms() {
    const url = `http://localhost:3030/data/movies`;
    try{
        let response = await fetch(url);
        if(!response.ok) {
            throw new Error(await response.json().message);
        }

        let films = await response.json();
        for (const key in films) {
            let film = films[key];
             createFilm(film);
        }
    }
    catch(error){
        alert(error.message);
    }
}

async function createFilm(film) {
    //element, textCon, type, className, value, parent, src, attributeValue, attributeType, href
     let divParent = createElement('div', '', '', 'card mb-4', '', movieSection);
     divParent.id = film._id;
     
     let img = createElement('img', '', '', 'card-img-top', '', divParent, film.img);
     img.setAttribute('alt', 'Card image cap');
     img.setAttribute('width', '400');
     createElement('div', '', '', 'card-body', '', divParent);
     createElement('h4', film.title, '', 'card-title', '', divParent.lastChild);
     createElement('div', '', '', 'card-footer', '', divParent);
     let aElement = createElement('a', '', '', '', '', divParent.lastChild, '', '', '', '#');
     let detailsButton = createElement('button', 'Details', 'button', 'btn btn-info', '', aElement);
     detailsButton.addEventListener('click', (e) => {
         description = film.description;
         title = film.title;
         imgSrc = film.img;
         createDetailsFilm(film, divParent, film._ownerId);
     });
}

 async function createDetailsFilm(film, divFilm, ownerId) {
    //element, textCon, type, className, value, parent, src, attribute
 let sectionInfo = createElement('section', undefined, undefined, undefined, undefined, divFilm);

 let divParent = createElement('div', undefined, undefined, 'row bg-light text-dark', undefined, sectionInfo);
 createElement('h1', `Movie title: ${film.title}`, undefined, undefined, undefined, divParent);
 createElement('div', undefined, undefined, 'col-md-8', undefined, divParent);
 createElement('img', undefined, undefined, 'img-thumbnail', undefined, divParent.lastChild, film.img, 'Movie', 'alt');

 let additionalInfo = createElement('div', undefined, undefined, 'col-md-4 text-center', undefined, divParent);
 createElement('h3', 'Movie Description', undefined,  'my-3', undefined, additionalInfo);
 createElement('p', film.description,undefined,  'description', undefined, additionalInfo);
 //Buttons
 let deleteButton = createElement('a', 'Delete', undefined, 'btn btn-danger', undefined, additionalInfo);
 deleteButton.id = divFilm.id;
 let editButton = createElement('a', 'Edit', undefined, 'btn btn-warning edit-film', undefined, additionalInfo);
 editButton.id = divFilm.id;
 let likeButton = createElement('a', '', '', 'btn btn-primary', undefined, additionalInfo);

 likeButton.id = divFilm.id;

 await isLike(divFilm.id, sessionStorage.getItem('ownerId'), likeButton);
 let likes = await likeGetRequest(divFilm.id);
 let likesElement = createElement('span', `Liked: ${likes}`, undefined, 'enrolled-span', undefined, additionalInfo, undefined, undefined, '#');
 likesElement.id = 'likes'; 
 
 let userId = sessionStorage.getItem('ownerId');
 if(userId == null) {
     deleteButton.style.display = 'none';
     editButton.style.display = 'none';
     likeButton.style.display = 'none';
 }
 if(userId == ownerId) {
     likeButton.style.display = 'none';
 } else {
    deleteButton.style.display = 'none';
    editButton.style.display = 'none';
 }

 deleteButton.addEventListener('click', deleteFunc);
 //editButton.addEventListener('click', editFunc);
 likeButton.addEventListener('click', likeFunc);

 loadView([bar, sectionInfo])
}
