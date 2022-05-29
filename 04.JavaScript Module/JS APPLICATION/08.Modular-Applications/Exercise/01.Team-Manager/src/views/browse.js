import { getAllTeams, getTeamMembers } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html, until,styleMap } from "../lib.js";


const browseTemplate = (teams) => html`
<section id="browse">

    <article class="pad-med">
        <h1>Team Browser</h1>
    </article>

    <article class="layout narrow" style=${styleMap({display: getToken() ? 'block' : 'none'})}>
        <div class="pad-small" ><a href="/create" class="action cta">Create Team</a></div>
    </article>

    ${teams.map(t => html`
    <article class="layout">
        <img src=${t.logoUrl} class="team-logo left-col">
        <div class="tm-preview">
            <h2>${t.name}</h2>
            <p>${t.description}</p>
            <span class="details">${until(getMembersCount(t._id), html`<span>Loading...</span>`)} Members</span>
            <div><a href="${`/details/${t._id}`}" class="action">See details</a></div>
        </div>
    </article>
    `)}
</section>
`


export async function browseView(ctx) {
    let teams = await getAllTeams();
    ctx.render(browseTemplate(teams));
}

export async function getMembersCount(id) {
    let users = await getTeamMembers(id)
    users = users.filter(x => x.status == 'member');
    return users.length;
}