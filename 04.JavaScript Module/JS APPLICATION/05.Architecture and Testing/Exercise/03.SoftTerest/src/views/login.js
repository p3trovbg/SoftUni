import { login } from "../api/users.js";

let loginPage = document.querySelector('#login');
let ctx = '';
export function loginView(context) {
    context.showSection(loginPage);
    ctx = context;
    loginPage.querySelector('form').addEventListener('submit', async(e) => {
        e.preventDefault();
        let formData = new FormData(e.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();

        if(!email || !password) {
            alert('You should fill all fields!');
            return;
        }
        
        await login(email, password);
        ctx.typeNav();
        ctx.goTo('/');
    })
}