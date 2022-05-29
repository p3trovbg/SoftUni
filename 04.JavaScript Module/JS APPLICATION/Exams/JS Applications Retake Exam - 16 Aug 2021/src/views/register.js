import { register } from "../api/users.js";
import { html } from "../library.js";


//Section
const registerTemplate = (onSubmit) => html`

<section id="register-page" class="content auth">
            <form id="register" @submit=${onSubmit}>
                <div class="container">
                    <div class="brand-logo"></div>
                    <h1>Register</h1>

                    <label for="email">Email:</label>
                    <input type="email" id="email" name="email" placeholder="maria@email.com">

                    <label for="pass">Password:</label>
                    <input type="password" name="password" id="register-password">

                    <label for="con-pass">Confirm Password:</label>
                    <input type="password" name="confirm-password" id="confirm-password">

                    <input class="btn submit" type="submit" value="Register">

                    <p class="field">
                        <span>If you already have profile click <a href="/login">here</a></span>
                    </p>
                </div>
            </form>
        </section>
`

export function registerView(ctx) {
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let email = form.get('email').trim();
        let password = form.get('password').trim();
        let confirmPassword = form.get('confirm-password').trim();

        if(!email || !password || !confirmPassword) {
            alert('You should fill all fields!');
            return;
        }

        if(password != confirmPassword) {
            alert('You not have same password');
            return;
        }

        await register(email, password); // edit
        ctx.updateNav();
        ctx.page.redirect('/home'); // edit
    }
}