function getBiggestElement(matrix) {
    let biggestNumber = -10000000000000;
    for (const arrDigits of matrix) {
        let max = Math.max.apply(0, arrDigits);
        if (biggestNumber < max) {
           biggestNumber = max;
        }
    }
    console.log(biggestNumber);
}

getBiggestElement([[-20, -50, -10],
    [-8, -33, -145]]
   );