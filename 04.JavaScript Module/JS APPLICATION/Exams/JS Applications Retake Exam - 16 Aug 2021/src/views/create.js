import { createGame } from "../api/data.js";
import { html } from "../library.js";


//Section
const createTemplate = (onSubmit) => html`
<section id="create-page" class="auth">
    <form id="create" @submit=${onSubmit}>
        <div class="container">

            <h1>Create Game</h1>
            <label for="leg-title">Legendary title:</label>
            <input type="text" id="title" name="title" placeholder="Enter game title...">

            <label for="category">Category:</label>
            <input type="text" id="category" name="category" placeholder="Enter game category...">

            <label for="levels">MaxLevel:</label>
            <input type="number" id="maxLevel" name="maxLevel" min="1" placeholder="1">

            <label for="game-img">Image:</label>
            <input type="text" id="imageUrl" name="imageUrl" placeholder="Upload a photo...">

            <label for="summary">Summary:</label>
            <textarea name="summary" id="summary"></textarea>
            <input class="btn submit" type="submit" value="Create Game">
        </div>
    </form>
</section>
`

export function createView(ctx) {
    ctx.render(createTemplate(onSubmit));

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

        await createGame({title, category, maxLevel, imageUrl, summary});
        ctx.page.redirect(`/home`);
    }
}