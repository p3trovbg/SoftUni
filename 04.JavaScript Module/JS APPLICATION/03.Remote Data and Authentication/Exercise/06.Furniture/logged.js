let tBody = document.querySelector('tbody');
let ordersDiv = document.querySelector('.orders');
window.addEventListener('load', async(e) => {
    e.preventDefault();
    tBody.replaceChildren();
    let token = sessionStorage.getItem('token');
    let totalPrice = ordersDiv.children[1].children[0].textContent = '0 $';
    ordersDiv.children[0].children[0].textContent = '';
    if(token == null) {
        alert('You are not login!')
        window.location = '/06.Furniture/login.html';
        
    } 
    let id = sessionStorage.getItem('userId');
    if(id) {
        await loadOwnerProducts(id);
    }
    document.querySelector('form').addEventListener('submit', requestCreateProduct);

})


async function loadOwnerProducts(id) {
    let url = `http://localhost:3030/data/furniture?where=_ownerId%3D"${id}"`;
    try{
        const response = await fetch(url);
        if(response.status !== 200) {
            throw new Error(await response.json().message);
        }

        let data = await response.json();
        for (const product of data) {
            addProduct(product);
        }
    }
    catch(error) {
        alert(error.message);
    }
}


async function requestCreateProduct(e) {
    e.preventDefault();

    let form = new FormData(e.target);

    let name = form.get('name').trim();
    let price = form.get('price').trim();
    let factor = form.get('factor').trim();
    let img = form.get('img').trim();

    if(!name || !price || !factor || !img) {
        alert('You must fill all fields!');
        return;
    }

    let product = {name, price, factor, img};
    let token = sessionStorage.getItem('token');
    const url = `http://localhost:3030/data/furniture`;
    try {
        const response = await fetch(url, {
            method: 'POST', 
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': token
            }
            ,body: JSON.stringify(product)
        })

        if(!response.ok) {
            throw new Error(`${await response.json().message}`);
        }

        
        let data = await response.json();
        addProduct(data);

    }
    catch(error) {
        alert(error.message);
    }
}



async function addProduct(product) {
    let row = createElement('tr', undefined, undefined, undefined, undefined, undefined, tBody);
    row.id = product._ownerId;  

    createElement('td', undefined, undefined, undefined, undefined, undefined, row);
    createElement('img', product.img, undefined, undefined, undefined, undefined, row.lastChild);

    createElement('td', undefined, undefined, undefined, undefined, undefined, row);
    createElement('p', undefined, product.name, undefined, undefined, undefined, row.lastChild);

    createElement('td', undefined, undefined, undefined, undefined, undefined, row);
    createElement('p', undefined, product.price, undefined, undefined, undefined, row.lastChild);

    createElement('td', undefined, undefined, undefined, undefined, undefined, row);
    createElement('p', undefined, product.factor, undefined, undefined, undefined, row.lastChild);

    createElement('td', undefined, undefined, undefined, undefined, undefined, row);
    createElement('input', undefined, undefined, 'checkbox', undefined, undefined, row.lastChild);

}

function createElement(element, src, textCon, type, className, value, parent) {
    let domElement = document.createElement(element);

    if(src) {
        domElement.src = src;
    }
    if (textCon) {
        domElement.textContent = textCon;
    }
    if (type) {
        domElement.type = type;
    }
    if (className) {
        domElement.className = className;
    }
    if (value) {
        domElement.value = value;
    }
    if (parent) {
        parent.appendChild(domElement);
    }
    return domElement;
}