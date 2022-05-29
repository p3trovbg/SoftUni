import { register } from "../api/users.js";
import { html, styleMap } from "../library.js";

const registerTemplate = (onSubmit) => html`
   <section id="register-page" class="register">
            <form id="register-form" @submit=${onSubmit}>
                <fieldset>
                    <legend>Register Form</legend>
                    <p class="field">
                        <label for="email">Email</label>
                        <span class="input">
                            <input type="text" name="email" id="email" placeholder="Email">
                        </span>
                    </p>
                    <p class="field">
                        <label for="password">Password</label>
                        <span class="input">
                            <input type="password" name="password" id="password" placeholder="Password">
                        </span>
                    </p>
                    <p class="field">
                        <label for="repeat-pass">Repeat Password</label>
                        <span class="input">
                            <input type="password" name="confirm-pass" id="repeat-pass" placeholder="Repeat Password">
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Register">
                </fieldset>
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
        let confirmPass = form.get('confirm-pass').trim();

        if(!email || !password || !confirmPass) {
            alert('You should fill all fields!');
            return;
        }

        if(password !== confirmPass) {
            alert('Error password!'); 
            return;
        }

        await register(email, password);

        ctx.updateNav();
        ctx.page.redirect('/dashboard');
    }
}