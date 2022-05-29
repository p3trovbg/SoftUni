function greatestDivisor (firstDigit, secondDigit) {
    for (let i = secondDigit; i >= 1; i--) {
        if (firstDigit % i == 0 && secondDigit % i == 0) {
            console.log(i);
            break;
        }
    }
}

greatestDivisor(2154, 458);