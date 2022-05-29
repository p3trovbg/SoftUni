class Restaurant {
    constructor (budgetMoney) {
        this.budgetMoney = budgetMoney;
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {
        for (const  product of products) {
            let[productName, productQuantity, productTotalPrice] = product.split(' ');
            productQuantity = Number(productQuantity);
            productTotalPrice = Number(productTotalPrice);
 
            if(this.budgetMoney >= productTotalPrice) {
                if (this.stockProducts[productName]) {
                    this.stockProducts[productName] += productQuantity;
                } else {
                    this.stockProducts[productName] = productQuantity;
                }

                this.budgetMoney -= productTotalPrice;
                this.history.push(`Successfully loaded ${productQuantity} ${productName}`);
            } else {
                this.history.push(`There was not enough money to load ${productQuantity} ${productName}`);
            }
        }
        return this.history.join('\n');
    }

    addToMenu(meal, neededProducts, price) {
            if(!this.menu[meal]) {
                this.menu[meal] = {neededProducts, price};

                let meals = Object.keys(this.menu).length;
            if(meals == 1) {
                return `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            } else if (meals == 0 || meals >= 2) {
                return `Great idea! Now with the ${meal} we have ${meals} meals in the menu, other ideas?`
            }
        } else {
            return `The ${meal} is already in the our menu, try something different.`;
        }        
    }

    showTheMenu() {
        let result = [];
        if (Object.keys(this.menu).length > 0) {
            for (const key in this.menu) {
                result.push(`${key} - $ ${this.menu[key].price}`);
            }
        } else {
            return `Our menu is not ready yet, please come later...`;
        }
        return result.join('\n');
    }

    makeTheOrder(meal) {
        if(!this.menu[meal]) {
            return `There is not ${meal} yet in our menu, do you want to order something else?`
        }

        for (const currProduct of this.menu[meal].neededProducts) {
            let[name, quantity] = currProduct.split(' ');
            quantity = Number(quantity);
            this.stockProducts[name] -= quantity;
            if(this.stockProducts[name] < quantity) {
                return `For the time being, we cannot complete your order (${meal}), we are very sorry...`;
            }
        }

        this.budgetMoney += this.menu[meal].price;
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }
}

let kitchen = new Restaurant(1000);
kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));


