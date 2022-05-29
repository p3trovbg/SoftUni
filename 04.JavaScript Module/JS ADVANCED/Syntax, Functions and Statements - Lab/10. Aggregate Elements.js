function aggregate(digits) {
    const digitsArray = digits;
    let firstResult = 0;
    let secondResult = 0;
    let thirdResult = '';
    for (let i = 0; i < digitsArray.length; i++) {
        const element = digitsArray[i];
        firstResult += element;
        secondResult += 1 / digitsArray[i]
        thirdResult += String(digitsArray[i]);
    }
    console.log(firstResult);
    console.log(secondResult);
    console.log(thirdResult);
}

aggregate([1, 2, 3]);