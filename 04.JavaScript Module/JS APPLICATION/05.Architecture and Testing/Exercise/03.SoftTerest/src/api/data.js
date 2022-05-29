import * as api from './api.js';

const endPoints = {
    'create': '/data/ideas',
    'getIdeas': '/data/ideas?select=_id%2Ctitle%2Cimg&sortBy=_createdOn%20desc',
    'getIdea': '/data/ideas/',
    'deleteIdea': '/data/ideas/'
}

export async function getAllIdeas() {
    return await api.get(endPoints.getIdeas);
}

export async function createIdeaRequest(idea) {
    return await api.post(endPoints.create, idea);
}

export async function getCurrentIdea(id) {
    return await api.get(endPoints.getIdea + id);
}

export async function removeIdea(id) {
     await api.del(endPoints.deleteIdea + id);
}