const host = 'http://localhost:3030';
import * as tokenController from './userStorage.js';
async function request(method, url, data) {
    const options = {
        method,
        headers:{}
    };

    if(data != undefined) {
        options.headers['Content-Type'] = 'application/json';
        options.body = JSON.stringify(data);
    }

    const userToken = tokenController.getToken();
    if(userToken != null) {
        let token = JSON.parse(userToken);
        options.headers['X-Authorization'] = token.accessToken;;
    }

    try{
        const response = await fetch(host + url, options);

        if(!response.ok) {
            throw new Error(await response.json().message);
        }

        if(response.status == 204) {
            return response;
        }

        return response.json();

    }
    catch(error){
        alert(error.message);
        throw error.message;
    }
}

const get = request.bind(null, 'GET');
const post = request.bind(null, 'POST');
const put = request.bind(null, 'PUT');
const del = request.bind(null, 'DELETE');

export {
    get, post, put, del
}