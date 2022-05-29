import { getAllMemes } from "../api/data.js";
import { html, styleMap } from "../library.js";

const memesTemplate = (memes) => html`
<section id="meme-feed">
    <h1>All Memes</h1>
    <div id="memes">
        <!-- Display : All memes in database ( If any ) -->
        ${memes.map(m => html`
        <div class="meme">
            <div class="card">
                <div class="info">
                    <p class="meme-title">${m.title}</p>
                    <img class="meme-image" alt="meme-img" src=${m.imageUrl}>
                </div>
                <div id="data-buttons">
                    <a class="button" href="${`/details/${m._id}`}">Details</a>
                </div>
            </div>
        </div>
        `)}
        <!-- Display : If there are no memes in database -->
        <p class="no-memes" style=${styleMap({display: memes.length > 0 ? 'none' : 'block'})}>No memes in database.</p>
    </div>
</section>
`

export async function memesView(ctx) {
    let memes = await getAllMemes();
    ctx.render(memesTemplate(memes));
}