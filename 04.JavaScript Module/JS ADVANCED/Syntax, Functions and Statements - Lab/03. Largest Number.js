function largestNumber(firstDigit, secondDigit, thirdDigit) {
    let result = `The largest number is ${Math.max(firstDigit, secondDigit, thirdDigit)}.`;
    console.log(result);
}

largestNumber(5, -3, 16);