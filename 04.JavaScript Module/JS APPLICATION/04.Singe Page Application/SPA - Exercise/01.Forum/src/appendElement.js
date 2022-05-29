import {createElement} from './createDomElement.js';
//element, textCon, type, className, value, parent
import{container , form} from './controler.js';
import {addTopic} from './addTopic.js';
export function appendTopic() {
    let dataForm = new FormData(form);
    let name = dataForm.get('topicName').trim();
    let username = dataForm.get('username').trim();
    let content = dataForm.get('postText').trim();
    
    addTopic({name, username, content});
    createTopic({name, username, content});
    
}

export function createTopic(objPost) {
    let parent = createElement('div', undefined, undefined, 'topic-name-wrapper', undefined, container);
    createElement('div', undefined, undefined, 'topic-name', undefined, parent);
    createElement('a', undefined, undefined, 'normal', undefined, parent.lastChild);
    createElement('h2', objPost.name, undefined, undefined, undefined, parent.lastChild.lastChild);
    createElement('div', undefined, undefined, 'columns', undefined, parent.lastChild);
    createElement('div', undefined, undefined, undefined, undefined, parent.lastChild.lastChild);
    createElement('p', 'Date: ', undefined, undefined, undefined, parent.lastChild.lastChild.lastChild);
    createElement('time', getTime(), undefined, undefined, undefined, parent.lastChild.lastChild.lastChild.lastChild);
    createElement('div', undefined, undefined, 'nick-name', undefined, parent.lastChild.lastChild.lastChild);
    createElement('p', undefined, undefined, undefined, undefined, parent.lastChild.lastChild.lastChild.lastChild);
    createElement('span', `Username: ${objPost.username}`, undefined, undefined, undefined, parent.lastChild.lastChild.lastChild.lastChild.lastChild);

    let commentParent = createElement('div', undefined, undefined, 'comment', undefined, parent);
    createElement('div', undefined, undefined, 'header', undefined, commentParent);
    createElement('img', undefined, undefined, 'comment', undefined, commentParent.lastChild, './static/profile.png', 'avatar');
    createElement('p', 'posted on: ', undefined, undefined, undefined, commentParent.lastChild);
    createElement('span', undefined, undefined, undefined, undefined, commentParent.lastChild.lastChild);
    createElement('time', getTime(), undefined, undefined, undefined, commentParent.lastChild.lastChild);
    createElement('p', objPost.content, undefined, 'post-content', undefined, commentParent.lastChild);
    commentParent.style.display = 'none';
}

function getTime() {
    let current = new Date();
    let cDate = current.getDate() + '-' + (current.getMonth() + 1) + '-' + current.getFullYear();
    let cTime = current.getHours() + ":" + current.getMinutes() + ":" + current.getSeconds();
    let dateTime = cDate + ' ' + cTime;
    return dateTime;
}