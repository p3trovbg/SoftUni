function addItem() {
    let textElement = document.getElementById('newItemText');
    let valueElement = document.getElementById('newItemValue');
    let optionElement = document.createElement('option');
    let optionValue = `${textElement.value}${valueElement.value}`;
    optionElement.textContent = optionValue;
    let menuElement = document.getElementById('menu');
    menuElement.appendChild(optionElement);
    textElement.value = "";
    valueElement.value = "";
}