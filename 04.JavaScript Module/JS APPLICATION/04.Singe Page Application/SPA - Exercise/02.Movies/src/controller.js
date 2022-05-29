import { loadView} from './loadView.js';
import { registerFunc } from './auth/register.js';
import { logout } from './auth/logout.js';
import { loginFunc } from './auth/login.js';
import { create } from './userActions/create.js';
import { loadAllFilms } from './userActions/loadFilms.js';
import { editFunc } from './userActions/manipulations.js'
export {bar, home}

let bar = document.querySelector('.navbar');

let home = document.querySelector('#home-page');
home.remove();

let movies = document.querySelector('#movie');
movies.remove();

let button = document.querySelector('#add-movie-button');
button.remove();

let loginSection = document.querySelector('#form-login');
loginSection.remove();

let registerSection = document.querySelector('#form-sign-up');
registerSection.remove();

let createSection = document.querySelector('#add-movie')
createSection.remove();

let editSection = document.querySelector('#edit-movie');
editSection.remove();


export function loadHomeView() {
    let sections = [bar, home, button, movies];
    loadView(sections);
}

export function createView() {
    loadView([bar, createSection]);
    let form = createSection.querySelector('form');
     create(form);
}

export function updateFilm() {
    loadView([bar, editSection]);
    let form = document.querySelector('form');
    editFunc(form);
}

export function loadFilms() {
    loadAllFilms();
}

export function loginView() {
    loadView([bar, loginSection]);
}

export function registerView() {
    loadView([bar, registerSection]);
}

export function registerRequest() {
    let registerForm = registerSection.querySelector('form');
    registerFunc(registerForm);
}

export function loginRequest() {
    let loginForm = loginSection.querySelector('form');
    loginFunc(loginForm);
}

export function logoutRequest() {
    logout();
}
