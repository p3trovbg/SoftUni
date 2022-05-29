function solve() {
    let selectMenuElement = document.getElementById('selectMenuTo');
    let binaryElement = document.createElement("option");
    binaryElement.value = "binary";
    binaryElement.textContent = "Binary";

    let hexadecimalElement = document.createElement("option");
    hexadecimalElement.value = "hexadecimal";
    hexadecimalElement.textContent = "Hexadecimal";
    
    selectMenuElement.appendChild(binaryElement);
    selectMenuElement.appendChild(hexadecimalElement);

    let result = document.querySelector("#result");
    let buttonElement = document.querySelector('button');

    buttonElement.addEventListener("click", (el) => {
      let num = Number(document.querySelector("#input").value);
      let type = selectMenuElement.value;
      if (type === 'binary') {
        result.value = num.toString(2);
      } else {
        result.value = num.toString(16).toUpperCase();
      }
    });
}