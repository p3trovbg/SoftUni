import { getToken } from "./api/userStorage.js";
import { page, render } from "./lib.js";
import { browseView } from "./views/browse.js";
import { createView } from "./views/create.js";
import { editView } from "./views/edit.js";
import { homeView } from "./views/home.js";
import { loginView } from "./views/login.js";
import { myTeamView } from "./views/my-teams.js";
import { registerView } from "./views/register.js";
import { teamHomeView } from "./views/details.js";
import { logout } from "./api/users.js";
const main = document.querySelector('main');


page(middleFunction);
page('/home', homeView);
page('/login', loginView);
page('/create', createView);
page('/edit/:id', editView);
page('/browse', browseView);
page('/register', registerView);
page('/myteams', myTeamView);
page('/details/:id', teamHomeView); 
page('/', '/home');
onNav();

page.start();

function middleFunction(ctx, next) {
    ctx.render = (template) => render(template, main);
    ctx.onNav = onNav;
    next();
}



function onNav() {
    let token = getToken();
    if(token == null) { 
        [...document.querySelectorAll('.user')].forEach(e => e.style.display = 'none');
        [...document.querySelectorAll('.guest')].forEach(e => e.style.display = 'inline-block')
    } else {
        [...document.querySelectorAll('.user')].forEach(e => e.style.display = 'inline-block');
        [...document.querySelectorAll('.guest')].forEach(e => e.style.display = 'none');
    }
}

document.getElementById('logoutBtn').addEventListener('click', async(e) => {
    await logout();
    page.redirect('/home');
})
