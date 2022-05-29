window.addEventListener('load', async(e) => {
    e.preventDefault();
    let form = document.querySelector('form');
    form.addEventListener('submit', register);
})

async function register(e) {
    e.preventDefault();
    let form = new FormData(e.target);

    let email = form.get('email').trim();
    let password = form.get('password').trim();
    let rePass = form.get('rePass').trim();
    
    if(!email || !password || !rePass) {
        alert('You should fill all fields to register!')
        return;
    }

    const url = 'http://localhost:3030/users/register';
    try{
        const response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify({email, password, rePass})
        })
        if(response.ok != true) {
            let error = await response.json();
            throw new Error(error.message);
        }
        
        let username = await response.json();

        let token = username.accessToken;
        sessionStorage.setItem('token', token);

        window.location = 'http://127.0.0.1:5500/Remote%20Data%20and%20Authentication/Exercise/05.Fisher-Game/src/index.html';
    }
    catch(error){
        alert(error.message)
    }
}