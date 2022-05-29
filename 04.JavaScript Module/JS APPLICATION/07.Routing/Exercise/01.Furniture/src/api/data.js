import * as api from './api.js';

const endPoints = {
    'getAllFurniture': '/data/catalog',
    'getFurnitureById': '/data/catalog/',
    'editFurnitureById': '/data/catalog/',
    'deleteFurnitureById': '/data/catalog/',
    'getOwnerFurnitures': '/data/catalog?where=_ownerId%3D%22{userId}%22',
    'createFurniture': '/data/catalog'
}


export async function getAllFurnitures() {
    return await api.get(endPoints.getAllFurniture);
}

export async function getFurnitureById(id) {
    return await api.get(endPoints.getFurnitureById + id);
}

export async function deleteFurnitureById(id) {
    await api.del(endPoints.deleteFurnitureById + id);
}

export async function createFurniture(furnitureObj) {
    await api.post(endPoints.createFurniture, furnitureObj);
}

export async function editFurniture(furnitureObj, id) {
    await api.put(endPoints.editFurnitureById + id, furnitureObj);
}

export async function getOwnFurnitures(ownerId) {
    return await api.get(endPoints.getOwnerFurnitures.replace('{userId}', ownerId));
}