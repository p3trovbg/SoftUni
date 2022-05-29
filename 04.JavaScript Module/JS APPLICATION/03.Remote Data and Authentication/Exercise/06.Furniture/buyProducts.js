window.addEventListener('load', async(e) => {
    e.preventDefault();
    document.querySelector('#buyBtn').addEventListener('click', buyProducts);
})


async function buyProducts(e) {
    let userId = sessionStorage.getItem('userId');
    let products = document.querySelector('tbody').children;

    let url = `http://localhost:3030/data/orders`;
    let token = sessionStorage.getItem('token');
    let isCheck = false;

    for (const product of products) {
        let check = product.children[4].children[0];
        if(product.id === userId && check.checked) {
            isCheck = true;
            let name = product.children[1].children[0].textContent;
            let price = product.children[2].children[0].textContent;
            let factor = product.children[3].children[0].textContent;
            let buyed = true;
            let productOrder = {name, price, factor, buyed};
            try{
                let response = await fetch(url, {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json',
                        'X-Authorization': token
                    },
                    body: JSON.stringify(productOrder)
                })

                if(!response.ok) {
                    const error = await response.json();
                    throw new Error(error.message);
                }
            }
            catch(error){
                alert(error.message);
            }
        } 
    }
    if (!isCheck) {
        alert('You should put tick on some of products.');
    }
}