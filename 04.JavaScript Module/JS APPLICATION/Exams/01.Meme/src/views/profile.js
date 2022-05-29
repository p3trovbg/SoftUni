import { getUserMemes } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html, styleMap } from "../library.js";

const profileTemplate = (userInfo, memes) => html`
<section id="user-profile-page" class="user-profile">
    <article class="user-info">
        <img id="user-avatar-url" alt="user-profile" src="/images/female.png">
        <div class="user-content">
            <p>Username: ${userInfo.username}</p>
            <p>Email: ${userInfo.email}</p>
            <p>My memes count: ${memes.length}</p>
        </div>
    </article>
    <h1 id="user-listings-title">User Memes</h1>
    <div class="user-meme-listings">
        <!-- Display : All created memes by this user (If any) -->
        ${memes.map(m => html`
        <div class="user-meme">
            <p class="user-meme-title">${m.title}</p>
            <img class="userProfileImage" alt="meme-img" src=${m.imageUrl}>
            <a class="button" href="${`/details/${m._id}`}">Details</a>
        </div>
        `)}
        <!-- Display : If user doesn't have own memes  -->
        <p class="no-memes" style=${styleMap({display: memes.length > 0 ? 'none' : 'block'})}>No memes in database.</p>
    </div>
</section>
`

export async function profileView(ctx) {
    let token = getToken();
    if (token) {
        token = JSON.parse(token);
    }
    console.log(token);
    let memes = await getUserMemes(token._id);
    console.log(memes)
    ctx.render(profileTemplate(token, memes));
}