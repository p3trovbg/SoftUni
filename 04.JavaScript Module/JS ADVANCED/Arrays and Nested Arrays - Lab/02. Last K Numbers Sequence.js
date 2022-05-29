function sequence(n, k) {
    const array = [];
    array.push(1);
    
    for (let i = 1; i < n; i++) {
        if (array.length >= k) {
            let sum = 0;
            for (let j = array.length - k; j < array.length; j++) {
                sum +=array[j];  
            }
            array.push(sum);
        } else {
            let sum = array.reduce((a, b) => a + b, 0);
           array.push(sum);
        }
    }

    return array;
}

sequence(8, 2);