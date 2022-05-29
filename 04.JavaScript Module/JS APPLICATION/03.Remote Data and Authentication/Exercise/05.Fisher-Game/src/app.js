let catches = document.querySelector('#main');
window.addEventListener('load', async(e) => {
    e.preventDefault();
    let token = sessionStorage.getItem('token');
    let userToken = sessionStorage.getItem('userId');
    let addButton = document.querySelector('#addForm button');
    let loadButton = document.querySelector('.load');

    let loginButton = document.querySelector('#login');
    let logoutButton = document.querySelector('#logout');
    let registerButton = document.querySelector('#register');

    loadButton.addEventListener('click', loadCatches);

    if(token == null || userToken == null) {
        catches.style.display = 'none';
        logoutButton.style.display = 'none';
    } else {
        logoutButton.style.display = 'block';
        loginButton.style.display = 'none';
        registerButton.style.display = 'none';

        addButton.disabled = false;
        addButton.addEventListener('click', createRequest);
    }
})


async function loadCatches(e) {
    let catchesElement = document.getElementById('catches');
    catchesElement.innerHTML = '';
    let url = 'http://localhost:3030/data/catches';
    try {
        let response = await fetch(url);
        if (response.status !== 200) {
            let error = await response.json();
            throw new Error(error.message);
        }

        let data = await response.json();

        for (const key in data) {
            let currentObj = data[key];
            createCatch(currentObj, currentObj._id, currentObj._ownerId);
        }
        catches.style.display = 'inline-block';
    }
    catch(error){
        alert(error.message);
    }
}

async function createRequest(e) {
    e.preventDefault();
    let addForm = document.querySelector('#addForm');
    let form = new FormData(addForm);

    let angler = form.get('angler').trim();
    let weight = form.get('weight').trim();
    let species = form.get('species').trim();
    let location = form.get('location').trim();
    let bait = form.get('bait').trim();
    let captureTime = form.get('captureTime').trim();
    
    if(!angler || !weight || !species || !location || !bait || !captureTime) {
        alert('You should fill all fields!');
        return;
    }
    let currentCatch = { angler, weight, species, location, bait, captureTime };
    addForm.reset();

    try{
        const url = 'http://localhost:3030/data/catches/'
        let response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': sessionStorage.getItem('token')
            }
            ,body: JSON.stringify(currentCatch)
        })

        if(!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        await response.json();
    }
    catch(error) {
        alert(error.message);
    }
}

async function createCatch(catchObj, id, ownerId) {
    let userId = sessionStorage.getItem('userId');
    let isDisabled = userId == ownerId ? false : true;
    let catchesElement = document.getElementById('catches');
    let catchDiv = createElement('div', undefined, undefined, 'catch', undefined, catchesElement);
    catchDiv.id = id;

    createElement('label', 'Angler', undefined, undefined, undefined, catchDiv);
    createElement('input', undefined, 'text', 'angler', catchObj.angler, catchDiv, isDisabled);

    createElement('label', 'Weight', undefined, undefined, undefined, catchDiv);
    createElement('input', undefined, 'text', 'weight', catchObj.weight, catchDiv, isDisabled);

    createElement('label', 'Species', undefined, undefined, undefined, catchDiv);
    createElement('input', undefined, 'text', 'species', catchObj.species, catchDiv, isDisabled);

    createElement('label', 'Location', undefined, undefined, undefined, catchDiv);
    createElement('input', undefined, 'text', 'location', catchObj.location, catchDiv, isDisabled);

    createElement('label', 'Bait', undefined, undefined, undefined, catchDiv);
    createElement('input', undefined, 'text', 'bait', catchObj.bait, catchDiv, isDisabled);
    
    createElement('label', 'Capture Time', undefined, undefined, undefined, catchDiv);
    createElement('input', undefined, 'number', 'captureTime', catchObj.captureTime, catchDiv, isDisabled);

    let updateButton = createElement('button', 'Update', undefined, 'update', undefined, catchDiv, isDisabled);
    updateButton.setAttribute('data-id', ownerId);
    let deleteButton = createElement('button', 'Delete', undefined, 'delete', undefined, catchDiv, isDisabled);
    deleteButton.setAttribute('data-id', ownerId);

    updateButton.addEventListener('click', updateCatch);
    deleteButton.addEventListener('click', deleteCatch);
}


async function updateCatch(e) {
    let parent = e.target.parentElement;
    let id = parent.id;
    let angler = parent.children[1].value;
    let weight = parent.children[3].value;
    let species = parent.children[5].value;
    let location = parent.children[7].value;
    let bait = parent.children[9].value;
    let captureTime = Number(parent.children[11].value);

    const updateCatch = {angler, weight, species, location, bait, captureTime};
    let token = sessionStorage.getItem('token');
    let url = `http://localhost:3030/data/catches/` + id; 
     try{
        let response = await fetch(url, {
            method: 'put',
            headers: {
                'X-Authorization': token,
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(updateCatch)
        })

        if(!response.ok) {
            throw new Error(`${await response.json().message}`);
        }
        await response.json();
     }
     catch(error){
         alert(error.message);
     }
    
}


async function deleteCatch(e) {
    let id = e.target.parentElement.id;
    let url = `http://localhost:3030/data/catches/` + id; 
     try{
        let response = await fetch(url, {
            method: 'delete',
            headers: {
                'X-Authorization': sessionStorage.getItem('token')
            }
        })
        e.target.parentElement.remove();

        await response.json();
     }
     catch(error){
         alert(error.message);
     }

}


function createElement(element, textCon, type, className, value, parent, disable) {
    let domElement = document.createElement(element);

    if (textCon) {
        domElement.textContent = textCon;
    }
    if (type) {
        domElement.type = type;
    }
    if (className) {
        domElement.className = className;
    }
    if (value) {
        domElement.value = value;
    }
    if (parent) {
        parent.appendChild(domElement);
    }
    if(disable) {
        domElement.disabled = true;
    }
    return domElement;
}