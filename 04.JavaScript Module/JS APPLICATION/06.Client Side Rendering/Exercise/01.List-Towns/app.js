import {html, render} from '../lit-html/lit-html.js';

start();
function start() {
    let rootSection = document.querySelector('#root');
    document.querySelector('form').addEventListener('submit', (e) => {
        e.preventDefault();
        let formData = new FormData(e.target);
        let towns = Array.from(formData.get('towns').split(', '));
        
        render(listTamplate(towns), rootSection);
    })
}


function listTamplate(data) {
    return html`
             <ul>
                ${data.map(i => html`
                <li>${i}</li>`)}
            </ul>
    `
}
