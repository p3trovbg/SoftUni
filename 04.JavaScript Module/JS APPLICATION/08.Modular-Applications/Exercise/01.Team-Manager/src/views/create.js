import { becomeMember, createTeam, setMemberStatus } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html, styleMap } from "../lib.js";


const createTemplate = (onSubmit, isValid, error) => html`
<section id="create">
    <article class="narrow">
        <header class="pad-med">
            <h1>New Team</h1>
        </header>
        <form id="create-form" class="main-form pad-large" @submit=${onSubmit}>
            <div class="error" style=${styleMap({display: isValid ? 'none' : 'block'})}>${error}</div>
            <label>Team name: <input type="text" name="name"></label>
            <label>Logo URL: <input type="text" name="logoUrl"></label>
            <label>Description: <textarea name="description"></textarea></label>
            <input class="action cta" type="submit" value="Create Team">
        </form>
    </article>
</section>
`

export function createView(ctx) {
    let isValid;
    ctx.render(createTemplate(onSubmit, isValid));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let name = form.get('name').trim();
        let logoUrl = form.get('logoUrl').trim();
        let description = form.get('description').trim();
        try {
            if(!name || !logoUrl || !description) {
                throw new Error('You must fill all fields!');
            }

            let [team] = await Promise.all([
                createTeam({name, logoUrl, description})
            ])

            //Create request for member on current team.
                let memberInfo = await becomeMember(team._id)
                await setMemberStatus(memberInfo._id, 'member');
            
            ctx.page.redirect(`/details/${team._id}`);
        }
        catch(error){
            isValid = false;
            ctx.render(createTemplate(onSubmit, isValid, error.message));
        }
    }
}