import { render, html, until } from '../dom.js';
import { getCommentsByRecipeId, createComment, deleteCommentById } from '../api/data.js';


const commentsTemplate = (recipe, commentForm, comments) => html`
<div class="section-title">
    Comments for ${recipe.name}
</div>
${commentForm}
<div class="comments">
    ${until((async () => commentsList(await comments))(), 'Loading comments...')}
</div>`;

const commentFormTemplate = (active, toggleForm, onSubmit) => html`
<article class="new-comment">
    ${active
        ? html`
    <h2>New comment</h2>
    <form id="commentForm" @submit=${onSubmit}>
        <textarea name="content" placeholder="Type comment"></textarea>
        <input type="submit" value="Add comment">
    </form>`
        : html`<form><button class="button" @click=${toggleForm}>Add comment</button></form>`}
</article>`;

const commentsList = (comments) => html`
<ul>
    ${comments.map(comment)}
</ul>`;

const comment = (data) => html`
<li class="comment" id ="${data._id}">
    <header>${data.author.email}</header>
    <p>${data.content}</p>
    <span>
        <a class="commentEditBtn" href="${`/comment/edit/${data._id}`}">Edit comment</a>
        <a class="commentDeleteBtn" href="${`/comment/delete/${data._id}`}">Delete comment</a>
    </span>
</li>`;

let originalRecipe;
export function showComments(recipe) {
    originalRecipe = recipe
    const recipeId = recipe._id;
    let formActive = false;
    const commentsPromise = getCommentsByRecipeId(recipeId);
    const result = document.createElement('div');
    renderTemplate(commentsPromise);

    return result;

    function renderTemplate(comments) {
        render(commentsTemplate(recipe, createForm(formActive, toggleForm, onSubmit), comments), result);
    }

    function toggleForm() {
        formActive = !formActive;
        renderTemplate(commentsPromise);
    }

    async function onSubmit(event) {
        event.preventDefault();
        const data = new FormData(event.target);

        toggleForm();
        const comments = await commentsPromise;

        const comment = {
            content: data.get('content'),
            recipeId
        };
        console.log(comment);

        const result = await createComment(comment);

        comments.unshift(result);
        renderTemplate(comments);
    }
}

function createForm(formActive, toggleForm, onSubmit) {
    const userId = sessionStorage.getItem('userId');
    if (userId == null) {
        return '';
    } else {
        return commentFormTemplate(formActive, toggleForm, onSubmit);
    }
}


export async function deleteComment(ctx) {
    let commentId = ctx.params.id;
    console.log(ctx);
    await deleteCommentById(commentId);
    document.getElementById(commentId).remove();
} 

export async function editComment(ctx) {
    let commentId = ctx.params.id;
    console.log(ctx);
    await deleteCommentById(commentId);
    document.getElementById(commentId).remove();
} 