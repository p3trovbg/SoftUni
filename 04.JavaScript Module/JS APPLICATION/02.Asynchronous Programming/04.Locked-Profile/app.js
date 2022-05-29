function lockedProfile() {
    let profileElement = document.querySelector('.profile');

    let showMoreButton = profileElement.children[10];
    let lockElement = profileElement.children[2];
    let unlockElement = profileElement.children[4];

    let usernameField = profileElement.children[7];
    
    unlockElement.addEventListener('change', (e) => {
        usernameField.disabled = false;
        usernameField.readOnly = false;
        usernameField.type = 'text';
    })

    showMoreButton.addEventListener('click', solution);


    async function solution() {
        usernameField.disabled = false;
        usernameField.readOnly = false;
    }
}