function printProducts(productsInfo) {
    const products = {};      
    for (let i = 0; i < productsInfo.length; i+= 2) {
       products[productsInfo[i]] = Number(productsInfo[i + 1]);
    }
    console.log(products);
}

printProducts(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);