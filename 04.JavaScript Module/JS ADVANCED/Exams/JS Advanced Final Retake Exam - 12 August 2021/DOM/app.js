window.addEventListener('load', solve);

function solve() {
    let modelElement = document.getElementById('model');
    let yearElement = document.getElementById('year');
    let descriptionElement = document.getElementById('description');
    let priceElement = document.getElementById('price');

    let addButton = document.getElementById('add');

    addButton.addEventListener('click', (e) => {
        e.preventDefault();
        if(modelElement.value && Number(yearElement.value) && descriptionElement.value && Number(priceElement.value)) {
            let price = Number(priceElement.value);
            let year = Number(yearElement.value);

            let furnitureElement = document.querySelector('#furniture-list');
                //Info 
                let trInfoElement = document.createElement('tr');
                trInfoElement.className = 'info';

                let tdModelElement = document.createElement('td');
                tdModelElement.textContent = modelElement.value;
                let tdPriceElement = document.createElement('td');
                tdPriceElement.textContent = price.toFixed(2);
                let tdButtonsElement = document.createElement('td');
                let moreButton = document.createElement('button');
                moreButton.textContent = 'More Info';
                moreButton.className = 'moreBtn';
                let buyButton = document.createElement('button');
                buyButton.textContent = 'Buy it';
                buyButton.className = 'buyBtn';

                tdButtonsElement.appendChild(moreButton);
                tdButtonsElement.appendChild(buyButton);
                
                trInfoElement.appendChild(tdModelElement);
                trInfoElement.appendChild(tdPriceElement);
                trInfoElement.appendChild(tdButtonsElement);

                //Additional info
                let additionalInfoElement = document.createElement('tr');
                additionalInfoElement.className = 'hide';

                let tdYearElement = document.createElement('td');
                    tdYearElement.textContent = `Year: ${year}`;

                let tdDescriptionElement = document.createElement('td');
                    tdDescriptionElement.textContent = `Description: ${descriptionElement.value}`;

                additionalInfoElement.appendChild(tdYearElement);
                additionalInfoElement.appendChild(tdDescriptionElement);


                moreButton.addEventListener('click', (e) => {
                    if(e.target.textContent == 'More Info') {
                        e.target.textContent = "Less Info"
                        tdDescriptionElement.colSpan = 3;
                    additionalInfoElement.style.display = 'contents';
                    } else {
                        e.target.textContent = "More Info"
                    additionalInfoElement.style.display = 'none';
                    }
                })

                buyButton.addEventListener('click', (e) => {
                    let parent = e.target.parentElement.parentElement;
                    let additonalSibling = parent.nextSibling;
                    let totalPriceElement = document.querySelector('.total-price');
                    let price = Number(totalPriceElement.textContent);
                    let currentPrice = Number(parent.children[1].textContent);
                    price += currentPrice;
                    totalPriceElement.textContent = price.toFixed(2);
                    furnitureElement.removeChild(parent);
                    furnitureElement.removeChild(additonalSibling);
                })

                furnitureElement.appendChild(trInfoElement);
                furnitureElement.appendChild(additionalInfoElement);

                modelElement.value = '';
                yearElement.value = '';
                descriptionElement.value = '';
                priceElement.value = '';
        }
    })
}
