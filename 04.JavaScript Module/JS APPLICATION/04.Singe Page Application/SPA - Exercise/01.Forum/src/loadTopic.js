import { createTopic } from './appendElement.js';

export async function loadTopic() {
    let url = `http://localhost:3030/jsonstore/collections/myboard/posts`;

    try{
        let response = await fetch(url);
        if (response.status !== 200) {
            throw new Error(await response.json().message);
        }
        let data = await response.json();
        for (const key in data) {
            let topic = data[key];
            createTopic(topic);
        }
    }
    catch(error){
        await(error.message);
    }
}