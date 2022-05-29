function notify(message) {
 let noticationElement = document.getElementById('notification');
 noticationElement.textContent = message;
 noticationElement.style.display = 'block';
 noticationElement.addEventListener('click', (e) => {
   e.target.style.display = 'none';
 })
}