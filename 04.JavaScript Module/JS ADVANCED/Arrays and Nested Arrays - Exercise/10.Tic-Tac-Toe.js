function ticTacToe(playersPosition) {
    let dashboard = [];
    for (let i = 0; i < 3; i++) {
        dashboard[i] = new Array(3);
        dashboard[i].fill(false);
    }
    
    let count = 0;
    for (const coordinates of  playersPosition) {
        let row = Number(coordinates[0]);
        let col = Number(coordinates[2]);
        
        if (!isFreePlace(dashboard)) {
            console.log("The game ended! Nobody wins :(");
            printGame(dashboard);
            return;
        }

        if (dashboard[row][col] !== false) {
            console.log("This place is already taken. Please choose another!");  
            continue;
        }
        
        if (count % 2 == 0) {
            dashboard[row][col] = 'X';
        } else {
            dashboard[row][col] = 'O';
        }

        let winner = isWin(dashboard);
        if(winner === 'O') {  
            console.log('Player O wins!');
            printGame(dashboard);
            return;
        } else if(winner === 'X') {
            console.log('Player X wins!');
            printGame(dashboard);
            return;
        }
       count++;
    }

    function printGame(dashboard) {
        for (const line of dashboard) {
            console.log(line.join('\t'));
        }
    }
    
    function isFreePlace(dash) {
        for (const line of dash) {
            for (const elements of line ) {
                if (elements === false)
                {
                    return true;
                }
            }
        }
        return false;
    }
    
    function isWin(dashboard) {
        let isWin = 'NS';
        const winningConditions = [
            [0, 0],[0, 1],[0, 2],
            [1, 0],[1, 1],[1, 2],
            [2, 0],[2, 1],[2, 2],
            [0, 0],[1, 0],[2, 0],
            [0, 1],[1, 1],[2, 1],
            [0, 2],[1, 2],[2, 2],
            [0, 0],[1, 1],[2, 2],
            [0, 2],[1, 1],[2, 0]
        ];
        for (let i = 0; i < winningConditions.length; i+= 3) {
            let firstLine = winningConditions[i];
            let secondLine = winningConditions[i + 1]; 
            let thirdLine = winningConditions[i + 2];
    
            let a =  dashboard[firstLine[0]][firstLine[1]];
            let b =  dashboard[secondLine[0]][secondLine[1]];
            let c = dashboard[thirdLine[0]][thirdLine[1]];
            if (a == false || b == false || c == false) {
                continue;
            }
            if (a === b && b === c) {
                isWin = a === 'O' ? 'O' : 'X';
                break;
            }                                  
        }
        return isWin;
    }
}

ticTacToe(["0 1",
"0 0",
"0 2", 
"2 0",
"1 0",
"1 1",
"1 2",
"2 2",
"2 1",
"0 0"]
);