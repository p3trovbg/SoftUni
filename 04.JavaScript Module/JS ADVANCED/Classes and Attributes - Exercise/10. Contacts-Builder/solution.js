
class Contact {
    constructor(firstName, lastName, phone, email) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.phone = phone;
        this.email = email;
        this.online = false;
        this.divTitle = '';

    }
    get status() {
        return this.online;
    }
    set status(value) {
        this.online = value;

        if (this.divTitle && value === false) {
            this.divTitle.classList.remove('online');
        } else {
            this.divTitle.classList.add('online');
        }
    }


    render(id) {
        let childrenElement = document.getElementById(id);
        let articleElement = document.createElement('article');
        this.divTitle = document.createElement('div');
        this.divTitle.classList.add('title');
        this.divTitle.textContent = `${this.firstName} ${this.lastName}`;
        
        let button = document.createElement('button');
        button.innerHTML = '&#8505;';
        this.divTitle.appendChild(button);
        //Info div
        let divInfo = document.createElement('div');
        divInfo.classList.add('info');
        divInfo.style.display = 'none';
        //Phone
        let spanPhoneElement = document.createElement('span');
        spanPhoneElement.innerHTML = `&phone; ${this.phone}`;
        //Email
        let spanEmailElement = document.createElement('span');
        spanEmailElement.innerHTML = `&#9993; ${this.email}`;

        divInfo.appendChild(spanPhoneElement);
        divInfo.appendChild(spanEmailElement);

        articleElement.appendChild(this.divTitle);
        articleElement.appendChild(divInfo);

        button.addEventListener('click', function () {
            divInfo.style.display = divInfo.style.display === 'none' ? 'block' : 'none';
        })

        childrenElement.appendChild(articleElement);
        }
}

// let contacts = [
//     new Contact("Ivan", "Ivanov", "0888 123 456", "i.ivanov@gmail.com"),
//     new Contact("Maria", "Petrova", "0899 987 654", "mar4eto@abv.bg"),
//     new Contact("Jordan", "Kirov", "0988 456 789", "jordk@gmail.com")
//   ];
//   contacts.forEach(c => c.render('main'));
  
//   // After 1 second, change the online status to true
//   setTimeout(() => contacts[1].online = true, 2000);
  