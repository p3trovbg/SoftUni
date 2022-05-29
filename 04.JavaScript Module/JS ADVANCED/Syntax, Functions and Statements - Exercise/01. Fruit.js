function buyFood (fruit, weight, price) {
    let kilograms = weight / 1000;
    let totalPrice = price * kilograms;
    console.log(`I need $${totalPrice.toFixed(2)} to buy ${kilograms.toFixed(2)} kilograms ${fruit}.`);
}
buyFood('orange', 2500, 1.80);
buyFood('apple', 1563, 2.35);