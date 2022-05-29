function solution() {
    let mainElement = document.getElementById('main');

    const baseUrl = `http://localhost:3030/jsonstore/advanced/articles/list`;
    fetch(baseUrl)
    .then(response => {
        if (response.status != 200) {
            throw new Error('Invalid URL!');
        }
        return response.json();
    })
    .then(data => {
        let divAccordion = document.createElement('div');
        divAccordion.className = 'accordion';

        for (const part of data) {
            let id = part['_id'];
            let title = part['title'];

            let divHead = document.createElement('div');
            divHead.className = 'head';

            let spanTitle = document.createElement('span');
            spanTitle.textContent = title;
            
            let moreButton = document.createElement('button');
            moreButton.className = 'button';
            moreButton.id = id;
            moreButton.textContent = 'More';

            let divExtra = document.createElement('div');
            divExtra.className = 'extra';

            fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${id}`)
            .then(response => {
                if(response.status !== 200) {
                    throw new Error('Error');
                }
                return response.json();
            })
            .then(data => {
                let text = data.content;
                let pElement = document.createElement('p');
                pElement.textContent = text;
                divExtra.appendChild(pElement);
            }) 
            
            divHead.appendChild(spanTitle);
            divHead.appendChild(moreButton);
            divAccordion.appendChild(divHead);
            divAccordion.appendChild(divExtra);
        }
        mainElement.appendChild(divAccordion);

        let buttons = document.querySelectorAll('.button');
        for (const button of buttons) {
        button.addEventListener('click', (e) => {
            let element = e.target.parentElement.nextSibling;
            if(e.target.textContent == 'More') {
                e.target.textContent = 'Less';
                element.style.display = 'block';
            } else {
                e.target.textContent = 'More';
                element.style.display = 'none';
            }
        })
    }
    })
    .catch(error => {
        mainElement.replaceChildren();
        let li = document.createElement('li');
        li.textContent = error.message;
        li.className = 'head';
        mainElement.appendChild(li);
    })
}
solution();