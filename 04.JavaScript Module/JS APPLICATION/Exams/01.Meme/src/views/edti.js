import { editMemeById, getMemeById } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html } from "../library.js";

const editTemplate = (onEdit, meme) => html`
<section id="edit-meme">
    <form id="edit-form" @submit=${onEdit}>
        <h1>Edit Meme</h1>
        <div class="container">
            <label for="title">Title</label>
            <input id="title" type="text" placeholder="Enter Title" name="title" .value=${meme.title}>
            <label for="description">Description</label>
            <textarea id="description" placeholder="Enter Description" name="description">${meme.description}</textarea>
            <label for="imageUrl">Image Url</label>
            <input id="imageUrl" type="text" placeholder="Enter Meme ImageUrl" name="imageUrl" .value=${meme.imageUrl}>
            <input type="submit" class="registerbtn button" value="Edit Meme">
        </div>
    </form>
</section>
`

export async function editView(ctx) {
    let meme = await getMemeById(ctx.params.id);
    ctx.render(editTemplate(onEdit, meme));   

    async function onEdit(e) {
        e.preventDefault();

    
        
        let form = new FormData(e.target);

        let title = form.get('title').trim();
        let description = form.get('description').trim();
        let imageUrl = form.get('imageUrl').trim();
        if(!title || !description || !imageUrl) {
            alert('You should fill all fields!');
            return;
        }

        await editMemeById(ctx.params.id, {title, description, imageUrl});
        ctx.page.redirect(`/details/${ctx.params.id}`);
    }
}