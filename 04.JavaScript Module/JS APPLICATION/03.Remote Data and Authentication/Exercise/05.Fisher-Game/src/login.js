window.addEventListener('load', async(e) => {
    e.preventDefault();
    let form = document.querySelector('form');
    form.addEventListener('submit', login);
    
})

async function login(e) {
    e.preventDefault();
    let form = new FormData(e.target);
    let email = form.get('email').trim();
    let password = form.get('password').trim();

    if(!email || !password) {
        alert('You should fill all fields to login!')
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
        window.location = 'http://127.0.0.1:5500/Remote%20Data%20and%20Authentication/Exercise/05.Fisher-Game/src/index.html';
    }
    catch(error) {
        alert(error.message);
    }
}