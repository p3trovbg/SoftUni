import { login } from "../api/users.js";
import { html, styleMap} from "../lib.js";

const loginTemplate = (onSubmit, isValid = true, error) => html`
<section id="login">
    <article class="narrow">
        <header class="pad-med">
            <h1>Login</h1>
        </header>
        <form id="login-form" class="main-form pad-large" @submit=${onSubmit}>
        <div class="error" style=${styleMap({display: isValid ? 'none' : 'block'})}>${error}</div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Password: <input type="password" name="password"></label>
            <input class="action cta" type="submit" value="Sign In">
        </form>
        <footer class="pad-small">Don't have an account? <a href="/register" class="invert">Sign up here</a>
        </footer>
    </article>
</section>
`

export function loginView(ctx) {
    let isValid;
    ctx.render(loginTemplate(onSubmit, isValid));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let email = form.get('email').trim();
        let password = form.get('password').trim();

        try{
            if(!email || !password) {
                throw new Error('You must fill all fields!')
            }

            await login(email, password);
            ctx.onNav();
            ctx.page.redirect('/myteams');
        }
        catch(error) {
            isValid = false;
            ctx.render(loginTemplate(onSubmit, isValid, error.message));
        }
    }
}