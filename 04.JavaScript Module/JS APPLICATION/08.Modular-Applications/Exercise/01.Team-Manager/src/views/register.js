import { register } from "../api/users.js";
import { html , styleMap} from "../lib.js";


const registerTemplate = (onSubmit, valid = true, error) => html`
<section id="register">
    <article class="narrow">
        <header class="pad-med">
            <h1>Register</h1>
        </header>
        <form id="register-form" class="main-form pad-large" @submit=${onSubmit}>
            <div class="error" style=${styleMap({display: valid ? 'none' : 'block'})}>${error}</div>
            <label>E-mail: <input type="text" name="email"></label>
            <label>Username: <input type="text" name="username"></label>
            <label>Password: <input type="password" name="password"></label>
            <label>Repeat: <input type="password" name="repass"></label>
            <input class="action cta" type="submit" value="Create Account">
        </form>
        <footer class="pad-small">Already have an account? <a href="/login" class="invert">Sign in here</a>
        </footer>
    </article>
</section>
`

export function registerView(ctx) {
    let isValid;
    ctx.render(registerTemplate(onSubmit, isValid));
    ctx.onNav();
    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let emailReg = new RegExp(`^[a-z0-9](\.?[a-z0-9]){2,}@([a-z]+).([a-z]){2,}$`);

        let email = form.get('email').trim();
        let valid = emailReg.test(email);

        let username = form.get('username').trim();
        let password = form.get('password').trim();
        let repass = form.get('repass').trim();

        try{

            if(!email || !username || !password || !repass) {
                throw new Error('You must fill all fields!')
            }

            if(!valid) {
                throw new Error('Invalid email!')
            }

            await register(email, username, password);
            ctx.onNav();
            ctx.page.redirect('/myteams');
        }
        catch(error) {
           isValid = false;
           ctx.render(registerTemplate(onSubmit, isValid, error.message));
        }
    }
}