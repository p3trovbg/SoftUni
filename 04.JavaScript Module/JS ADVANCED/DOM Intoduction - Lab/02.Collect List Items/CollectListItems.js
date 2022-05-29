function extractText() {
   let items = document.getElementById('items');
   let result = document.getElementById('result');
   result.textContent = items.textContent;
}