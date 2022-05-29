
function equalElements(matrix) {
    let count = 0;

    for (let i = 0; i < matrix.length; i++) {
        for (let j = 0; j < matrix[i].length; j++) {
            let row =  i;
            let col = j;
                  let currentElement = matrix[row][col];
                  let isLastRow = row === matrix.length - 1;
                  let isLastCol = col === matrix[row].length - 1;

                  if (isLastRow && isLastCol) {
                      break;
                  } else if (isLastRow && currentElement === matrix[row][col + 1]) {
                      count++;
                  } else if (isLastCol && currentElement === matrix[row + 1][col]) {
                      count++;
                  } else if (!isLastCol && !isLastRow && currentElement === matrix[row][col + 1]) {
                    count++;
                  } else if (!isLastCol && !isLastRow && currentElement === matrix[row + 1][col]) {
                    count++;
                  }
                 
        }     
    }
    
    console.log(count);
}

equalElements([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
);