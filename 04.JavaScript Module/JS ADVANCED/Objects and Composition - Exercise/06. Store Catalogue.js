function storeCatalogue(input) {
    let products = [];
    for (const line of input) {
        let[name, price] = line.split(' : ');
        price = Number(price);
        products.push({name, price});
    }
    products.sort((a, b) => (a.name > b.name) ? 1 : -1)
    let firstCharacter = products[0].name[0];
    console.log(firstCharacter);
    
    for (const product of products) {
        if(product.name[0] != firstCharacter) {
            firstCharacter = product.name[0];
            console.log(firstCharacter);
        }  
        console.log(`  ${product.name}: ${product.price}`);
    }
}

storeCatalogue(['Appricot : 20.4',
'Fridge : 1500',
'TV : 1499',
'Deodorant : 10',
'Boiler : 300',
'Apple : 1.25',
'Anti-Bug Spray : 15',
'T-Shirt : 10']
);