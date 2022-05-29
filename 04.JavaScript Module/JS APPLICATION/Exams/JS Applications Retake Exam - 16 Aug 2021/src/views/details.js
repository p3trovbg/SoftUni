import { createComment, deleteGameById, getComments, getGameDetails } from "../api/data.js";
import { getUserId } from "../api/userStorage.js";
import { html, styleMap } from "../library.js";


//Section
const detailsTemplate = (game, comments ,userId, addComment, deleteGame) => html`
<section id="game-details">
    <h1>Game Details</h1>
    <div class="info-section">

        <div class="game-header">
            <img class="game-img" src="${game.imageUrl}"/>
            <h1>${game.title}</h1>
            <span class="levels">MaxLevel: ${game.maxLevel}</span>
            <p class="type">${game.category}</p>
        </div>

        <p class="text">
           ${game.summary}
        </p>

        <!-- Bonus ( for Guests and Users ) -->
        <div class="details-comments">
            <h2>Comments:</h2>
            <ul>
                <!-- list all comments for current game (If any) -->
                ${comments.map(c => html`
                <li class="comment">
                    <p>Content: ${c.comment}</p>
                </li>
                `)}
               
            </ul>
            <!-- Display paragraph: If there are no games in the database -->
            <p class="no-comment" style=${styleMap({display: comments.length == 0 ? 'block': 'none'})}>No comments.</p>
        </div>

        <!-- Edit/Delete buttons ( Only for creator of this game )  -->
        <div class="buttons" style=${styleMap({display: userId !== null && userId == game._ownerId ? 'block': 'none'})}>
            <a href="${`/edit/${game._id}`}" class="button">Edit</a>
            <a href="/delete" class="button" @click=${(e) => deleteGame(e)}>Delete</a>
        </div>
    </div>

    <!-- Bonus -->
    <!-- Add Comment ( Only for logged-in users, which is not creators of the current game ) -->
    <article class="create-comment" style=${styleMap({display: userId !== null && userId != game._ownerId ? 'block': 'none'})}>
        <label>Add new comment:</label>
        <form class="form" @submit=${addComment}>
            <textarea name="comment" placeholder="Comment......"></textarea>
            <input class="btn submit" type="submit" value="Add Comment">
        </form>
    </article>

</section>
`

export async function detailsView(ctx) {
    let gameId = ctx.params.id;
    let userId = getUserId();
    let[game, comments] = await Promise.all([
        getGameDetails(gameId),
        getComments(gameId)
    ])

    ctx.render(detailsTemplate(game, comments, userId, addComment, deleteGame));


    async function addComment(e) {
        e.preventDefault();
        let form = new FormData(e.target);
        let comment = form.get('comment');
        
        e.target.reset();
        await createComment({gameId, comment})

        let[game, comments] = await Promise.all([
            getGameDetails(gameId),
            getComments(gameId)
        ])

        ctx.render(detailsTemplate(game, comments, userId, addComment, deleteGame));
    }

    async function deleteGame(e) {
        e.preventDefault();

        await deleteGameById(gameId);

        ctx.page.redirect('/home');
    }
}