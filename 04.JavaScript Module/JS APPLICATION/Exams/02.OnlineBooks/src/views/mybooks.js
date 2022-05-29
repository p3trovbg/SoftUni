import { getUserBooks } from "../api/data.js";
import { getUserId } from "../api/userStorage.js";
import { html, styleMap } from "../library.js";

const mybookTemplate = (books) => html`
    <section id="my-books-page" class="my-books">
        <h1>My Books</h1>
        <!-- Display ul: with list-items for every user's books (if any) -->
        <ul class="my-books-list">
            ${books.map(book => html`
            <li class="otherBooks">
                <h3>${book.title}</h3>
                <p>Type: ${book.type}</p>
                <p class="img"><img src=${book.imageUrl}></p>
                <a class="button" href="${`/details/${book._id}`}">Details</a>
            </li>
            `)}
        </ul>
    
        <!-- Display paragraph: If the user doesn't have his own books  -->
        <p class="no-books" style=${styleMap({display: books.length == 0 ? 'block' : 'none'})}>No books in database!</p>
    </section>
`

export async function myBookView(ctx) {
    let userId = getUserId();
    let books = await getUserBooks(userId);
    ctx.render(mybookTemplate(books));
}