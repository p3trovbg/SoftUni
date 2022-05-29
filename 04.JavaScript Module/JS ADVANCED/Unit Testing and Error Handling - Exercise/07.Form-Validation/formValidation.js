function validate() {
    let passwordElement = document.getElementById('password');
    let confirmPassword = document.getElementById('confirm-password');
    let companyTargetElement = document.getElementById('company');
    let companyInfoElement =document.getElementById('companyInfo');
    let submitButton = document.getElementById('submit');
    let validElement = document.getElementById('valid');
    
    submitButton.addEventListener('click', (e) => {
        e.preventDefault();
        let container = document.querySelectorAll('.pairContainer');
        let passwordPattern = /^[\w_]{5,15}$/g;
        let isValid = true;

        for (const element of container) {
            let child = element.children[1];
            if (child.id == "username") {
                let regex = new RegExp('^([A-Za-z0-9]{3,20})$');
                if (!regex.test(child.value)) {
                    child.style.borderColor = "red";
                    isValid = false;
                } else {
                    child.style.border = "none";
                }
            } else if (child.id == "email") {
                let regex = new RegExp('[a-z]+@[a-z]+\.[a-z]+');
                if (!regex.test(child.value)) {
                    child.style.borderColor = "red";
                    isValid = false;
                } else {
                    child.style.border = "none";
                }
            } else if (child.id == "password" || child.id == "confirm-password" ) {
                if (passwordElement.value.match(passwordPattern) && 
                confirmPassword.value.match(passwordPattern) &&
                passwordElement.value == passwordElement.value) {
                    confirmPassword.style.border = "none";
                    passwordElement.style.border = "none";
                    
                } else {
                    confirmPassword.style.borderColor = 'red';
                    passwordElement.style.borderColor = 'red';
                    isValid = false;
                } 
            } 
            if (companyTargetElement.checked && child.id == "companyNumber") {
                    if(child.value < 1000 || child.value > 9999) {
                        child.style.borderColor = "red";
                        isValid = false;
                    } else {
                        child.style.border = "none";
                    }
            }
        }

        if (isValid) {
            validElement.classList = "#valid";
            validElement.style.display = "block";
        } else 
        validElement.style.display = 'none';
    }) 

    companyTargetElement.addEventListener('change', (e) => {
        if (e.target.checked) {
            companyInfoElement.style.display = 'block';
        } else {
            companyInfoElement.style.display = 'none';
        }
    })
}

