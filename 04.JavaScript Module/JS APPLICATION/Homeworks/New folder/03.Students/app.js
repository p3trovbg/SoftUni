async function solve(){

    const url = `http://localhost:3030/jsonstore/collections/students`;

    const table = document.querySelector('#results tbody');

    const response = await fetch(url);
    const data = await response.json();

    Object.values(data).forEach(x=>{
        
        const firstName = x.firstName;
        const lastName = x.lastName;
        const facultyNumber = x.facultyNumber;
        const grade = Number(x.grade);

        const tr = document.createElement('tr');
        
        const firstNameCell = tr.insertCell(0);
        firstNameCell.innerText = firstName;
        
        const lastNameCell = tr.insertCell(1);
        lastNameCell.innerText = lastName;
        
        const facultyNumberCell = tr.insertCell(2);
        facultyNumberCell.innerText = facultyNumber;
        
        const gradeCell = tr.insertCell(3);
        gradeCell.innerText = grade;
        
        table.appendChild(tr);
        
    });

    const submitBtn = document.getElementById('submit');
    submitBtn.addEventListener('click', onClickSubmit);

    async function onClickSubmit(ev){
        ev.preventDefault();

        const firstNameInput = document.getElementsByName('firstName')[0];
        const lastNameInput = document.getElementsByName('lastName')[0];
        const facultiNumberInput = document.getElementsByName('facultyNumber')[0];
        const gradeInput = document.getElementsByName('grade')[0];
        
        if(isNaN(facultiNumberInput.value) || isNaN(gradeInput.value )){
            return alert('Wrong input data!');
        }

        if(firstNameInput.value === '' || lastNameInput.value === '' || gradeInput.value === '' || facultiNumberInput.value === ''){
            return alert('Input must be filled!')
        }
        const response = await fetch(url, {
            method: 'POST',
                headers: {'Content-type': 'application/json'},
                body: JSON.stringify({
                    firstName:firstNameInput.value,
                    lastName:lastNameInput.value,
                    facultyNumber:facultiNumberInput.value,
                    grade:gradeInput.value
                })
        });

        const tr = document.createElement('tr');

        const firstNameCell = tr.insertCell(0);
        firstNameCell.innerText = firstNameInput.value;
        
        const lastNameCell = tr.insertCell(1);
        lastNameCell.innerText = lastNameInput.value;
        
        const facultyNumberCell = tr.insertCell(2);
        facultyNumberCell.innerText = facultiNumberInput.value;
        
        const gradeCell = tr.insertCell(3);
        gradeCell.innerText = gradeInput.value;

        table.appendChild(tr);

        firstNameInput.value = '';
        lastNameInput.value = '';
        facultiNumberInput.value = '';
        gradeInput.value = '';

    }


}
solve();