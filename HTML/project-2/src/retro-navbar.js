const template = document.createElement("template");
template.innerHTML = `
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-iBBXm8fW90+nuLcSKlbmrPcLa0OT92xO1BIsZ+ywDWZCvqsWgccV3gFoRBv0z+8dLJgyAHIhR35VZc2oM/gI1w==" crossorigin="anonymous" referrerpolicy="no-referrer">
<style>
  .navbar{
    background-color: rgba(246,179,35,255);
    font-family: 'Press Start 2P', cursive; 
  }
</style>
<nav class="navbar">
    <!-- logo / brand -->
    <div class="navbar-brand">
      <a class="navbar-item" href="home.html">
        <i class="fas fa-solid fa-gamepad"></i>
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
      
        <a class="navbar-item is-hoverable" id="documentation" href="documentation.html">
          Documentation
        </a>
      </div> <!-- end navbar-start -->
    </div>
</nav>`;

class RetroNav extends HTMLElement
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

        this.render();
    }

    disconnectedCallback()
    {
        this.burgerIcon.onclick = () => null;
        this.render();
    }

    render()
    {
        const currentPageData = this.getAttribute("current-page");
        let currentPage = this.shadowRoot.querySelector(`#${currentPageData}`);
        currentPage.className = "navbar-item has-text-weight-bold";
        currentPage.style = "pointer-events: none";
        currentPage.removeAttribute("href");
    }
}

customElements.define('retro-nav', RetroNav);