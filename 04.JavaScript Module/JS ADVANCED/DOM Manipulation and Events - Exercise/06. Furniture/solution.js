function solve() {
  let exerciseElement = document.getElementById('exercise');
  let inputTextElement = exerciseElement.children[1];
  let inputButtonElement = exerciseElement.children[2];
  let furnitureRows = Array.from(document.querySelectorAll('tbody'));

  inputButtonElement.addEventListener('click', (e) => {
    let furnitureObj = JSON.parse(inputTextElement.value);
    for (const furnitureInfo of furnitureObj) {
      //Image
      let image = document.createElement('img');
      image.src = furnitureInfo.img;
      //Name
      let name = document.createElement('p');
      name.textContent = furnitureInfo.name;
      //Price
      let price = document.createElement('p');
      price.textContent = furnitureInfo.price;
      //decFactor
      let decFactor = document.createElement('p');
      decFactor.textContent = furnitureInfo.decFactor;
      //Checkbox
      let x = document.createElement('input');
      x.setAttribute("type", "checkbox");
      trElement = document.createElement('tr');

      for (let index = 0; index < 5; index++) {
        let tdElement = document.createElement('td');
        switch(index) {
          case 0: tdElement.appendChild(image); break;
          case 1: tdElement.appendChild(name); break;
          case 2: tdElement.appendChild(price); break;
          case 3: tdElement.appendChild(decFactor); break;
          case 4: tdElement.appendChild(x); break;
        }
        trElement.appendChild(tdElement);
      }
      furnitureRows[0].appendChild(trElement);
    }
  });

  let products = [];
  let sum = 0; 
  let averageDec = 0;
  let buyButton = exerciseElement.children[5];

  buyButton.addEventListener('click', (e) => {
    for (const child of furnitureRows[0].children) {
      let checkedElement = child.children[4].children[0];

      if(checkedElement.checked) {
        let nameProduct = child.children[1].children[0].textContent;
        let priceProduct = Number(child.children[2].children[0].textContent);
        let decFactor = Number(child.children[3].children[0].textContent);
        
          products.push(nameProduct);
          sum += priceProduct;
          averageDec += decFactor;
      }
    }
    if(products.length == 0) {
      return;
    }
      let textArea = exerciseElement.children[4];
      textArea.value += `Bought furniture: ${products.join(', ')}\n`;
      textArea.value += `Total price: ${sum.toFixed(2)}\n`;
      textArea.value += `Average decoration factor: ${averageDec / products.length}`;
    
  });
}