import { register } from "../api/users.js";
import { html } from "../library.js";

const registerTemplate = (onSubmit) => html`
        <div class="row space-top">
            <div class="col-md-12">
                <h1>Register New User</h1>
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
                    <div class="form-group">
                        <label class="form-control-label" for="rePass">Repeat</label>
                        <input class="form-control" id="rePass" type="password" name="rePass">
                    </div>
                    <input type="submit" class="btn btn-primary" value="Register" />
                </div>
            </div>
        </form>`


export function reigsterView(ctx) {
    ctx.render(registerTemplate(onSubmit));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let name = form.get('email').trim();
        let password = form.get('password').trim();
        let repeatPassword = form.get('rePass').trim();


        if(!name || !password || !repeatPassword) {
            alert('You should fill all fields!')
            return;
        }

        if(password !== repeatPassword) {
            alert('You should fill fields for password with same values!');
            return;
        }

        await register(name, password);
        
        ctx.upNav();
        ctx.page.redirect('/dashboard');
    }
}