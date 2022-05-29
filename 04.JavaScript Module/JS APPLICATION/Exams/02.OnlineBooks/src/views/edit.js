import { getBookById, updateBookById } from "../api/data.js";
import { html, styleMap } from "../library.js";

const editTemplate = (book, onEdit) => html`
 <section id="edit-page" class="edit">
            <form id="edit-form" @submit=${onEdit}>
                <fieldset>
                    <legend>Edit my Book</legend>
                    <p class="field">
                        <label for="title">Title</label>
                        <span class="input">
                            <input type="text" name="title" id="title" .value=${book.title}>
                        </span>
                    </p>
                    <p class="field">
                        <label for="description">Description</label>
                        <span class="input">
                            <textarea name="description"
                                id="description">${book.description}</textarea>
                        </span>
                    </p>
                    <p class="field">
                        <label for="image">Image</label>
                        <span class="input">
                            <input type="text" name="imageUrl" id="image" .value=${book.imageUrl}>
                        </span>
                    </p>
                    <p class="field">
                        <label for="type">Type</label>
                        <span class="input">
                            <select id="type" name="type" .value=${book.type}>
                                <option value="Fiction" selected>Fiction</option>
                                <option value="Romance">Romance</option>
                                <option value="Mistery">Mistery</option>
                                <option value="Classic">Clasic</option>
                                <option value="Other">Other</option>
                            </select>
                        </span>
                    </p>
                    <input class="button submit" type="submit" value="Save">
                </fieldset>
            </form>
        </section>
`

export async function editView(ctx) {
    let book = await getBookById(ctx.params.id);
    ctx.render(editTemplate(book, onEdit));

    async function onEdit(e){
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

        await updateBookById(book._id, {title, description, imageUrl, type});
        ctx.page.redirect(`/details/${book._id}`);
    }
}