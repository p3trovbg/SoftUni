function solve() {
   let result = document.querySelector('textarea');
   let liElement = document.createElement('li');
   let allButtons = Array.from(document.querySelectorAll('button'));
   let totalPrice = 0;
   let products = [];
   for (let i = 0; i < allButtons.length - 1; i++) {
      const button = allButtons[i];
      button.addEventListener('click', addEvent);      
   }
   
   let chekout = document.querySelector('.checkout');
   chekout.addEventListener('click', chekoutEvent);

   function addEvent(e) {
      let perent = e.currentTarget.parentElement.parentElement;
         let productName = perent.children[1].children[0].textContent;
         let price = Number(perent.children[3].textContent);
         totalPrice += price;
         products.includes(productName) ? products : products.push(productName); 
         liElement.textContent = `Added ${productName} for ${price.toFixed(2)} to the cart.\n`;
         result.value += liElement.textContent;
   }

   function chekoutEvent(e) {
      allButtons.map(x => x.disabled = 'true');
      result.value += (`You bought ${products.join(', ')} for ${totalPrice.toFixed(2)}.`);
   }
}