const template = document.createElement("template");

template.innerHTML = `
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-iBBXm8fW90+nuLcSKlbmrPcLa0OT92xO1BIsZ+ywDWZCvqsWgccV3gFoRBv0z+8dLJgyAHIhR35VZc2oM/gI1w==" crossorigin="anonymous" referrerpolicy="no-referrer">
<style>
    #image-main{
        border:1px solid black;
        background-color:white;
        padding:7px;
        box-shadow: 1px 1px 2px #333;
        margin:.1rem;
        width:300px;
        align-content: center;
    }
    #title::first-letter{
        text-transform:capitalize;
    }

    .card{
        height:450x;
        overflow: auto;
    }

    @media (max-width: 700px){
        span{
            font-size: 25px;
        }
    }
</style>
<div class="card">
    <div class="card-header-title is-size-4">
        <i class="fas fa-solid fa-dragon mr-3"></i>
        <span id="title">???</span>
    </div>

    <div class="control has-text-centered">
        <button 
            id="btn-remove" 
            class="button is-danger is-responsive" 
            title="Remove Pokemon">Remove Me!
        </button>
    </div>

    <div class="card-content">
        <div class="card-image has-text-centered">
            <figure class="image is-inline-block">
                <img id="image-main" src ="https://bulma.io/images/placeholders/1280x960.png" alt"Placeholder image">
            </figure>
        </div>
        <br>
        <span class="has-text-weight-bold">Form: </span><span id="form">???</span>
        <br>
        <span class="has-text-weight-bold">Base Attack: </span><span id="base_attack">???</span>
        <br>
        <span class="has-text-weight-bold">Base Defense: </span><span id="base_defense">???</span>
        <br>
        <span class="has-text-weight-bold">Base Stamina: </span><span id="base_stamina">???</span>
        <br>
    </div>
</div>
`;

class PokemonResultCard extends HTMLElement
{
    static defaultImage = "https://cdn.pixilart.com/photos/large/a672c7ce2caaf4f.png";

    constructor()
    {
        super();
        this.attachShadow({"mode": "open"});
        this.shadowRoot.appendChild(template.content.cloneNode(true));
    }

    connectedCallback()
    {
        this.shadowRoot.querySelector("#title").innerHTML = this.dataset.title;
        this.shadowRoot.querySelector("#image-main").src = PokemonResultCard.defaultImage;;
        this.shadowRoot.querySelector("#form").innerHTML = this.dataset.form;
        this.shadowRoot.querySelector("#base_attack").innerHTML = this.dataset.base_attack;
        this.shadowRoot.querySelector("#base_defense").innerHTML = this.dataset.base_defense;
        this.shadowRoot.querySelector("#base_stamina").innerHTML = this.dataset.base_stamina;
    
        this.btnRemove = this.shadowRoot.querySelector("#btn-remove");

        this.callback = this.callback || ((obj) => console.log(`Name: ${obj.name}, src: ${obj.src}`));
        this.btnRemove.onclick = () => {
            const dataObj = {
                "title": this.dataset.title,
                "src": this.dataset.src,
                "form": this.dataset.form,
                "base_attack": this.dataset.base_attack,
                "base_defense": this.dataset.base_defense,
                "base_stamina": this.dataset.base_stamina
            };
            this.callback(dataObj);
        };
    }
}

customElements.define('poke-favcard', PokemonResultCard);