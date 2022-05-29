import { createIdeaRequest } from "../api/data.js";
import { e } from "../api/domCreator.js";

let createPage = document.querySelector('#create');
let form = createPage.querySelector('form');

let ctx = '';
export async function createView(context) {
    ctx = context;
    context.showSection(createPage);
}

form.addEventListener('submit', async(e) => {
    e.preventDefault();
    let formData = new FormData(e.target);
    let title = formData.get('title').trim();
    let description = formData.get('description').trim();
    let img = formData.get('imageURL').trim();
    
    if(!title || !description || !img) {
        alert('You should fill all fields to create new idea!');
        return;
    }

    await createIdeaRequest({title, description, img});
    e.target.reset();
    ctx.goTo('/dashboard');
})

export function createIdea(idea) {
    const result = 
    e('div', { id: idea._id ,className: 'card overflow-hidden current-card details', width: '20rem', height: '18rem'},
        e('div', {className: 'card-body'},
            e('p', {className: 'card-text'}, idea.title)),
        e('img', {className: 'card-image', src: idea.img, alt: "Card image cap"}),
        e('a', {id:'detailBtn',className: 'btn', href: "/details"}, 'Details'));
    return result;
}

export function createDetails(idea) {

    let userToken = sessionStorage.getItem('userToken');
    let isOwner = true;
    if(userToken == null) {
        isOwner = false;
    } else {
        let token = JSON.parse(userToken);
        if(idea._ownerId !== token._id) {
            isOwner = false;
        }
    }

    let result = 
    e('div', {},
        e('img', {className: 'det-img', src: idea.img}),
        e('div', {className: 'desc'},
            e('h2', {className: 'display-5'}, idea.title),
            e('p', {className: 'infoType'}, 'Description:'),
            e('p', {className: "idea-description"}, idea.description)));
    
    if(isOwner) {
        result.appendChild(
            e('div', {className: "text-center"},
                e('a', {className: 'btn detb', href: '/delete'}, 'Delete'))
                );
    }
    return result;
}