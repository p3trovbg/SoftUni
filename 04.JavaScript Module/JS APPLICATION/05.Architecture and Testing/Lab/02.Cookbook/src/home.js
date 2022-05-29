import { showDetails } from './details.js';
import { showCatalog } from './catalog.js';

let main;
let section;
let setActiveNav;
export function setupHome(targetMain, targetSection, onActiveNav) {
    main = targetMain;
    section = targetSection;
    setActiveNav = onActiveNav;
}

export async function showHome() {
    setActiveNav('/home');
    section.innerHTML = 'Loading&hellip;';
    main.innerHTML = '';
    main.appendChild(section);

    const recipes = await getRecipes();
    const cards = recipes.map(createRecipePreview);

    const fragment = document.createDocumentFragment();
    fragment.appendChild(e('div', {className: 'hero'},
                            e('h2', {}, 'Welcome to My Cookbook')));
    fragment.appendChild(e('header', {className: 'section-title'}, 'Recently added recipes'));
    fragment.appendChild(e('div', {className: 'recent-recipes'}));
    cards.forEach(c => fragment.appendChild(c));
    fragment.appendChild(e('footer', {className: 'section-title'}, 
                            e('p'), {}, 'Browse all recipes in the',
                                e('a'), {onClick: () => showCatalog()}, 'Catalog'));
    section.replaceChildren(fragment);
}


async function getRecipes() {
    const response = await fetch('http://localhost:3030/data/recipes?select=_id%2Cname%2Cimg&sortBy=_createdOn%20desc&pageSize=3');
    const recipes = await response.json();

    return recipes;
}

function createRecipePreview(recipe) {
    let element = 
    e('article', {className: 'recent', onClick: () => showDetails(recipe._id)},
        e('div', {className: 'recent-preview'},
            e('img', {src: recipe.img})),
        e('div', {className: 'recent-title'}, recipe.title));

    return element;                    
}