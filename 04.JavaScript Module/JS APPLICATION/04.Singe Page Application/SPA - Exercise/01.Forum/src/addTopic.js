export async function addTopic(topic) {
    let url = 'http://localhost:3030/jsonstore/collections/myboard/posts';

    try {
        let response = await fetch(url, {
            method: 'post',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(topic)
        })

        if(!response.ok) {
            throw new Error(await response.json().message);
        }
        
    }catch(error){
        alert(error.message);
    }
}