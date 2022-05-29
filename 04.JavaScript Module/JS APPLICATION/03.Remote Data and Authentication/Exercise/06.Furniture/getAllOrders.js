window.addEventListener('load', async(e) => {
    e.preventDefault();
    document.querySelector('#showOrders').addEventListener('click', getOrders);
})


async function getOrders(e) {
    let userId = sessionStorage.getItem('userId');
    let url = `http://localhost:3030/data/orders?where=_ownerId%3D"${userId}"`;
    try{
        let response = await fetch(url);
        if (response.status !== 200) {
            throw new Error(await response.json().message);
        }

        let orders = await response.json();
        let totalPrice = 0;
        let products = [];
        for (const order of orders) {
            if(order.buyed) {
                totalPrice += Number(order.price);
                products.push(order.name);
            }
        }

        ordersDiv.children[1].children[0].textContent = `${totalPrice} $`;
        ordersDiv.children[0].children[0].textContent = `${products.join(', ')}`;
    }
    catch(error) {

    }
}