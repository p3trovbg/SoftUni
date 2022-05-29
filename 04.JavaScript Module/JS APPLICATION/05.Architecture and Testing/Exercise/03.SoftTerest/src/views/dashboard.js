import { getAllIdeas, getCurrentIdea, removeIdea } from "../api/data.js";
import { createDetails, createIdea } from "./create.js";
import { e } from '../api/domCreator.js';


let dashboardPage = document.querySelector('#dashboard-holder');
let detailsPage = document.querySelector('#details');

let ctx = '';
export async function dashboardView(context) {
    ctx = context;
    const ideas = await getAllIdeas();
    if(ideas.length == 0 || ideas == undefined) {
        dashboardPage.replaceChildren(e('h1',{}, 'No ideas yet! Be the first'));
    } else {
        dashboardPage.replaceChildren(...ideas.map(createIdea));
        context.showSection(dashboardPage);
        
    }
}

dashboardPage.addEventListener('click', showDetails)

async function showDetails(e) {
    let target = e.target;
      if(target.tagName == 'A') {
          e.preventDefault();
      } else {
          return;
      }

let currentId = target.parentElement.id;
let currentIdea = await getCurrentIdea(currentId);
let detail = createDetails(currentIdea);
detailsPage.replaceChildren(detail);

ctx.showSection(detailsPage);

//Delete button
detail.addEventListener('click', async(e) => {
  e.preventDefault();
  let button = e.target;
  if(button.tagName == 'A') {
      e.preventDefault();
      await removeIdea(currentId);
      ctx.goTo('/dashboard');
        }
    })
}