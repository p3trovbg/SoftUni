import { getOwnFurnitures } from "../api/data.js";
import { html } from "../library.js";
import { getToken } from "../api/userStorage.js";

const myFurnitureTempalte = (data) => html`
 <div class="row space-top">
            <div class="col-md-12">
                <h1>My Furniture</h1>
                <p>This is a list of your publications.</p>
            </div>
        </div>
        <div class="row space-top">
            ${data.map(f => html`
            <div class="col-md-4">
                <div class="card text-white bg-primary">
                    <div class="card-body">
                            <img src=${f.img} />
                            <p>Description here</p>
                            <footer>
                                <p>Price: <span>${f.price} $</span></p>
                            </footer>
                            <div>
                                <a href=${`/details/${f._id}`} class="btn btn-info">Details</a>
                            </div>
                    </div>
                </div>
            </div>
            `)}
        </div>
`

export async function ownerFurnitureView(ctx) {
    let token = getToken();
    let furnitures;
    if(token) {
        token = JSON.parse(token);
        furnitures = await getOwnFurnitures(token._id);
        if(furnitures.length == 0) {
            alert('You not have own furnitures!');
            ctx.page.redirect('/dashboard');
            return;
        }
    } else {
        ctx.page.redirect('/dashboard');
        return;
    }

    ctx.render(myFurnitureTempalte(furnitures));
}