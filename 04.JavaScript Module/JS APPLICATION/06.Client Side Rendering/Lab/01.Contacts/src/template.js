import { html } from "lit-html";
import { styleMap } from 'lit-html/directives/style-map';

export function articleTempalte(data, onDetails) {
      return html`
        <div class="contact card">
            <div>
                <i class="far fa-user-circle gravatar"></i>
            </div>
            <div class="info">
                <h2>Name: ${data.name}</h2>
                <button class="detailsBtn" @click=${() => onDetails(data)}>Details</button>
                <div class="details" id="1" style=${styleMap({display: data.details ? 'block' : 'none'})}>
                    <p>Phone number: ${data.phoneNumber}</p>
                    <p>Email: ${data.email}</p>
                </div>
            </div>
        </div>
      `
}
