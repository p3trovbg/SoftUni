function addItem() {
    let inputElement = document.getElementById('newItemText').value;
    let listOfItems = document.getElementById('items');
    let newElement = document.createElement('li');
    newElement.textContent = inputElement;
    inputElement.value = '';
    
    let deleteElement = document.createElement('a');
    deleteElement.href = "#";
    deleteElement.textContent = '[Delete]';

    deleteElement.addEventListener('click', (e) => {
        e.currentTarget.parentElement.remove();
    });

    newElement.appendChild(deleteElement);
    listOfItems.appendChild(newElement);
}