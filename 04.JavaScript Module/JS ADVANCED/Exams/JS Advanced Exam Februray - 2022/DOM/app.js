function solve() {
    let firstNameElement = document.getElementById('fname');
    let lastNameElement = document.getElementById('lname');
    let emailElement = document.getElementById('email');
    let birthElement = document.getElementById('birth');
    let positionElement = document.getElementById('position');
    let salaryElement = document.getElementById('salary');
    let addButton = document.getElementById('add-worker');

    let salaryBudget = document.getElementById('sum');

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        if(firstNameElement.value && lastNameElement.value && emailElement.value && birthElement.value && positionElement.value && salaryElement.value) {
            let tableBody = document.querySelector('#tbody');
            let trElement = document.createElement('tr');
            let tdFirstName = document.createElement('td');
            tdFirstName.textContent = firstNameElement.value;

            let tdLastName = document.createElement('td');
            tdLastName.textContent = lastNameElement.value;

            let tdEmail = document.createElement('td');
            tdEmail.textContent = emailElement.value;

            let tdBirth = document.createElement('td');
            tdBirth.textContent = birthElement.value;

            let tdPosition = document.createElement('td');
            tdPosition.textContent = positionElement.value;

            let tdSalary = document.createElement('td');
            tdSalary.textContent = salaryElement.value;

            let tdButtons = document.createElement('td');

            let firedButton = document.createElement('button');
            firedButton.textContent = 'Fired';
            firedButton.className = 'fired';

            let editButton = document.createElement('button');
            editButton.textContent = 'Edit';
            editButton.className = 'edit';

            tdButtons.appendChild(firedButton);
            tdButtons.appendChild(editButton);

            trElement.appendChild(tdFirstName);
            trElement.appendChild(tdLastName);
            trElement.appendChild(tdEmail);
            trElement.appendChild(tdBirth);
            trElement.appendChild(tdPosition);
            trElement.appendChild(tdSalary);
            trElement.appendChild(tdButtons);

            let sum = Number(salaryBudget.textContent);
            sum += Number(tdSalary.textContent);
            salaryBudget.textContent = sum.toFixed(2);

            editButton.addEventListener('click', (e) => {
                let currentTable = e.target.parentElement.parentElement;
                firstNameElement.value = tdFirstName.textContent;
                lastNameElement.value = tdLastName.textContent;
                emailElement.value = tdEmail.textContent;
                birthElement.value = tdBirth.textContent;
                positionElement.value = tdPosition.textContent;
                salaryElement.value = tdSalary.textContent;

                let sum = Number(salaryBudget.textContent);
                sum -= Number(tdSalary.textContent);
                salaryBudget.textContent = sum.toFixed(2);
                tableBody.removeChild(currentTable);     
            })

            firedButton.addEventListener('click', (e) => {
                let currentTable = e.target.parentElement.parentElement;
                let sum = Number(salaryBudget.textContent);
                sum -= Number(tdSalary.textContent);
                salaryBudget.textContent = sum.toFixed(2);
                tableBody.removeChild(currentTable);    
            })

            tableBody.appendChild(trElement);
            firstNameElement.value = '';
            lastNameElement.value = '';
            emailElement.value = '';
            birthElement.value = '';
            positionElement.value = '';
            salaryElement.value = '';
        }
        
    })
}
solve()