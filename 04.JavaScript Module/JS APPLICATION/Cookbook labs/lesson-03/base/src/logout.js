async function logout() {
    try{
        const token = sessionStorage.getItem('token');
        const response = await fetch('http://localhost:3030/users/logout', {
        method: 'get',
        headers: {
            'X-Authorization': token
        },
    });
    
        if(response.status !== 200) {
            let error = await response.json();
            throw new Error(error.message);
        }

        localStorage.removeItem('token');
        window.location = '/Labs/lesson-03/base/index.html';
    }
    catch(error) {
        alert(error.message);
    } 
}

logout();