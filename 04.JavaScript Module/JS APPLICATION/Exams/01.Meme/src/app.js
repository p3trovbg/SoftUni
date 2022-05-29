import { logout } from "./api/users.js";
import { getToken } from "./api/userStorage.js";
import { render, page } from "./library.js";
import { createView } from "./views/create.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edti.js";
import { homeView } from "./views/home.js";
import { loginView } from "./views/login.js";
import { memesView } from "./views/memes.js";
import { profileView } from "./views/profile.js";
import { registerView } from "./views/register.js";

const main = document.querySelector('main');


page(middleFunc);
page('/home', homeView);
page('/allmemes', memesView);
page('/login', loginView);
page('/register', registerView);
page('/allmemes', memesView);
page('/create', createView);
page('/details/:id', detailsView);
page('/edit/:id', editView);
page('/profile', profileView);
page('/', '/home');
updateNav();
page.start();

function middleFunc(ctx, next) {
    ctx.render = (template) => render(template, main);
    ctx.updateNav = updateNav;
    next();
}


function updateNav() {
    let token = getToken();
    if(token == null) {
        document.querySelector('.user').style.display = 'none';
        document.querySelector('.guest').style.display = 'block';

    } else {
        token = JSON.parse(token).email;
        document.querySelector('.user span').textContent = `Welcome, ${token}`
        document.querySelector('.user').style.display = 'block';
        document.querySelector('.guest').style.display = 'none';
    }
}



document.querySelector('#logout').addEventListener('click', async(e) => {
    await logout();
    page.redirect('/home');
})