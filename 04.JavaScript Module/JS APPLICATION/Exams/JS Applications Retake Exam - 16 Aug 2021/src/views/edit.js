import { getGameDetails, updateGame } from "../api/data.js";
import { html } from "../library.js";


//Section
const editTemplate = (onSubmit, game) => html`
<section id="edit-page" class="auth">
    <form id="edit" @submit=${onSubmit}>
        <div class="container">

            <h1>Edit Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" .value="${game.title}">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" .value="${game.category}">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" .value="${game.maxLevel}">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" .value="${game.imageUrl}">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary">${game.summary}</textarea>
            <input class="btn submit" type="submit" value="Edit Game">

        </div>
    </form>
</section>
`

export async function editView(ctx) {
    let gameId = ctx.params.id;
    let game = await getGameDetails(gameId);

    ctx.render(editTemplate(onSubmit, game));

    async function onSubmit(e) {
        e.preventDefault();
        let form = new FormData(e.target);

        let title = form.get('title').trim();
        let category = form.get('category').trim();
        let maxLevel = form.get('maxLevel').trim();
        let imageUrl = form.get('imageUrl').trim();
        let summary = form.get('summary').trim();

        if(!title || !category || !maxLevel || !imageUrl || !summary) {
            alert('Error!');
            return;
        }

        await updateGame(gameId, {title, category, maxLevel, imageUrl, summary});
        ctx.page.redirect(`/details/${gameId}`);
    }
}
