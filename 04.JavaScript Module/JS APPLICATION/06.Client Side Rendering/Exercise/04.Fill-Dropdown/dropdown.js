import {render, html} from '../lit-html/lit-html.js';
let menu = document.querySelector('#menu');


load();
async function load() {
    let response = await fetch(`http://localhost:3030/jsonstore/advanced/dropdown`);
    let data = await response.json();
    const options = Object.values(data);
    render(optionTamplate(options), menu);
    document.querySelector('form').addEventListener('submit', addItem)
}

function optionTamplate(options) {
    const result = (options.map(option => html`
        <option value=${option._id}>${option.text}</option>
    `))
    return result;
}

async function addItem(e) {
    e.preventDefault(); 
    let form = new FormData(e.target);
    let text = form.get('option').trim();

    e.target.reset();
    await fetch(`http://localhost:3030/jsonstore/advanced/dropdown`, {
        method: 'post',
        headers: {
            'content-type': 'application/json'
        },
        body: JSON.stringify({text})
    })
    load();
    return;
}