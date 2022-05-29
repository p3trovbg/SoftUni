function diagonalSums(matrix) {
    let rightDiagonal = 0;
    let leftDiagonal = 0;
    for (let i = 0; i < matrix[0].length; i++) {
        rightDiagonal += matrix[i][i];
        let leftIdx = matrix[0].length - i - 1;
        leftDiagonal += matrix[leftIdx][i];
    } 
    console.log(rightDiagonal, leftDiagonal);
}

diagonalSums([[3, 5, 17],
    [-1, 7, 14],
    [1, -8, 89]]
            );