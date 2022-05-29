export function loginFunc(form) {
    let formData = new FormData(form);

    let email = formData.get('email').trim();
    let password = formData.get('password').trim();

    if(!email || !password) {
        alert('You should fill all fields!')
        return;
    }
    let username = {email, password};
   login(username);
}


async function login(username) {
    const url = 'http://localhost:3030/users/login';
    try{
        let response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(username)
        })
        if(response.ok !== true) {
            throw new Error(await response.json().message);
        }

        let user = await response.json();
        let element = document.querySelector('.info');
        element.textContent = username.email;
        sessionStorage.setItem('authToken', user.accessToken);
        sessionStorage.setItem('ownerId', user._id);
        sessionStorage.setItem('userEmail', user.email);
        window.location = '/index.html';

    }
    catch(error) {
        alert(error.message);
    }
}