import { register } from "../api/users.js";
import { html } from "../library.js";

const registerTemplate = (onSubmit) => html`
    <section id="register">
            <form id="register-form" @submit=${onSubmit}>
                <div class="container">
                    <h1>Register</h1>
                    <label for="username">Username</label>
                    <input id="username" type="text" placeholder="Enter Username" name="username">
                    <label for="email">Email</label>
                    <input id="email" type="text" placeholder="Enter Email" name="email">
                    <label for="password">Password</label>
                    <input id="password" type="password" placeholder="Enter Password" name="password">
                    <label for="repeatPass">Repeat Password</label>
                    <input id="repeatPass" type="password" placeholder="Repeat Password" name="repeatPass">
                    <div class="gender">
                        <input type="radio" name="gender" id="female" value="female">
                        <label for="female">Female</label>
                        <input type="radio" name="gender" id="male" value="male" checked>
                        <label for="male">Male</label>
                    </div>
                    <input type="submit" class="registerbtn button" value="Register">
                    <div class="container signin">
                        <p>Already have an account?<a href="/login">Sign in</a>.</p>
                    </div>
                </div>
            </form>
        </section>
`

export function registerView(ctx) {
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let username = form.get('username').trim();
        let email = form.get('email').trim();
        let password = form.get('password').trim();
        let repeatPass = form.get('repeatPass').trim();
        let gender = form.get('gender');  


        if(!username || !email || !password || !repeatPass || !gender) {
            alert('You should fill all fields!');
            return;
        }

        if(password !== repeatPass) {
            alert('Error password');
            return; 
        }

        await register(username, email, password, gender);
        ctx.updateNav();
        ctx.page.redirect('/allmemes');
    }
}