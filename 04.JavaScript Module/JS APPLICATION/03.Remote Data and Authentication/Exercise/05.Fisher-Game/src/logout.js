window.addEventListener('load', async(e) => {
    e.preventDefault();
    document.querySelector('#logout').addEventListener('click', logout);
})


async function logout(e) {
    const url = `http://localhost:3030/users/logout`;
    let token = sessionStorage.getItem('token');
    try{
        let response = await fetch(url, {
            method: 'get',
            headers: {
                'X-Authorization': token
            }
        })
        
        if(response.status !== 204) {
            throw new Error(`${await response.json().message}`);
        } 

        sessionStorage.removeItem('token');
        sessionStorage.removeItem('userId');
        window.location = 'http://127.0.0.1:5500/Remote%20Data%20and%20Authentication/Exercise/05.Fisher-Game/src/index.html';
    }
    catch(error) {
        alert(error.message);
    }
}