function orbits(input) {
    let rows = input[0];
    let cols = input[1];
    let rowStar = input[2];
    let colStar = input[3];
    let orbit = [];
    for (let i = 0; i < rows; i++) {
        orbit[i] = new Array(cols);
        orbit[i].fill(0);
    }
    
    orbit[rowStar][colStar] = 1;  
    let move = 1;
    for (let k = 0; k < orbit.length - 1; k++) {
        for (let row = rowStar - move; row <= rowStar + move; row++) {
            if (row < 0) {
                continue;
            }
            for (let col = colStar - move; col <= colStar + move; col++) {
                if (row >= 0 && row < rows && col < rows && col >= 0 && col < cols && orbit[row][col] === 0) {
                        orbit[row][col] = move + 1;
                    }         
            }       
        }  
        move++;
    }

    for (const star of orbit) {
        console.log(star.join(' '));
    }
}

orbits([3, 3, 2, 2]);
orbits([4, 4, 0, 0]);