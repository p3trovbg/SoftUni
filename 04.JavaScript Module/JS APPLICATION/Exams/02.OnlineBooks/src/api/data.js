import * as api from './api.js';

const endPoints = {
    'getBooks': '/data/books?sortBy=_createdOn%20desc',
    'getBookById': '/data/books/',
    'addBook': '/data/books',
    'deleteBook': '/data/books/',
    'updateBook': '/data/books/',
    'userBooks': (userId) => `/data/books?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`,
    'totalBookLikes': (bookId) => `/data/likes?where=bookId%3D%22${bookId}%22&distinct=_ownerId&count`,
    'isLike': (bookId, userId) => `/data/likes?where=bookId%3D%22${bookId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
    'likeBook': `/data/likes`
}


export async function getBooks() {
    return await api.get(endPoints.getBooks);
}

export async function addBook(book) {
    await api.post(endPoints.addBook, book);
}

export async function getBookById(bookId) {
    return await api.get(endPoints.getBookById + bookId);
}

export async function deleteBookById(bookId) {
    await api.del(endPoints.deleteBook + bookId);
}

export async function updateBookById(bookId, book) {
    await api.put(endPoints.updateBook + bookId, book);
}

export async function getUserBooks(userId) {
    return await api.get(endPoints.userBooks(userId));
}

//Like requests
export async function getBookLikes(bookId) {
    return await api.get(endPoints.totalBookLikes(bookId));
}

export async function likeBookById(bookId) {
     await api.post(endPoints.likeBook, bookId); //bookId in obj
}

export async function isLikeByUser(bookId, userId) {
    return await api.get(endPoints.isLike(bookId, userId));
}