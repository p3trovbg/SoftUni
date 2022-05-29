import * as api from './api.js';

const endPoints = {
    'getAllMemes': '/data/memes?sortBy=_createdOn%20desc',
    'createMeme': '/data/memes',
    'getMemeById': '/data/memes/',
    'deleteMemeById': '/data/memes/',
    'editMemeById': '/data/memes/',
    'getUserMemes': (userId) => `/data/memes?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`
}


export async function getAllMemes() {
    return await api.get(endPoints.getAllMemes);
}


export async function createMeme(meme) {
    return await api.post(endPoints.createMeme, meme);
}

export async function getMemeById(id) {
    return await api.get(endPoints.getMemeById + id);
}

export async function deleteMemeById(id) {
    await api.del(endPoints.deleteMemeById + id);
}

export async function editMemeById(id, meme) {
    await api.put(endPoints.editMemeById + id, meme);
}

export async function getUserMemes(userId) {
   return await api.get(endPoints.getUserMemes(userId));
}