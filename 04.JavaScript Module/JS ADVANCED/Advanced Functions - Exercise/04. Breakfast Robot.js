function solution() {
    let products = {};
    let ingredients = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }
    products['apple'] = {carbohydrate: 1, flavour: 2};
    products['lemonade'] = {carbohydrate: 10, flavour: 20};
    products['burger'] = {carbohydrate: 5, fat: 7, flavour: 3};
    products['eggs'] = {protein: 5, fat: 1, flavour: 1};
    products['turkey'] = {protein: 10, carbohydrate: 10, fat: 10, flavour: 10};
    return function(request) {
        let[command, product, quantity] = request.split(' ');
        let result = '';
        switch(command) {
            case "restock": 
            ingredients[product] += Number(quantity);
            result = 'Success';
                break;
            case "prepare": 
            quantity = Number(quantity);
            let currentProduct = products[product];
            let propsNames = Object.getOwnPropertyNames(currentProduct);
            let propsValue = Object.values(currentProduct).map(x => x * quantity);
            for (let i = 0; i < propsNames.length; i++) {
                let propName = propsNames[i];
                let value = propsValue[i];
                if(ingredients[propName] < value) {
                    result = `Error: not enough ${propName} in stock`;
                    break;
                } else {
                    ingredients[propName] -= value;
                }       
            }
            if(result == '') {
                result = 'Success';
            }

                break;
            case "report":              
                Object.keys(ingredients).forEach((x) => {
                    result += `${x}=${ingredients[x]} `;
                });
                break;
        }
        return result.trimEnd();
    }
}

let manager = solution (); 
console.log (manager ("restock flavour 50")); // Success 
console.log (manager ("prepare lemonade 4"));
console.log (manager ("report")); // Error: not enough carbohydrate in stock 

