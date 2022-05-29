function lowestPrice(input) {
    const products = [];
    for (const line of input) {
        let[townName, productName, price] = line.split(' | ');
        price = Number(price);
        let wantedProduct = products.find(x => Object.keys(x)[0] === productName);
        if (!wantedProduct) {
            products.push({[productName]: {[townName]: price}});
        }
    }

    for (const product of products) {
        for (const key in product) {
            let [town, price] = Object.entries(product[key]).sort((a, b) => a[1] - b[1])[0];
            console.log(`${key} -> ${price} (${town})`);
        }
    }

}

lowestPrice(['Sample Town | Sample Product | 1000',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Orange | 3',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);