function solve(){
 
   //creator, title, category and content, create button
   let creatorElement = document.getElementById('creator');
   let titleElement = document.getElementById('title');
   let categoryElement = document.getElementById('category');
   let contentElement = document.getElementById('content');
   let createButton = document.getElementsByClassName('btn create')[0];
   let postsElement = document.querySelector('.site-content');

   let archiveSection = document.querySelector('.archive-section');
   createButton.addEventListener('click', (e) => {
      e.preventDefault();
      if(creatorElement.value && titleElement.value && categoryElement.value && contentElement.value) {
         let articleElement = document.createElement('article');
         //Title
         let h1Title = document.createElement('h1');
         h1Title.textContent = titleElement.value;
         //Category
         let pCategoryElement = document.createElement('p');
         pCategoryElement.textContent = 'Category: ';
         let strongCategoryElement = document.createElement('strong');
         strongCategoryElement.textContent = categoryElement.value;
         pCategoryElement.appendChild(strongCategoryElement);
         //Creator
         let pCreatorElement = document.createElement('p');
         pCreatorElement.textContent = 'Creator: ';
         let strongCreatorElement = document.createElement('strong');
         strongCreatorElement.textContent = creatorElement.value;
         pCreatorElement.appendChild(strongCreatorElement);
         //Content
         let pContentElement = document.createElement('p');
         pContentElement.textContent = contentElement.value;
         //Buttons
         let divElement = document.createElement('div');
         divElement.className = 'buttons';
         let deleteButton = document.createElement('button');
         deleteButton.className = 'btn delete';
         deleteButton.textContent = 'Delete';
         let archiveButton = document.createElement('button');
         archiveButton.className = 'btn archive';
         archiveButton.textContent = 'Archive';

         divElement.appendChild(deleteButton);
         divElement.appendChild(archiveButton);

         articleElement.appendChild(h1Title);
         articleElement.appendChild(pCategoryElement);
         articleElement.appendChild(pCreatorElement);
         articleElement.appendChild(pContentElement);
         articleElement.appendChild(divElement);
         //---------------------------------------------------------
         archiveButton.addEventListener('click', (e) => {
            let currentSection = e.target.parentElement.parentElement;
            let title = currentSection.children[0].textContent;

            let olElement = archiveSection.children[1];
            let liElement = document.createElement('li');
            liElement.textContent = title;
            olElement.appendChild(liElement);
            let children = Array.from(olElement.children).sort((a,b) => {
               if(a.textContent < b.textContent) return -1;
               if(a.textContent > b.textContent) return 1;
               return 0;
           })
            let parentSection = currentSection.parentElement;
            parentSection.removeChild(currentSection);
            olElement.textContent = '';
            for (const child of children) {
               olElement.appendChild(child);
            }
         })

          deleteButton.addEventListener('click', (e) => {
            let currentSection = e.target.parentElement.parentElement;
            let parentSection = currentSection.parentElement;
            parentSection.removeChild(currentSection);
          })

         postsElement.children[0].children[0].appendChild(articleElement);
      } 
   })
  }
