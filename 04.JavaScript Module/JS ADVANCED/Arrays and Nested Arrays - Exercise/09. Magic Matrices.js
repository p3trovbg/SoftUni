function magicMatricies(matrix) {
    let sameDigits = [];
    for (let i = 0; i < matrix.length; i++) {
        let sum = 0;
        for (let j = 0; j < matrix[i].length; j++) {
            sum += matrix[i][j];
        }
        sameDigits.push(sum);
    }

    let isMagic = sameDigits.every(x => x == sameDigits[0]);
    console.log(isMagic);
}


magicMatricies([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );