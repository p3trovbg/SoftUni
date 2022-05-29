export function logout() {
     logoutRequest();
}


async function logoutRequest() {
    const url = 'http://localhost:3030/users/logout';
    let token = sessionStorage.getItem('authToken');
    if (!token) {
        sessionStorage.clear();
    }

    try{
        let response = await fetch(url, {
            method: 'get',
            headers: {
                'X-Authorization': token
            }
        })

        if(response.ok !== true) {
            throw new Error(await response.json().message);
        }

        sessionStorage.clear();
        window.location = '/index.html';
    }
    catch(error){
        alert(error.message);
    }
}