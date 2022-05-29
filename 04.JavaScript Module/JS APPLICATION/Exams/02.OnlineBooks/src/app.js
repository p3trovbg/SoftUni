import { logout } from "./api/users.js";
import { getToken } from "./api/userStorage.js";
import { render, page } from "./library.js";
import { createView } from "./views/create.js";
import { dashboardView } from "./views/dashboard.js";
import { deleteBook, detailsView } from "./views/details.js";
import { editView } from "./views/edit.js";
import { loginView } from "./views/login.js";
import { myBookView } from "./views/mybooks.js";
import { registerView } from "./views/register.js";

const main = document.getElementById('site-content');

page(middleFunc);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', registerView);
page('/details/:id', detailsView);
page('/delete/:id', deleteBook);
page('/edit/:id', editView);
page('/add', createView);
page('/mybooks', myBookView)
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
        document.querySelector('#user').style.display = 'none';
        document.querySelector('#guest').style.display = 'block';

    } else {
        token = JSON.parse(token).email;
        document.querySelector('#user span').textContent = `Welcome, ${token}`
        document.querySelector('#user').style.display = 'block';
        document.querySelector('#guest').style.display = 'none';
    }
}


document.querySelector('#logout').addEventListener('click', async(e) => {
    await logout();
    page.redirect('/dashboard');
})