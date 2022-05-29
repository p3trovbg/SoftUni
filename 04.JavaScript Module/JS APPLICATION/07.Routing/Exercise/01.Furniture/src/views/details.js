import { getFurnitureById, deleteFurnitureById } from "../api/data.js";
import { getToken } from "../api/userStorage.js";
import { html, styleMap } from "../library.js";

const detailsTemplate = (furnitureObj, isOwner) => html`
<div class="row space-top">
            <div class="col-md-12">
                <h1>Furniture Details</h1>
            </div>
        </div>
        <div class="row space-top">
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                    <img src="${furnitureObj.img}" />
                    </div>
                </div>
            </div>
            <div class="col-md-4">
                ${html`
                <p>Make: <span>${furnitureObj.make}</span></p>
                <p>Model: <span>${furnitureObj.model}</span></p>
                <p>Year: <span>${furnitureObj.year}</span></p>
                <p>Description: <span>${furnitureObj.description}</span></p>
                <p>Price: <span>${furnitureObj.price}</span></p>
                <p>Material: <span>${furnitureObj.material}</span></p>
                <div style=${styleMap({display: isOwner ? 'block' : 'none'})}>
                    <a href=${`/details/edit/${furnitureObj._id}`} class="btn btn-info">Edit</a>
                    <a href=${`/details/delete/${furnitureObj._id}`} class="btn btn-red">Delete</a>
                </div>
                `}
            </div>
        </div>
`


export async function detailsView(ctx) {
    let currentFurn = await getFurnitureById(ctx.params.id);
    let token = getToken();
    let isOwner;
    if(token) {
        token = JSON.parse(token);
         token._id === currentFurn._ownerId ? isOwner = true : isOwner = false; 
    }
    ctx.render(detailsTemplate(currentFurn, isOwner));
}


export async function deleteFurniture(ctx) {
    await deleteFurnitureById(ctx.params.id);
    ctx.page.redirect('/dashboard');
}