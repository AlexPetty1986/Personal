const template = document.createElement("template");
template.innerHTML = `
<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bulma@0.9.3/css/bulma.min.css" />
<link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.3/css/all.min.css" integrity="sha512-iBBXm8fW90+nuLcSKlbmrPcLa0OT92xO1BIsZ+ywDWZCvqsWgccV3gFoRBv0z+8dLJgyAHIhR35VZc2oM/gI1w==" crossorigin="anonymous" referrerpolicy="no-referrer">
<style>
    .navbar{
        background-color: rgb(46, 46, 46);
        color: rgb(128, 0, 0)
        box-sizing: border-box;
        top: 0;
        position: sticky;
        z-index: 10px;
    }
    
    .navbar a{
        color: rgb(165, 46, 46);
        margin: 10px;
        font-size: 20px;
    }
</style>
<nav class="navbar fixed-top">
    <!-- logo / brand -->
    <div class="navbar-brand">
      <a class="navbar-item" href="index.html">
        <i class="fas fa-gamepad"></i>
      </a>
      <a class="navbar-burger" id="burger">
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
      </a>
    </div>

    <div class="navbar-menu" id="nav-links">
      <div class="navbar-start">
        <a class="navbar-item is-hoverable" id="home" href="index.html">
          Home
        </a>
      
        <a class="navbar-item is-hoverable" id="about" href="#about">
          About
        </a>
      
        <a class="navbar-item is-hoverable" id="project" href="#projects">
          Projects
        </a>

        <a class="navbar-item is-hoverable" id="contact" href="#contact">
          Contact
        </a>

        <a class="navbar-item is-hoverable" id="resume" href="./HTML/portfolioPages/media/AlexanderPettyResume.pdf" target="_blank" rel="noopener noreferrer">
          Resume
        </a>
      </div> <!-- end navbar-start -->
    </div>
</nav>`;

class PortNav extends HTMLElement
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

customElements.define('port-nav', PortNav);