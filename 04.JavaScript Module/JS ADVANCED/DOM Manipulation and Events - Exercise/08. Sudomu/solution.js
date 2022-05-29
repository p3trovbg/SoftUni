function solve() {
    let buttonElements = Array.from(document.querySelectorAll('td button'));
    let tableElement = document.querySelector('table');
    let pElement = document.querySelectorAll('#check p')[0];
    let matrix = [];
    
    buttonElements[1].addEventListener('click', (e) => {
        tableElement.style.border = "none";
        pElement.textContent = "";
        Array.from(document.getElementsByTagName('input')).forEach(x => x.value = '');
    });

    buttonElements[0].addEventListener('click', (e) => {
        let allCellsElements = Array.from(document.querySelectorAll('tbody tr td input'));
        for (let i = 0; i < 3; i++) {
            matrix[i] = new Array(3);
            matrix[i].fill(0);
            for (let j = 0; j < matrix[i].length; j++) {
                let cell = allCellsElements.shift(); 
                matrix[i][j] = cell.value;
            }
        }
        
        let rowArray = [];
        let colArray = [];
        let error = false;
        for (let i = 0; i < matrix.length; i++) {
            for (let j = 0; j < matrix[i].length; j++) {
                let elementRow = matrix[i][j];
                let elementCol = matrix[j][i];
                 if(!rowArray.includes(elementRow) && elementRow > 0 && elementRow <=3) {
                     rowArray.push(elementRow);
                 } else {
                    error = true;
                    break;
                 }                
                 if(!colArray.includes(elementCol) && elementCol > 0 && elementCol <=3) {
                    colArray.push(elementCol);
                } else {
                    error = true;
                    break;
                }
            }
            if(error) {
                break;
            } else {
                rowArray = [];
                colArray = [];
            }  
        }

        if (error) {
            pElement.textContent = 'NOP! You are not done yet...';
            pElement.style.color = "red";
            tableElement.style.border = "2px solid red";
        } else {
            pElement.textContent = 'You solve it! Congratulations!';
            pElement.style.color = "green";
            tableElement.style.border = "2px solid green";
        }
    });
}