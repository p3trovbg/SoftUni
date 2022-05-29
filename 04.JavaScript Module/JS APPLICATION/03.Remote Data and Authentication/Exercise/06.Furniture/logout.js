window.addEventListener('load', async(e) => {
    e.preventDefault();
    document.querySelector('#logoutBtn').addEventListener('click', logout);
})


async function logout() {
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
        window.location = '/06.Furniture/home.html';
    }
    catch(error) {
        alert(error.message);
    }
}