function validate() {
    let emailElement = document.getElementById('email');
      emailElement.addEventListener('change', (e) => {
        let regex = new RegExp('[a-z]+@[a-z]+\.[a-z]+');
        if(regex.test(emailElement.value)) {
            e.target.classList = '';
        } else {
            e.target.classList.add("error");
        }
      });
}