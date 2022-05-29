import { addTopic, loadHome, showContent} from './controler.js';

const sections = {
    'public':addTopic,
    'columns': showContent
}

loadHome();

document.addEventListener('click', onNavigation);
 
function onNavigation(e) {
    let element = e.target;
    if(element.tagName == 'BUTTON' || element.tagName == 'DIV') {
        let view = sections[element.className];
        if(typeof view == 'function') {
            e.preventDefault();
            view();
        }
    }
}
