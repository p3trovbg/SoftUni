import { addBook } from "../api/data.js";
import { html, styleMap } from "../library.js";

const createTemplate = (onSubmit) => html`
<section id="create-page" class="create">
    <form id="create-form" @submit=${onSubmit}>
        <fieldset>
            <legend>Add new Book</legend>
            <p class="field">
                <label for="title">Title</label>
                <span class="input">
                    <input type="text" name="title" id="title" placeholder="Title">
                </span>
            </p>
            <p class="field">
                <label for="description">Description</label>
                <span class="input">
                    <textarea name="description" id="description" placeholder="Description"></textarea>
                </span>
            </p>
            <p class="field">
                <label for="image">Image</label>
                <span class="input">
                    <input type="text" name="imageUrl" id="image" placeholder="Image">
                </span>
            </p>
            <p class="field">
                <label for="type">Type</label>
                <span class="input">
                    <select id="type" name="type">
                        <option value="Fiction">Fiction</option>
                        <option value="Romance">Romance</option>
                        <option value="Mistery">Mistery</option>
                        <option value="Classic">Clasic</option>
                        <option value="Other">Other</option>
                    </select>
                </span>
            </p>
            <input class="button submit" type="submit" value="Add Book">
        </fieldset>
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
        let type = form.get('type');

        if(!title || !description || !imageUrl || !type) {
            alert('You should fill all fields!');
            return;
        }
        
        await addBook({title, description, imageUrl, type});
        ctx.page.redirect('/dashboard');
    }
}