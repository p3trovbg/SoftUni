import { createMeme } from "../api/data.js";
import { html } from "../library.js";

const createTemplate = (onSubmit) => html`
<section id="create-meme">
    <form id="create-form" @submit=${onSubmit}>
        <div class="container">
            <h1>Create Meme</h1>
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title">
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description"></textarea>
            <label for="imageUrl">Meme Image</label>
            <input id="imageUrl" type="text" placeholder="Enter meme ImageUrl" name="imageUrl">
            <input type="submit" class="registerbtn button" value="Create Meme">
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
        let description = form.get('description').trim();
        let imageUrl = form.get('imageUrl').trim();

        if(!title || !description || !imageUrl) {
            alert('You should fill all fields!');
            return;
        }

        await createMeme({title, description, imageUrl});
        ctx.page.redirect('/allmemes');
    }
}