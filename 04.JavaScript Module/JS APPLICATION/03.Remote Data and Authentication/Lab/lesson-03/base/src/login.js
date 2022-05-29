window.addEventListener('load', async() => {
    const form = document.querySelector('form');
    form.addEventListener('submit', inLogin);
});

async function inLogin(e) {
    const url = (`http://localhost:3030/users/login`);
    e.preventDefault();
    const currForm = e.target;
    const formData = new FormData(currForm);
    let email = formData.get('email').trim();
    let password = formData.get('password').trim();

    try{
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email, password})
        });

        if(response.ok != true) {
            let error = await response.json();
            throw new Error(error.message);
        }

        let data = await response.json();
        const token = data.accessToken;
        
        sessionStorage.setItem('token', token);
        window.location = '/index.html';
    }
    catch(error) {
        alert(error.message);
    }
}

