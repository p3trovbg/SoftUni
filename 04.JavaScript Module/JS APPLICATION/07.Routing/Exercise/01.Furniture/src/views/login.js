import { login } from "../api/users.js";
import { html } from "../library.js";

const loginTemplate = (onSubmit) => html`
<div class="row space-top">
<div class="col-md-12">
    <h1>Login User</h1>
    <p>Please fill all fields.</p>
</div>
</div>
<form @submit=${onSubmit}>
<div class="row space-top">
    <div class="col-md-4">
        <div class="form-group">
            <label class="form-control-label" for="email">Email</label>
            <input class="form-control" id="email" type="text" name="email">
        </div>
        <div class="form-group">
            <label class="form-control-label" for="password">Password</label>
            <input class="form-control" id="password" type="password" name="password">
        </div>
        <input type="submit" class="btn btn-primary" value="Login" />
    </div>
</div>
</form>`


export function loginView(ctx) {
    ctx.render(loginTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let name = form.get('email').trim();
        let password = form.get('password').trim();

        if(!name || !password) {
            alert('You should fill all fields!')
            return;
        }
        
        await login(name, password);
        
        ctx.upNav();
        ctx.page.redirect('/dashboard');
    }
}