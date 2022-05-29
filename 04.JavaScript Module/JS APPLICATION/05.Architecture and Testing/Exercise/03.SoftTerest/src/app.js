import { logout } from "./api/users.js";
import { initial } from "./router.js"
import { createView } from "./views/create.js";
import { dashboardView } from "./views/dashboard.js";
import { homeView } from "./views/home.js";
import { loginView } from "./views/login.js";
import { registerView } from "./views/register.js";

document.querySelector('#sections').remove();

const links = {
    '/': homeView,
    '/login': loginView,
    '/register': registerView,
    '/create': createView,
    '/dashboard': dashboardView,
    '/logout': logOut
}
const router = initial(links);


//Start engine
router.goTo('/');

function logOut() {
    logout();
    router.goTo('/');
}