import { getUserTeams } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html, until, styleMap } from "../lib.js";
import { getMembersCount } from "./browse.js";

const myTeamTemplate = (owners) => html`
<section id="my-teams">

    <article class="pad-med">
        <h1>My Teams</h1>
    </article>

    <article class="layout narrow" style=${styleMap({display: owners.length > 0 ? 'none' : 'block'})}>
        <div class="pad-med">
            <p>You are not a member of any team yet.</p>
            <p><a href="/browse">Browse all teams</a> to join one, or use the button bellow to cerate your own
                team.</p>
        </div>
        <div class=""><a href="/create" class="action cta">Create Team</a></div>
    </article>

    ${owners.map(owner => html`
    <article class="layout">
        <img src=${owner.team.logoUrl} class="team-logo left-col">
        <div class="tm-preview">
            <h2>${owner.team.name}</h2>
            <p>${owner.team.description}</p>
            <span class="details">${until(getMembersCount(owner.team._id), html`<span>Loading...</span>`)} Members</span>
            <div><a href="${`/details/${owner.team._id}`}" class="action">See details</a></div>
        </div>
    </article>
    `)}
</section>
`


export async function myTeamView(ctx) {
    let token = getToken();
    if (token !== null) {
        token = JSON.parse(token);
    }
    
    let teams = await getUserTeams(token._id);
    ctx.render(myTeamTemplate(teams));
}