import { logout } from "./api/users.js";
import { getToken } from "./api/userStorage.js";
import { render, page } from "./library.js";
import { catalogView } from "./views/catalog.js";
import { createView } from "./views/create.js";
import { detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { homeView } from "./views/home.js";
import { loginView } from "./views/login.js";
import { registerView } from "./views/register.js";


const main = document.getElementById('main-content'); // Edit

page(middleFunc);
page('/home', homeView);
page('/login', loginView);
page('/register', registerView);
page('/create', createView);
page('/edit/:id', editView);
page('/details/:id', detailsView);
page('/catalog', catalogView)
page('/', '/home');
updateNav();
page.start();

function middleFunc(ctx, next) {
    ctx.render = (template) => render(template, main);
    ctx.updateNav = updateNav;
    next();
}


function updateNav() { //Edit
    let token = getToken();
    if(token == null) {
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'block';

    } else {
        //token = JSON.parse(token).email;
        //document.querySelector('#user span').textContent = `Welcome, ${token}` // Edit
        document.querySelector('#user').style.display = 'block';
        document.querySelector('#guest').style.display = 'none';
    }
}


document.querySelector('#logout').addEventListener('click', async(e) => {
    await logout();
    updateNav();
    page.redirect('/home'); //Edit
})