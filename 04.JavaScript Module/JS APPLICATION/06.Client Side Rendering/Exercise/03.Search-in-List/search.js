import { html, render} from '../lit-html/lit-html.js';
import { towns } from './towns.js';
let citySection = document.querySelector('#towns');

load();
function load() {
   render(cityTamplate(towns), citySection);

   document.querySelector('button').addEventListener('click', search);
}


function search() {
   let searchText = document.querySelector('#searchText').value;
   let times = 0;

   citySection.querySelectorAll('li').forEach(city => {
      let cityName = city.textContent;
      city.classList.remove("active");
      if(cityName.includes(searchText)) {
         city.classList.add("active");
         times++;
      }
   });
   document.querySelector('#result').textContent = `${times} matches found`;

}


function cityTamplate(cities) {
   return html`
   <ul>
      ${cities.map(c => html`
      <li>${c}</li>`)}
  </ul>
`
}