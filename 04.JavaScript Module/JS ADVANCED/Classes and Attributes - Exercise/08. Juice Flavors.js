function solve(juices) {
    let juiceObj = {};
    let result = {};
    for (const juice of juices) {
        let[name, quantity] = juice.split(' => ');
        quantity = Number(quantity);
        if(!juiceObj[name]) {
            juiceObj[name] = quantity;
        }  else {
            juiceObj[name] += quantity;
        }   

        let fruitQuantity = juiceObj[name];
        if (fruitQuantity >= 1000) {
            let bottles = Math.floor(fruitQuantity / 1000);
            result[name] = bottles;
        }
    }

    for (const currentJuice in result) {
            console.log(`${currentJuice} => ${result[currentJuice]}`);
        } 
}

// solve(['Orange => 2000',
// 'Peach => 1432',
// 'Banana => 450',
// 'Peach => 600',
// 'Strawberry => 549']
// );

solve(['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);