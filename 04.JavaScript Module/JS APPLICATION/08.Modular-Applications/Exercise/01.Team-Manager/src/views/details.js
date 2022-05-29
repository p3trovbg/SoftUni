import { becomeMember, deleteMember, getTeamById, getTeamMembers, setMemberStatus } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html, styleMap } from "../lib.js";




const teamHomeTemplate = (team, infoTeams, token, operations) => { 
const styleForOwner = {
    display: team._ownerId == token ? 'inline-block' : 'none'
  };


const removeMemberStyle  = {
    display: team._ownerId == token ? 'inline-block' : 'none'
}
const leaveButtonStyle = {
    display: infoTeams.isMember &&  team._ownerId !== token ? 'inline-block' : 'none'
}
  
 const joinButtonStyle = {
    display: team._ownerId == token || token == 1 || infoTeams.isWaiting || infoTeams.isMember ? 'none' : 'inline-block'
 } 

 const dependingStyle = {
    display: infoTeams.isWaiting ? 'inline-block' : 'none'

 }
return html`
<section id="team-home">
    <article class="layout">
        <img src=${team.logoUrl} class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${infoTeams.joinedMembers.length} Members</span>
            <div>
                <a href="${`/edit/${team._id}`}" class="action" style=${styleMap(styleForOwner)}>Edit team</a>
                <a @click=${(e) => operations.join(e, team._id)} href="/join" class="action" style=${styleMap(joinButtonStyle)}>Join team</a>
                <a @click=${(e) => operations.cancelRequest(e, infoTeams.isMember)} href="/leave" class="action invert" style=${styleMap(leaveButtonStyle)}>Leave team</a>
                <div style=${styleMap(dependingStyle)}>Membership pending.
                    <a @click=${(e) => operations.cancelRequest(e, infoTeams.isWaiting)} href="/cancelRequest">Cancel request</a>
                </div>
            </div>
        </div>
        <div class="pad-large">
            <h3>Members</h3>
            <ul class="tm-members">
                ${infoTeams.joinedMembers.map(m => html`
                <li>${m.user.username}
                    <a @click=${(e) => operations.cancelRequest(e, m._id)} href="${`/remove/${m._id, token}`}" class="tm-control action" style=${styleMap(removeMemberStyle)}>Remove from team</a>
                </li>
                `)}
            </ul>
        </div>
        <div class="pad-large" style=${styleMap(styleForOwner)}>
            <h3>Membership Requests</h3>
            <ul class="tm-members">
                ${infoTeams.memberships.map(m => html`
                    <li>${m.user.username}<a @click=${(e) => operations.approve(e, m._id)} href="/approve" class="tm-control action">Approve</a>
                    <a @click=${(e) => operations.cancelRequest(e, m._id)} href="/decline" class="tm-control action">Decline</a></li>   
                    `)}
            </ul>
        </div>
    </article>
</section>

`}

export async function teamHomeView(ctx) {
    let teamId = ctx.params.id;
    let token = getToken();

    if (token != null) {
        token = JSON.parse(token)._id;
    } else {
        token = 1;
    }

    let [team, members] = await Promise.all(
        [
             getTeamById(teamId),
             getTeamMembers(teamId)
        ]
    )

    let typeMembers = getTypeMembers(members);

    let operations = {
        'approve': approve,
        'cancelRequest': cancelRequest,
        'join': join,
    }
    ctx.render(teamHomeTemplate(team, typeMembers, token, operations));


    async function cancelRequest(e, memberId) {
        e.preventDefault();
        let parent = e.target.parentElement;

        await deleteMember(memberId);
        if(parent.tagName != 'DIV') {
            e.target.parentElement.remove();
        } 
        

        members = await  getTeamMembers(teamId);
        typeMembers = getTypeMembers(members);

        ctx.render(teamHomeTemplate(team, typeMembers, token, operations));
    }


    async function join(e, teamId) {
        e.preventDefault();
        await becomeMember(teamId);

        members = await  getTeamMembers(teamId);
        typeMembers = getTypeMembers(members);

        ctx.render(teamHomeTemplate(team, typeMembers, token, operations));
    }

    async function approve(e, userId) {
        e.preventDefault();
        await setMemberStatus(userId, 'member');
        e.target.parentElement.remove();

        members = await  getTeamMembers(teamId);
        typeMembers = getTypeMembers(members);

        ctx.render(teamHomeTemplate(team, typeMembers, token, operations));
    }


         function getTypeMembers(members) {
        let joinedMembers = members.filter(x => x.status !== 'pending');
        let memberships = members.filter(x => x.status == 'pending');

        let isWaiting = memberships.filter(x => x._ownerId == token);
        if(isWaiting.length == 1) {
            isWaiting = isWaiting[0]._id;
        } else {
            isWaiting = null;
        }

        let isMember = joinedMembers.filter(x => x._ownerId == token);
        if(isMember.length == 1) {
            isMember = isMember[0]._id;
        } else {
            isMember = null;
        }
        return {joinedMembers, memberships, isWaiting, isMember};
    }
}

