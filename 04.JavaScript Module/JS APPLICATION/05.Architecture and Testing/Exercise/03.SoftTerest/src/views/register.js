import { register } from "../api/users.js";

let registerPage = document.querySelector('#register');
let ctx = '';
export function registerView(context) {
    ctx = context;
    context.showSection(registerPage);
    
    registerPage.querySelector('form').addEventListener('submit', async(e) => {
        e.preventDefault();
        let formData = new FormData(e.target);
        let email = formData.get('email').trim();
        let password = formData.get('password').trim();
        let rePass = formData.get('repeatPassword').trim();

        if(!email || !password || !rePass) {
            alert('You should fill all fields!');
            return;
        }

        await register(email, password);
        ctx.typeNav();
        ctx.goTo('/');
    })
}