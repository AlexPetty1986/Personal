const template = document.createElement("template");
template.innerHTML = `
<style>
header{
    color: white;
    background-color: red;
    padding: .2rem;
  }
header h2{
  text-align: center;
  font-size: 60px;
}
header h3{
  text-align: center;
  font-size:25px;
}
</style>
<header>
<h2>PokéFinder</h2>
<h3>Do you wanna be a master of Pokémon?</h3>
</header>`;

class Header extends HTMLElement
{
  constructor()
  {
    super();
    this.attachShadow({mode: "open"});
    this.shadowRoot.appendChild(template.content.cloneNode(true));
  }
}

customElements.define('poke-header', Header);