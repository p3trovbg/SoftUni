window.addEventListener('load', (e) => {
    e.preventDefault();
    let form = document.querySelector('#form');
    let token = sessionStorage.getItem('token');
    if(token == null) {
        window.location = '/login.html';
        return;
    }
    form.addEventListener('submit', create);
})

async function create(e) {
    let formData = new FormData(e.target);
    let name = formData.get('name').trim();
    let img = formData.get('img').trim();
    let ingredients = formData.get('ingredients').trim().split('\n');
    let steps = formData.get('steps').trim().split('\n');;

    let token = sessionStorage.getItem('token');
    try {
        const url = `http://localhost:3030/data/recipes`;
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            },
            body: JSON.stringify({name, img, ingredients, steps})
        })

        if(!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        window.location = '/index.html';
        await response.json();

    }
    catch(error) {
        alert(error.message);
    }
}
