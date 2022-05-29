//'+', '-', '*', '/', '%', '**'.
function mathOperation(firstDigit, secondDigit, mathOperator) {
    let result = null;
    if (mathOperator == '+') {
        result = firstDigit + secondDigit;
    } else if (mathOperator == '-') {
        result = firstDigit - secondDigit;
    } else if (mathOperator == '*') {
        result = firstDigit * secondDigit;
    } else if (mathOperator == '/') {
        result = firstDigit / secondDigit;
    } else if (mathOperator == '%') {
        result = firstDigit % secondDigit;
    } else if (mathOperator == '**') {
        result = firstDigit ** secondDigit;
    }
    console.log(result);
}

mathOperation(3, 5.5, '*');