import { login } from "../api/users.js";
import { html, styleMap } from "../library.js";

const loginTemplate = (onSubmit) => html`
<section id="login-page" class="login">
    <form id="login-form" @submit=${onSubmit}>
        <fieldset>
            <legend>Login Form</legend>
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
            <input class="button submit" type="submit" value="Login">
        </fieldset>
    </form>
</section>
`

export function loginView(ctx) {
    ctx.render(loginTemplate(onSubmit));


    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let email = form.get('email').trim();
        let password = form.get('password').trim();

        if(!email || !password) {
            alert('You should fill all fields!');
            return;
        }

        await login(email, password);

        ctx.updateNav();
        ctx.page.redirect('/dashboard');
    }
}