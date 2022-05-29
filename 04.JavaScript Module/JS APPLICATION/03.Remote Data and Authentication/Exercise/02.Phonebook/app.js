function attachEvents() {
    let createButton = document.querySelector('#btnCreate');
    let loadButton = document.querySelector('#btnLoad');
    let phonebook = document.querySelector('#phonebook');

    let personInput = document.querySelector('#person');
    let phoneInput = document.querySelector('#phone');
    
    const url = `http://localhost:3030/jsonstore/phonebook`;
    createButton.addEventListener('click', create);
    loadButton.addEventListener('click', load);
    async function create(e) {
        let person = personInput.value.trim();
        let phone = phoneInput.value.trim();

        if(!person || !phone) {
            alert('Fill all fields!');
        }
        let obj = {person, phone};
        personInput.value = '';
        phoneInput.value = '';
        try {
            const response = await fetch(url, {
                method: 'post',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(obj)
            })

            if (response.ok !== true) {
                const error = await response.json();
                throw new Error(error.message);
            }

            await response.json();
        }
        catch(error) {
            alert(error.message);
        }
    }

    async function load(e) {

        try {
            let data = await getPhoneBook();
            phonebook.replaceChildren();
            
            for (const key in data) {
                let currnetPerson = data[key];
                let liElement = document.createElement('a');
                liElement.id = key;
                liElement.textContent = `${currnetPerson.person}: ${currnetPerson.phone}`;
                let deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';
                deleteButton.className = 'delete';
                liElement.appendChild(deleteButton);
                phonebook.appendChild(liElement);
            }

            let buttons = document.querySelectorAll('.delete');
            for (const button of buttons) {
                button.addEventListener('click', deletePhone);
            }
        }
        catch(error){
            alert(error.message);
        }
    }

    async function deletePhone(e) {
        try {
            const id = e.target.parentElement.id;
            let response = await fetch(`${url}/`+ id, {
                method: 'delete'
            })
            if (response.ok !== true) {
                const error = await response.json();
                throw new Error(error.message);
            }

            phonebook.removeChild(e.target.parentElement);
        }
        catch(error) {
            alert(error.message);  
        }
    }

    async function getPhoneBook() {
        let response = await fetch(url);
        if (response.status !== 200) {
            const error = await response.json();
            throw new Error(error.message);
        } 
        let data = await response.json();
        return data;
    }
}

attachEvents();