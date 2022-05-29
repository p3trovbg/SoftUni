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
            const error = await response.json();
            throw new Error(error.message);
        }

        if(response.status == 204) {
            return response;
        }

        return response.json();

    }
    catch(error){
        throw error;
    }
}

const get = request.bind(null, 'get');
const post = request.bind(null, 'post');
const put = request.bind(null, 'put');
const del = request.bind(null, 'delete');

export {
    get, post, put, del
}


