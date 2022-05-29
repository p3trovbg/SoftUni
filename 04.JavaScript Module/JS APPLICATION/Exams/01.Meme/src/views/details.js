import { deleteMemeById, getMemeById } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html } from "../library.js";

const detailsTemplate = (meme, isOwner, deleteMeme) => html`
<section id="meme-details">
    <h1>
        Meme Title: ${meme.title}
    </h1>
    <div class="meme-details">
        <div class="meme-img">
            <img alt="meme-alt" src=${meme.imageUrl}>
        </div>
        <div class="meme-description">
            <h2>Meme Description</h2>
            <p>
                ${meme.description}
            </p>

            <!-- Buttons Edit/Delete should be displayed only for creator of this meme  -->
            ${
                isOwner ? html`
                      <a class="button warning" href="${`/edit/${meme._id}`}">Edit</a>
            <button class="button danger"} @click=${deleteMeme}>Delete</button>
                ` : ''
            }

    </div>
</section>
`

export async function detailsView(ctx) {
    let meme = await getMemeById(ctx.params.id);
    let isOwner = false;
    let token = getToken();
    if(token) {
        token = JSON.parse(token);
        isOwner = token._id == meme._ownerId ? true : false;
    }
    ctx.render(detailsTemplate(meme, isOwner, deleteMeme)); 

    async function deleteMeme() {
        if (confirm("Do you want delete?!")) {
        } else {
          return;
        }

        await deleteMemeById(ctx.params.id);
        ctx.page.redirect('/allmemes');
    }
}


