import { editTeam, getTeamById } from "../api/data.js";
import { html, styleMap } from "../lib.js";


const editTemplate = (onEdit, team, isValid = true, error) => html`
<section id="edit">
    <article class="narrow">
        <header class="pad-med">
            <h1>Edit Team</h1>
        </header>
        <form id="edit-form" class="main-form pad-large" @submit=${onEdit}>
            <div class="error" style=${styleMap({display: isValid ? 'none' : 'block'})}>${error}</div>
            <label>Team name: <input type="text" name="name" .value=${team.name}></label>
            <label>Logo URL: <input type="text" name="logoUrl" .value=${team.logoUrl}></label>
            <label>Description: <textarea name="description" .value=${team.description}></textarea></label>
            <input class="action cta" type="submit" value="Save Changes">
        </form>
    </article>
</section>
`

export async function editView(ctx) {
    let isValid;
    let team = await getTeamById(ctx.params.id);
    ctx.render(editTemplate(onEdit, team, isValid));

    async function onEdit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let name = form.get('name').trim();
        let logoUrl = form.get('logoUrl').trim();
        let description = form.get('description').trim();
        try {
            if(!name || !logoUrl || !description) {
                throw new Error('You must fill all fields!');
            }
            await editTeam(ctx.params.id, {name, logoUrl, description});
            ctx.page.redirect(`/details/${ctx.params.id}`);
        }
        catch(error){
            isValid = false;
            ctx.render(editTemplate(onEdit, team, isValid, error.message));
        }
    }
}