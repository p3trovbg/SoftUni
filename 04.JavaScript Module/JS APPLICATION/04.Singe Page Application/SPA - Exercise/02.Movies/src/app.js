import { loadHomeView, loginView, registerView, registerRequest, loginRequest, logoutRequest, loadFilms, createView, updateFilm } from './controller.js';
loadHomeView();
loadFilms();
barSettings();



export { movieSection }
export {movies, buttonId}


let buttonId;
let movies = document.querySelector('#movie')
let movieSection = document.querySelector('.card-deck');
document.addEventListener('click', onNavigator);

let sections = {
    'navbar-brand text-light': loadHomeView,
    'nav-link login': loginView,
    'nav-link register': registerView,
    'btn btn-primary reg': registerRequest,
    'btn btn-primary log': loginRequest,
    'nav-link logout': logoutRequest,
    'btn btn-warning': createView,
    'btn btn-warning edit-film': updateFilm
}

function onNavigator(e) {
    let target = e.target;
    if(target.tagName == 'A' || target.tagName =='BUTTON') {
        const view = sections[target.className];
        if(typeof view == 'function') {
            e.preventDefault();
            buttonId = target.id;
            view();
        }
    }
}

function barSettings() {
    let token = sessionStorage.getItem('authToken');
    if(token == null) {
        document.querySelector('.info').style.display = 'none';
        document.querySelector('.logout').style.display = 'none';
        document.querySelector('#add-movie-button').style.display = 'none';

    } else {
        document.querySelector('#add-movie-button').style.display = 'block';
        document.querySelector('.info').style.display = 'block';
        document.querySelector('.info').textContent = `Welcome: ${sessionStorage.getItem('userEmail')}`;
        document.querySelector('.logout').style.display = 'block';

        document.querySelector('.register').style.display = 'none';
        document.querySelector('.login').style.display = 'none';
    }
}