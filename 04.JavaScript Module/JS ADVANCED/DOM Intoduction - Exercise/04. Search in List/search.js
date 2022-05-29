function search() {
   let searchWord = document.getElementById('searchText').value;
   let father = document.getElementById('towns');
   let children = Array.from(father.children);
   let searchTown = children
         .filter(x => x.textContent.includes(searchWord))
         .map(function(x, i) {
            x.style.fontWeight = "bold";
            x.style.textDecoration = "underline";
         });
         
   let result = document.getElementById('result');
   result.textContent = `${searchTown.length} matches found`;
   
}
