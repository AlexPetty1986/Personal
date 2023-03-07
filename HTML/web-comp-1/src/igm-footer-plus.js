// YOUR CODE GOES HERE
const template = document.createElement('template');
    template.innerHTML = `
    <style>
            :host{
                display: block;
                background-color: #ddd
            }

            span{
                color: #F76902;
                font-variant: small-caps;
                font-weight: bolder;
                font-family: sans-serif;
            }
    </style>
    <span></span>
    <span id="org"></span>
    <hr>
    `;

class IGMFooter extends HTMLElement{
    constructor()
    {
    super();

    this.attachShadow({mode: "open"});
    this.shadowRoot.appendChild(template.content.cloneNode(true));

    }

    connectedCallback()
        {
            this.render();
        }

        render()
        {
            const year = this.getAttribute('data-year') ? this.getAttribute('data-year') : "1995";

            const text = this.getAttribute('data-text') ? this.getAttribute('data-text') : "Nobody";

            const organization = this.getAttribute('data-organization') ? this.getAttribute('data-organization') : "RIT";

            this.shadowRoot.querySelector("span").innerHTML = `&copy; Copyright ${year}, ${text},`;
            this.shadowRoot.querySelector("#org").innerHTML = `Organization: ${organization}`;
        }
} 
    
customElements.define('igm-footer', IGMFooter);