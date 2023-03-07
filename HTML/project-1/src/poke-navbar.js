const template = document.createElement("template");
template.innerHTML = `
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-iBBXm8fW90+nuLcSKlbmrPcLa0OT92xO1BIsZ+ywDWZCvqsWgccV3gFoRBv0z+8dLJgyAHIhR35VZc2oM/gI1w==" crossorigin="anonymous" referrerpolicy="no-referrer">
<nav class="navbar has-shadow is-white">
    <!-- logo / brand -->
    <div class="navbar-brand">
      <a class="navbar-item" href="home.html">
        <i class="fas fa-solid fa-dragon"></i>
      </a>
      <a class="navbar-burger" id="burger">
        <span></span>
        <span></span>
        <span></span>
      </a>
    </div>

    <div class="navbar-menu" id="nav-links">
      <div class="navbar-start">
        <a class="navbar-item is-hoverable" id="home" href="home.html">
          Home
        </a>
      
        <a class="navbar-item is-hoverable" id="app" href="app.html">
          App
        </a>
      
        <a class="navbar-item is-hoverable" id="favorites" href="favorites.html">
          Favorites
        </a>

        <a class="navbar-item is-hoverable" id="community" href="community.html">
          Community
        </a>
      
        <a class="navbar-item is-hoverable" id="documentation" href="documentation.html">
          Documentation
        </a>
      </div> <!-- end navbar-start -->
    </div>
</nav>`;

class PokeNav extends HTMLElement
{
    constructor(){
        super();
        this.attachShadow({mode: "open"});
        this.shadowRoot.appendChild(template.content.cloneNode(true));
    }

    connectedCallback()
    {
        //mobile menu
        this.burgerIcon = this.shadowRoot.querySelector('#burger');
        this.navbarMenu = this.shadowRoot.querySelector('#nav-links');

        this.burgerIcon.addEventListener('click', () => {
            this.navbarMenu.classList.toggle('is-active');
        });

        const currentPageData = this.getAttribute("current-page");
        let currentPage = this.shadowRoot.querySelector(`#${currentPageData}`);
        currentPage.className = "navbar-item has-text-weight-bold";
        currentPage.style = "pointer-events: none";
    }
}

customElements.define('poke-navbar', PokeNav);