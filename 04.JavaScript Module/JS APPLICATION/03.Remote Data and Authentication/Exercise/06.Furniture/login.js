window.addEventListener('load', async(e) => {
    let token = sessionStorage.getItem('token');
    if(token) {
        alert('You already login!')
        window.location = '/06.Furniture/homeLogged.html';
    } 

    document.querySelector('#login').addEventListener('submit', login);
    document.querySelector('#register').addEventListener('submit', register);
})



async function login(e) {
    e.preventDefault();
    let form = new FormData(e.target);
    let email = form.get('email').trim();
    let password = form.get('password').trim();

    if(!email || !password) {
        alert('You must fill all fields!')
        return;
    }

    const url = `http://localhost:3030/users/login`;
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
        
        sessionStorage.setItem('userId', data._id);
        sessionStorage.setItem('token', data.accessToken);
        window.location = '/06.Furniture/homeLogged.html';
    }
    catch(error) {
        alert(error.message);
    }
}

async function register(e) {
    e.preventDefault();
    let form = new FormData(e.target);
    let email = form.get('email').trim();
    let password = form.get('password').trim();
    let repeat = form.get('rePass').trim();

    if(!email || !password || !repeat) {
        alert('You must fill all fields!')
        return;
    }

    try{
        let url = `http://localhost:3030/users/register`;
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email, password, repeat})
        })
        if(response.ok != true) {
            let error = await response.json();
            throw new Error(error.message);
        }
        
        let username = await response.json();

        let token = username.accessToken;
        sessionStorage.setItem('token', token);
        sessionStorage.setItem('userId', data._id);

        window.location = '/06.Furniture/homeLogged.html';
    }
    catch(error){
        alert(error.message);
    }

}