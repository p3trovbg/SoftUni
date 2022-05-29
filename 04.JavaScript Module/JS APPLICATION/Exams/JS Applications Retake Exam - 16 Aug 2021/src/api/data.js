import * as api from './api.js';

const endPoints = {
    'getLatestGames': '/data/games?sortBy=_createdOn%20desc&distinct=category',
    'getAllGames': '/data/games?sortBy=_createdOn%20desc',
    'getGameDetails': '/data/games/',
    'getGameById': '/data/games/',
    'updateGameDetails': '/data/games/',
    'createGame': '/data/games',
    'getComments': (gameId) => `/data/comments?where=gameId%3D%22${gameId}%22`,
    'createComment': '/data/comments'
}


export async function getLatestGames() {
    return await api.get(endPoints.getLatestGames);
}

export async function getGameDetails(gameId) {
    return await api.get(endPoints.getGameDetails + gameId);
}

export async function getAllGames() {
    return await api.get(endPoints.getAllGames);
}

export async function updateGame(gameId, game) {
    await api.put(endPoints.updateGameDetails + gameId, game)
}

export async function createGame(game) {
    return await api.post(endPoints.createGame, game);
}

export async function getComments(gameId) {
    return await api.get(endPoints.getComments(gameId));
}

export async function createComment(comment) {
    await api.post(endPoints.createComment, comment);
}

export async function deleteGameById(gameId) {
    await api.del(endPoints.getGameById + gameId);
}