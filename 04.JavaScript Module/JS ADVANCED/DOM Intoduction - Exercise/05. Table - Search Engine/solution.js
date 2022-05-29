function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      let info = document.getElementById('searchField').value;
      let trElements = document.getElementsByTagName('tbody')[0].children;
      const arr = Array.from(trElements);
      document.getElementById('searchField').value = '';
      for (const element of arr) {
            element.classList.remove('select');
      }

      for (const element of arr) {
         if(element.textContent.includes(info)) {
            element.classList.add('select');
         }
      }
   }
}