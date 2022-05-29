window.addEventListener('load', async() => [

    document.querySelector('form').addEventListener('submit', register)
])

async function register(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let email = formData.get('email').trim();
    let password = formData.get('password').trim();
    let rePass = formData.get('rePass').trim();

    try{
        const url = `http://localhost:3030/users/register`;
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email, password, rePass})
        })

        if(!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        let username = await response.json();
        let token = username.accessToken;
        sessionStorage.setItem('token', token);

        window.location = '/login.html';
    }
    catch(error)
    {
        alert(error.message);
    }
}