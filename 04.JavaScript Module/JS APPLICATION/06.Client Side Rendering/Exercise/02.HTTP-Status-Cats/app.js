//id, statusCode, statusMessage and imageLocation
import {render, html} from '../lit-html/lit-html.js';
import { styleMap } from '../lit-html/directives/style-map.js'
import { cats } from "./catSeeder.js";

let catsSection = document.querySelector('#allCats');
load();
function load() {
    onRender();
}

function onRender() {
    render(catTamplate(cats), catsSection);
}

function onDetails(cat) {
    cat.details = !cat.details;
    onRender();
}


function catTamplate(cats) {
    return html`
    <ul>
        ${cats.map(cat => html`
        <li>
            <img src="${`./images/${cat.imageLocation}.jpg`}" width="250" height="250" alt="Card image cap">
            <div class="info">
                <button class="showBtn" @click=${() => onDetails(cat)}>Show status code</button>
                <div class="status" id="${cat.id}" style=${styleMap({display: cat.details ? 'block' : 'none'})}>
                    <h4>Status Code: ${cat.statusCode}</h4>
                    <p>${cat.statusMessage}</p>
                </div>
            </div>
        </li>`)}
    </ul>
    `
}