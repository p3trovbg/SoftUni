function solve() {
    let inputFields = document.getElementById('container');
    let inputButtonElement = inputFields.children[3];
    let moviesElement = document.getElementById('movies');
    let archiveElement = document.getElementById('archive');

    inputButtonElement.addEventListener('click', (e) => {
        let isFill = Array.from(inputFields.children).filter(x => x.value == '');
        if(isFill.length == 1 && Number(inputFields.children[2].value)) {
            e.preventDefault();
            let ulElement = moviesElement.children[1];
            let liElement = document.createElement('li');
            //Create and append span element.
            let spanElement = document.createElement('span');
            spanElement.textContent = inputFields.children[0].value;
            liElement.appendChild(spanElement);
            //Create and append strong element.
            let strongElement = document.createElement('strong');
            strongElement.textContent = `Hall: ${inputFields.children[1].value}`;
            liElement.appendChild(strongElement);
            
            //Create and append div element.
            let divElement = document.createElement('div');
            //Create and append second strong element.
            let secondStrongElement = document.createElement('strong');
            secondStrongElement.textContent = Number(inputFields.children[2].value).toFixed(2);
            //Create and append input element.
            let inputElement = document.createElement('input');
            inputElement.placeholder = "Tickets Sold";
            //Create and append button element.
            let archiveButton = document.createElement('button');
            archiveButton.textContent = "Archive";
            archiveButton.addEventListener('click', archive);

            divElement.appendChild(secondStrongElement);
            divElement.appendChild(inputElement);
            divElement.appendChild(archiveButton);

            liElement.appendChild(divElement);
            ulElement.appendChild(liElement);
        }
    })

    function archive(e) {
        let inputField = e.target.parentElement.children[1];
        let movieName = e.target.parentElement.parentElement.children[0];
        let moviePrice = e.target.parentElement.children[0];

        if (inputField.value && Number(inputField.value)) {
            let liElement = document.createElement('li');
            let spanElement = document.createElement('span');
            let strongElement = document.createElement('strong');
            let deleteButton = document.createElement('button');
            //----------------------------------------------
            let price = Number(moviePrice.textContent);
            let count = Number(inputField.value);
            let totalPrice = (price * count).toFixed(2);

            spanElement.textContent = movieName.textContent;
           strongElement.textContent = `Total amount: ${totalPrice}`;
            deleteButton.textContent = 'Delete';
            //-----------------------------------------------
            liElement.appendChild(spanElement);
            liElement.appendChild(strongElement);
            liElement.appendChild(deleteButton);
            archiveElement.children[1].appendChild(liElement);

            let allMovies = Array.from(moviesElement.children[1].children);
            let currentFilm = allMovies.find(x => x.children[0].textContent == movieName.textContent);
            moviesElement.children[1].removeChild(currentFilm);

            deleteButton.addEventListener('click', (e) => {
                let element = e.target.parentElement;
                archiveElement.children[1].removeChild(element);
            });
            
            let clearButton = archiveElement.children[2];
            clearButton.addEventListener('click', (e) => {
                let allLiElements = archiveElement.children[1].children;
                for (let i = 0; i < allLiElements.length; i++) {
                    let currentLi = allLiElements[i];
                    archiveElement.children[1].removeChild(currentLi);
                } 
            })
        }
    }

}