window.addEventListener('load', solve);

function solve() {
    let addButtonElement = document.getElementById('add-btn');
    let genreElement = document.getElementById('genre');
    let nameElement = document.getElementById('name');
    let authorElement = document.getElementById('author');
    let dateElement = document.getElementById('date');

    addButtonElement.addEventListener('click', (e) => {
        if(genreElement.value && nameElement.value && authorElement.value && dateElement.value) {
            e.preventDefault();
            let divElement = document.createElement('div');
            divElement.className = 'hits-info';

            let imgElement = document.createElement('img');
            imgElement.src = "./static/img/img.png";

            let h2GenreElement = document.createElement('h2');
            h2GenreElement.textContent = `Genre: ${genreElement.value}`;

            let h2NameElement = document.createElement('h2');
            h2NameElement.textContent = `Name: ${nameElement.value}`;
            
            let h2AuthorElement = document.createElement('h2');
            h2AuthorElement.textContent = `Author: ${authorElement.value}`;

            let h3DateElement = document.createElement('h3');
            h3DateElement.textContent = `Date: ${dateElement.value}`;

            let buttonSave = document.createElement('button');
            buttonSave.textContent = 'Save song';
            buttonSave.className = 'save-btn';
            let buttonLike = document.createElement('button');
            buttonLike.textContent = 'Like song';
            buttonLike.className = 'like-btn';
            let buttonDelete = document.createElement('button');
            buttonDelete.textContent = 'Delete';
            buttonDelete.className = 'delete-btn';

            divElement.appendChild(imgElement);
            divElement.appendChild(h2GenreElement);
            divElement.appendChild(h2NameElement);
            divElement.appendChild(h2AuthorElement);
            divElement.appendChild(h3DateElement);

            divElement.appendChild(buttonSave);
            divElement.appendChild(buttonLike);
            divElement.appendChild(buttonDelete);

            buttonLike.addEventListener('click', (e) => {
                let likeElement = document.querySelector('.likes').children[0];
                let text = likeElement.textContent.split(' ');
                let likeAsNumber = Number(text[2]) + 1;
                likeElement.textContent = `Total Likes: ${likeAsNumber}`;
                e.target.disabled = true;
            })

             buttonSave.addEventListener('click', (e) => {
                 let parentElement = e.target.parentElement;
                 let[img, h2First, h2Second, h2Third, h3] = Array.from(parentElement.children);

                 let divElement = document.createElement('div');
                 divElement.className = 'hits-info';

                let imgElement = document.createElement('img');
                imgElement.src = img.src;

                let h2GenreElement = document.createElement('h2');
                h2GenreElement.textContent = h2First.textContent;

                let h2NameElement = document.createElement('h2');
                h2NameElement.textContent = h2Second.textContent;
                
                let h2AuthorElement = document.createElement('h2');
                h2AuthorElement.textContent = h2Third.textContent;

                let h3DateElement = document.createElement('h3');
                h3DateElement.textContent = h3.textContent;

                let deleteButton = document.createElement('button');
                deleteButton.textContent = 'Delete';
                deleteButton.className = 'delete-btn';

                divElement.appendChild(imgElement);
                divElement.appendChild(h2GenreElement);
                divElement.appendChild(h2NameElement);
                divElement.appendChild(h2AuthorElement);
                divElement.appendChild(h3DateElement);
                divElement.appendChild(deleteButton);

                deleteButton.addEventListener('click', (e) => {
                    let firstParent = e.target.parentElement;
                    let secondParent = firstParent.parentElement;
                    secondParent.removeChild(firstParent);
                })

                //Remove from saved section
                document.querySelector('.saved-container').appendChild(divElement);
                let firstParent = e.target.parentElement;
                let secondParent = firstParent.parentElement;
                secondParent.removeChild(firstParent);
             })

             buttonDelete.addEventListener('click', (e) => {
                let firstParent = e.target.parentElement;
                let secondParent = firstParent.parentElement;
                secondParent.removeChild(firstParent);
            })
            
            document.querySelector('.all-hits-container').appendChild(divElement);
            genreElement.value = '';
            nameElement.value = '';
            authorElement.value = '';
            dateElement.value = '';
        }
    })
}