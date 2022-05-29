function addItem() {
    let ulElement = document.getElementById('items');
    let liElement = document.createElement('li');
    
    let inputElement = document.getElementById('newItemText').value;
    liElement.textContent = inputElement;
    ulElement.appendChild(liElement);
}