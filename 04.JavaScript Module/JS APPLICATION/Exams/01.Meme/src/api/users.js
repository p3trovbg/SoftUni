import * as api from './api.js';
import * as tokenController from './userStorage.js';
const endPoints = {
    'register': '/users/register',
    'login': '/users/login',
    'logout': '/users/logout'
}

export async function register(username, email, password, gender) {
    const user = await api.post(endPoints.register, {username, email, password, gender});
    tokenController.setToken(user);
}

export async function login(email, password) {
    const user = await api.post(endPoints.login, {email, password});
    tokenController.setToken(user);
}

export async function logout() {
    api.get(endPoints.logout);
   tokenController.removeToken();
}