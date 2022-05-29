import { getBooks } from "../api/data.js";
import { html, styleMap } from "../library.js";

const dashboardTemplate = (books) => html`
<section id="dashboard-page" class="dashboard">
    <h1>Dashboard</h1>
    <!-- Display ul: with list-items for All books (If any) -->
    <ul class="other-books-list">
        ${books.map(book => html`
        <li class="otherBooks">
            <h3>${book.title}</h3>
            <p>Type: ${book.type}</p>
            <p class="img"><img src=${book.imageUrl}></p>
            <a class="button" href="${`/details/${book._id}`}">Details</a>
        </li>
        `)}
    </ul>
    <!-- Display paragraph: If there are no books in the database -->
    <p class="no-books" style=${styleMap({display: books.length == 0 ? 'block' : 'none'})}>No books in database!</p>
</section>
`

export async function dashboardView(ctx) {
    let books = await getBooks();

    ctx.render(dashboardTemplate(books));
    ctx.updateNav();
}