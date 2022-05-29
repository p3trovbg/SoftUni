import { contacts } from "./contacts.js";
import { render } from "lit-html";
import { articleTempalte } from "../template.js";

startUp();

function startUp() {
    onRender();
}

function onRender() {
    let section = document.querySelector('#contacts');
    render(contacts.map(c => articleTempalte(c, onDetails)), section);   
}

function onDetails(contact) {
    contact.details = !contact.details;
    onRender();
    }