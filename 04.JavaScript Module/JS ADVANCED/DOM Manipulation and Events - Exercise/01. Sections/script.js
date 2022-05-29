function create(words) {

   let output = document.getElementById('content');
   const divs = [];
   for (const word of words) {
      let divElement = document.createElement('div');
      divElement.classList.add("content-div");
      let paragraph = document.createElement('p');
      paragraph.classList.add("content-div-p");
      paragraph.style.display = 'none';
      paragraph.textContent = word;
      divElement.appendChild(paragraph);   
      divs.push(divElement);         
   }

  for (const div of divs) {
     let paragraph = div.children[0];
     output.appendChild(div);
     div.addEventListener('click', (e) => {
        paragraph.style.display = 'inline';
     })
  }
}