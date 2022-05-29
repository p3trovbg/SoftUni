function lockedProfile() {
    let buttonElements = document.querySelectorAll('button');
    for (const button of buttonElements) {
        let unlockElement = button.parentElement.children[4];
        let div = button.parentElement.children[9];
         button.addEventListener('click', (e) => {
             if(unlockElement.checked && button.textContent == 'Show more') {
                div.style.display = "inline-block";
                button.textContent = 'Hide it';
             } else if(unlockElement.checked) {
                div.style.display = "none";
                button.textContent = 'Show more';
             }
         });        
    }
}