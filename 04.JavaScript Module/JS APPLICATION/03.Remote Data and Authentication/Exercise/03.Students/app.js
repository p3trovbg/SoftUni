const url = 'http://localhost:3030/jsonstore/collections/students';
let results = document.querySelector('#results');
let tBodyElement = results.children[1];

window.addEventListener('load', async(e)=> {
    e.preventDefault();
    await getStudents();
    document.getElementById('form').addEventListener('submit', submit);;
})

async function submit(e) {
    e.preventDefault();
    let formData = new FormData(e.target);

    let firstName = formData.get('firstName').trim();
    let lastName = formData.get('lastName').trim();
    let facultyNumber = formData.get('facultyNumber').trim();
    let grade = formData.get('grade').trim();

    if(!firstName || !lastName || !facultyNumber || !grade) {
        alert('You should fill all fields!');
        return;
    }
    const student = {firstName, lastName, facultyNumber, grade};
    e.target.reset();

    try{
        let response = await fetch(url, {
            method: 'post',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(student)
        })

        if(!response.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        await response.json();
        location.reload();
    }
    catch(error) {
        alert(error.message);
    }
}

async function getStudents() {
    try {

        let response = await fetch(url);
        if (response.status !== 200) {
            const error = await response.json();
            throw new Error(error.message);
        }

        let data = await response.json();

        for (const key in data) {
           let currentObj = data[key];
           let trElement = document.createElement('tr');
            trElement.id = key;
           let firstName = document.createElement('td');
           firstName.textContent = currentObj.firstName;

           let lastName = document.createElement('td');
           lastName.textContent = currentObj.lastName;

           let number = document.createElement('td');
           number.textContent = currentObj.facultyNumber;

           let grade = document.createElement('td');
           grade.textContent = currentObj.grade;

           //It is additional functional by me!
           let deleteButton = document.createElement('delete');
           deleteButton.textContent = 'Delete';
           deleteButton.style.color = '#18ADD5';
           deleteButton.className = 'delete';

           trElement.appendChild(firstName);
           trElement.appendChild(lastName);
           trElement.appendChild(number);
           trElement.appendChild(grade);
           trElement.appendChild(deleteButton);

           tBodyElement.appendChild(trElement);
        }

        let buttons = document.querySelectorAll('.delete');
        for (const button of buttons) {
            button.addEventListener('click', async(e) => {
                let id = e.target.parentElement.id;

                try{
                    let response = await fetch(`${url}/` + id, {
                        method: 'delete'
                    });
                    if(!response.ok) {
                        const error = await response.json();
                        throw new Error(error.message);
                    }
                    
                    await response.json();
                    tBodyElement.removeChild(e.target.parentElement);
                }
                catch(error) {
                    alert(error.message);
                }
            })
        }
    }
    catch(error){
        alert(error.message);
    }
}