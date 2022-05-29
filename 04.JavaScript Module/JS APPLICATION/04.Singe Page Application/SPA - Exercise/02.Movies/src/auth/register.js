export function registerFunc(form) {
    let formData = new FormData(form);

    let email = formData.get('email').trim();
    let password = formData.get('password').trim();
    let rePass = formData.get('repeatPassword').trim();

    if(!email || !password || !rePass) {
        alert('You should fill all fields!');
        return;
    } else if(password.length < 6) {
        alert('You should have password at least 6 symbols')
        return;
    } else if(password !== rePass) {
        alert('You should have same fields about password');
        return;
    }

    let username = {email, password, rePass};
    register(username);
}



async function register(username) {
    const url = 'http://localhost:3030/users/register';
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
        sessionStorage.setItem('authToken', user.accessToken);
        sessionStorage.setItem('ownerId', user._id);
        sessionStorage.setItem('userEmail', user.email);
        
        window.location = '/index.html';

    }
    catch(error) {
        alert(error.message);
    }
}