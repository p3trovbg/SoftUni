import { getAllGames } from "../api/data.js";
import { html, styleMap } from "../library.js";


//Section
const catalogTemplate = (games) => html`
<section id="catalog-page">
    <h1>All Games</h1>
    <!-- Display div: with information about every game (if any) -->
    ${games.map(game => html`
    <div class="allGames">
        <div class="allGames-info">
            <img src="${game.imageUrl}">
            <h6>${game.type}</h6>
            <h2>${game.title}</h2>
            <a href="${`/details/${game._id}`}" class="details-button">Details</a>
        </div>
    </div>
    `)}
    <!-- Display paragraph: If there is no games  -->
    <h3 class="no-articles" style=${styleMap({display: games.length == 0 ? 'block' : 'none'})}>No articles yet</h3>
</section>
`

export async function catalogView(ctx) {
    let games = await getAllGames();
    ctx.render(catalogTemplate(games));
}