window.addEventListener('load', solution);

function solution() {
  let nameElement = document.getElementById('fname');
  let emailElement = document.getElementById('email');
  let phoneElement = document.getElementById('phone');
  let addressElement = document.getElementById('address');
  let postalCodeElement = document.getElementById('code');
  let submitButton = document.getElementById('submitBTN');
 
  let divActionsElement = document.querySelector('.actions');
  let editButton = divActionsElement.children[0];
  let continueButton = divActionsElement.children[1];

  let blockElement = document.querySelector('#block');

  let ulElement = document.getElementById('infoPreview');
  let initialValues = [];
  submitButton.addEventListener('click', (e) => {
    e.preventDefault();
    if(nameElement.value && emailElement.value) {
      e.target.disabled = true;
      let liFullNameElement = document.createElement('li');
      liFullNameElement.textContent = `Full Name: ${nameElement.value}`;
      initialValues.push(nameElement.value);

      let liEmailElement = document.createElement('li');
      liEmailElement.textContent = `Email: ${emailElement.value}`;
      initialValues.push(emailElement.value);

      let liPhoneNumber = document.createElement('li');
      liPhoneNumber.textContent = `Phone Number: ${phoneElement.value}`
      initialValues.push(phoneElement.value);

      let liAddress = document.createElement('li');
      liAddress.textContent = `Address: ${addressElement.value}`;
      initialValues.push(addressElement.value);

      let liPostalCode = document.createElement('li');
      liPostalCode.textContent = `Postal Code: ${postalCodeElement.value}`;
      initialValues.push(postalCodeElement.value);

      editButton.disabled = false;
      continueButton.disabled = false;

      ulElement.appendChild(liFullNameElement);
      ulElement.appendChild(liEmailElement);
      ulElement.appendChild(liPhoneNumber);
      ulElement.appendChild(liAddress);
      ulElement.appendChild(liPostalCode);

      nameElement.value = '';
      emailElement.value = '';
      phoneElement.value = '';
      addressElement.value = '';
      postalCodeElement.value = '';

      editButton.addEventListener('click', (e) => {
        submitButton.disabled = false;
        editButton.disabled = true;
        continueButton.disabled = true;
        
        nameElement.value = initialValues.shift();
        emailElement.value = initialValues.shift();
        phoneElement.value = initialValues.shift();
        addressElement.value = initialValues.shift();
        postalCodeElement.value = initialValues.shift();
    
        Array.from(ulElement.children).forEach(x => {
          ulElement.removeChild(x);
        })
      })
      
      continueButton.addEventListener('click', (e) => {
        Array.from(blockElement.children).forEach(x => {
          blockElement.removeChild(x);
        })
    
        let h3Element = document.createElement('h3');
        h3Element.textContent = 'Thank You For Your Reservation!';
        blockElement.appendChild(h3Element);
      })
    }
  })
}
