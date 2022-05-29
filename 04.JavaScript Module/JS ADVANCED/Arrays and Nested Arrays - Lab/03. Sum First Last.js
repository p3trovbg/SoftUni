function sumFirstLast(array) {
    let digits = array.map(Number);
    let sum = digits.pop() + digits.shift();
    console.log(sum);
}

sumFirstLast(['20', '30', '40']);