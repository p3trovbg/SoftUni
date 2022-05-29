import { html, del, editBook } from './app.js';

export function bookTamplate(book, id) {
    return html`
    <tr>
        <td>${book.title}</td>
        <td>${book.author}</td>
        <td>
            <button @click=${()=> editBook(book, id)}>Edit</button>
            <button @click=${()=> del(id)}>Delete</button>
        </td>
    </tr>`
}