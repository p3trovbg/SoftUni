function evenDigit(array) {
    let even = [];
    for (let i = 0; i < array.length; i++) {
        if(i % 2 == 0) {
            even.push(array[i]);
        }
    }
    console.log(even.join(' '));
    
}

evenDigit(['20', '30', '40', '50', '60']);
