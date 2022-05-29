function sum (firstInput, secondInput) {
    let firstDigit = Number(firstInput);
    let secondDigit = Number(secondInput);
    let result = 0;
    for (let i = firstDigit; i <= secondDigit; i++) {
        result += i;
    }
    return result;
}

sum('-8', '20');