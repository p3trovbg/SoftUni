import { getLatestGames } from "../api/data.js";
import { html, styleMap } from "../library.js";

const homeTemplate = (games) => html`
    <section id="welcome-world">
    
        <div class="welcome-message">
            <h2>ALL new games are</h2>
            <h3>Only in GamesPlay</h3>
        </div>
        <img src="./images/four_slider_img01.png" alt="hero">
    
        <div id="home-page">
            <h1>Latest Games</h1>
    
            <!-- Display div: with information about every game (if any) -->
            ${games.map(game => html`
            <div class="game">
                <div class="image-wrap">
                    <img src=${game.imageUrl}>
                </div>
                <h3>${game.title}</h3>
                <div class="rating">
                    <span>☆</span><span>☆</span><span>☆</span><span>☆</span><span>☆</span>
                </div>
                <div class="data-buttons">
                    <a href=${`/details/${game._id}`} class="btn details-btn">Details</a>
                </div>
            </div>
            `)}
            <!-- Display paragraph: If there is no games  -->
            <p class="no-articles" style=${styleMap({display: games.length == 0 ? 'block' : 'none' })}>No games yet</p>
        </div>
    </section>
`

export async function homeView(ctx) {
    let latestGames = await getLatestGames();

    ctx.render(homeTemplate(latestGames));
}