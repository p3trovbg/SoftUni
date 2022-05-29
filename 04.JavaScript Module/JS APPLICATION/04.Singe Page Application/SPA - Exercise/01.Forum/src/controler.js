import { appendTopic } from './appendElement.js';
import { loadTopic } from './loadTopic.js'
export {container , form};

let form = document.querySelector('#home form');
let container = document.querySelector('.topic-container');

export function addTopic() {
    appendTopic()
}

export function loadHome() {
    loadTopic();
}

export function showContent() {
    container.addEventListener('click', async(e) => {
        e.stopImmediatePropagation();
        if(e.target.className == 'columns')
        {
            let element = e.target.parentElement.parentElement;
            let comment = element.querySelector('.comment');
            if (comment.style.display == 'flex') {
                comment.style.display = 'none';
            } else {
                comment.style.display = 'flex';
            }
            
        }
    })
}