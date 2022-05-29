function solve() {
    let addButtonElement = document.querySelector('#add');
    let inputTaskElement = document.querySelector('#task');
    let textAreaElement = document.querySelector('#description');
    let inputDateElement = document.querySelector('#date');
 
    let sections = document.querySelector('.wrapper');
 
    addButtonElement.addEventListener('click', addOpenSection)
 
    function addOpenSection(e) {
        e.preventDefault();
        //Second Section
        if (inputTaskElement.value != '' && textAreaElement.value !== '' && inputDateElement.value !== '') {
            let articleElement = document.createElement('article');
 
            let h3Element = document.createElement('h3');
            let firstP = document.createElement('p');
            let secondP = document.createElement('p');
            let divElement = document.createElement('div');
            let startButton = document.createElement('button');
            let deleteButton = document.createElement('button');
 
            h3Element.textContent = inputTaskElement.value;
            firstP.textContent = `Description: ${textAreaElement.value}`;
            secondP.textContent = `Due Date: ${inputDateElement.value}`;
            startButton.className = "green";
            startButton.textContent = "Start";
            deleteButton.className = "red";
            deleteButton.textContent = "Delete";
            divElement.className = "flex";
            divElement.appendChild(startButton);
            divElement.appendChild(deleteButton);
 
            //Third section
            startButton.addEventListener('click', addInProgressSection);
            deleteButton.addEventListener('click', deleteElement);
 
            articleElement.appendChild(h3Element);
            articleElement.appendChild(firstP);
            articleElement.appendChild(secondP);
            articleElement.appendChild(divElement);
 
            sections.children[1].children[1].appendChild(articleElement);
 
            inputTaskElement.value = '';
            textAreaElement.value = '';
            inputDateElement.value = '';
        }
    }
 
    function addInProgressSection(e) {
        let articleElement = document.createElement('article');
 
                let h3Element = document.createElement('h3');
                let firstP = document.createElement('p');
                let secondP = document.createElement('p');
                let divElement = document.createElement('div');
                let deleteButton = document.createElement('button');
                let finishButton = document.createElement('button');
 
                let courseName = e.target.parentElement.parentElement.children[0];
                let courseDescription = e.target.parentElement.parentElement.children[1];
                let courseDate = e.target.parentElement.parentElement.children[2];
 
                h3Element.textContent = courseName.textContent;
                firstP.textContent = courseDescription.textContent;
                secondP.textContent = courseDate.textContent;
                finishButton.className = "orange";
                finishButton.textContent = "Finish";
                deleteButton.className = "red";
                deleteButton.textContent = "Delete";
                divElement.className = "flex";
                divElement.appendChild(deleteButton);
                divElement.appendChild(finishButton);
 
                //Last section
                finishButton.addEventListener('click', lastSection);
                deleteButton.addEventListener('click', deleteElement);
 
                articleElement.appendChild(h3Element);
                articleElement.appendChild(firstP);
                articleElement.appendChild(secondP);
                articleElement.appendChild(divElement);
 
                sections.children[2].children[1].appendChild(articleElement);
                deleteElement(e);
    }
 
    function lastSection(e) {
                    let courseName = e.target.parentElement.parentElement.children[0];
                    let courseDescription = e.target.parentElement.parentElement.children[1];
                    let courseDate = e.target.parentElement.parentElement.children[2];
 
                    let articleElement = document.createElement('article');
                    let h3Element = document.createElement('h3');
                    let firstP = document.createElement('p');
                    let secondP = document.createElement('p');
 
                    h3Element.textContent = courseName.textContent;
                    firstP.textContent = courseDescription.textContent;
                    secondP.textContent = courseDate.textContent;
 
                    articleElement.appendChild(h3Element);
                    articleElement.appendChild(firstP);
                    articleElement.appendChild(secondP);
 
                    sections.children[3].children[1].appendChild(articleElement);
                    deleteElement(e);
    }
 
    function deleteElement(e) {
        let firstParent = e.target.parentElement.parentElement;
            let secondParent = firstParent.parentElement;
            secondParent.removeChild(firstParent);
    }
}