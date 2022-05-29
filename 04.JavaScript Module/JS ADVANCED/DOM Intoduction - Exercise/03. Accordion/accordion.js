function toggle() {
    let moreText = document.getElementById('extra');
    let button = document.getElementsByClassName('button')[0];

    if (moreText.style.display == 'block') {
        moreText.style.display = 'none';
        button.textContent = 'More'; 
    } else {
        moreText.style.display = 'block';
        button.textContent = 'Less';
    }
}