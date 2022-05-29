import { page, render } from "./library.js";
import { dashboardView } from "./views/dashboard.js";
import { getToken } from "./api/userStorage.js";
import { loginView } from "./views/login.js";
import { reigsterView } from "./views/register.js";
import { createview } from "./views/create.js";
import { deleteFurniture, detailsView } from "./views/details.js";
import { ownerFurnitureView } from "./views/my-furniture.js";
import { editView } from "./views/edit.js";
import { logout } from "./api/users.js";

const main = document.querySelector('#main');
let context;

page(decorateContext);
page('/dashboard', dashboardView);
page('/login', loginView);
page('/register', reigsterView);
page('/create', createview);
page('/details/edit/:id', editView);
page('/details/:id', detailsView);
page('/own', ownerFurnitureView);
page('/details/delete/:id', deleteFurniture);
page('/', '/dashboard');


updateNav();
page.start();

async function decorateContext(ctx, next) {
    ctx.render = (template) => render(template, main);
    ctx.upNav = updateNav;
    next();
    context = ctx;
}


function updateNav() {
    let token = getToken();
    if(token == null) {
        document.querySelector('#guest').style.display = 'inline-block';
        document.querySelector('#user').style.display = 'none';
    } else {
        document.querySelector('#guest').style.display = 'none';
        document.querySelector('#user').style.display = 'inline-block';
    }
}

document.getElementById('logoutBtn').addEventListener('click', async(e) => {
    await logout();
    context.upNav();
    context.page.redirect('/dashboard');
})
