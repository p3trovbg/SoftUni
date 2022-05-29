function diagonalAttack(matrix) {
    let digitsMatrix = [];
    for (const line of matrix) {
        let newLine = line.split(' ').map(Number);
        digitsMatrix.push(newLine);
    }

    let diagonalCoordinates = [];
    let rightDiagonal = 0;
    let leftDiagonal = 0;
    for (let i = 0; i < digitsMatrix.length; i++) {
        rightDiagonal += digitsMatrix[i][i];
        leftDiagonal += digitsMatrix[i][digitsMatrix[0].length - i - 1];
        diagonalCoordinates.push(i, i, i, digitsMatrix[0].length - i - 1);
    } 

    if (rightDiagonal === leftDiagonal) {
        for (let i = 0; i < digitsMatrix.length; i++) {
            for (let j = 0; j < digitsMatrix[i].length; j++) {
                if(!isPartOfMainDiagonal(i, j, diagonalCoordinates)) {
                    digitsMatrix[i][j] = rightDiagonal;
                }
            }
        }
    } 

    for (const item of digitsMatrix) {
        console.log(item.join(' '));
    }

    function isPartOfMainDiagonal(row, col, matrix) {
        for (let i = 0; i < matrix.length; i+= 2) {
            if (row == matrix[i] && col == matrix[i + 1]) {
                return true;
            }
        }
        return false;
    }
}

diagonalAttack(['5 3 12 3 1',
'11 4 23 2 5',
'101 12 3 21 10',
'1 4 5 2 2',
'5 22 33 11 1']
);