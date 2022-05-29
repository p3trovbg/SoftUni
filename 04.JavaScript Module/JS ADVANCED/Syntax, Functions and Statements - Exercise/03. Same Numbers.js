function sameNumbers(digit) {
    let digitsAsString = String(digit);
    let flag = true;
    let sum = 0; 
    for (let i = 0; i < digitsAsString.length - 1; i++) {
        let currentDigit = Number(digitsAsString[i]);
        if (currentDigit != digitsAsString[i + 1]) {
            flag = false;
        }
        sum += currentDigit;
    }
    console.log(flag);
    console.log(sum + Number(digitsAsString[digitsAsString.length - 1]));
}

sameNumbers(2222222);
sameNumbers(1234);