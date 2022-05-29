function focused() {
    let elements = document.querySelectorAll("div div input");
   for (const element of elements) {
    element.addEventListener('focus', function(event){
        event.target.parentNode.classList = 'focused';
    });

    element.addEventListener('blur', function(event){
        event.target.parentNode.classList = '';
    });
   }
}