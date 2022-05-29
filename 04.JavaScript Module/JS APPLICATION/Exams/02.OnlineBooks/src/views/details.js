import { deleteBookById, getBookById, getBookLikes, isLikeByUser, likeBookById } from "../api/data.js";
import { getToken, getUserId } from "../api/userStorage.js";
import { html, styleMap } from "../library.js";

const detailsTemplate = (book, isOwner, isUser, like, isLike, likes) => html`
 <section id="details-page" class="details">
            <div class="book-information">
                <h3>${book.title}</h3>
                <p class="type">Type: ${book.type}</p>
                <p class="img"><img src=${book.imageUrl}></p>
                <div class="actions">
                    <!-- Edit/Delete buttons ( Only for creator of this book )  -->
                    <a class="button" href="${`/edit/${book._id}`}" style=${styleMap({display: isOwner ? 'block' : 'none'})}>Edit</a>
                    <a class="button" href="${`/delete/${book._id}`}" style=${styleMap({display: isOwner ? 'block' : 'none'})}>Delete</a>

                    <!-- Bonus -->
                    <!-- Like button ( Only for logged-in users, which is not creators of the current book ) -->
                    <a class="button" @click=${(e) => like(e)} href="/like" style=${styleMap({display: isOwner || !isUser || isLike == 1 ? 'none' : 'block'})}>Like</a>

                    <!-- ( for Guests and Users )  -->
                    <div class="likes">
                        <img class="hearts" src="/images/heart.png">
                        <span id="total-likes">Likes: ${likes}</span>
                    </div>
                    <!-- Bonus -->
                </div>
            </div>
            <div class="book-description">
                <h3>Description:</h3>
                <p>${book.description}</p>
            </div>
        </section>
`

export async function detailsView(ctx) {
    let bookId = ctx.params.id;
    let isOwner;
    let book = await getBookById(bookId);
    let userId = getUserId();
    isOwner = userId == book._ownerId ? true : false;

    let bookLikes = await getBookLikes(bookId);
    let isLike = await isLikeByUser(bookId, userId);

    ctx.render(detailsTemplate(book, isOwner, userId, likeBook, isLike, bookLikes));

    async function likeBook(e) {
        e.preventDefault();
        e.target.remove();
        let totalLikes = document.querySelector('#total-likes');
        let likes = totalLikes.textContent.split(': ')[1];
        likes++;
        totalLikes.textContent = `Likes: ${likes}`;

        await likeBookById({bookId});
    }
}

export async function deleteBook(ctx) {
    let bookId = ctx.params.id;
    await deleteBookById(bookId);
    ctx.page.redirect('/dashboard');
}

