const template = document.createElement("template");
template.innerHTML = `
<style>
footer{
    color: black;
    background-color: red;
    padding: .2rem;
  }
footer h4{
    text-align: left;
    margin-left: 2px;
    color: white;
}
</style>
<footer>
<h4>Contact: ap8180@g.rit.edu</h4>
<h4>&copy2022 Pokémon. &copy1995 - 2022 Nintendo/Creatures Inc./GAME FREAK inc. TM, &regNintendo.</h4>
</footer>`;

class Footer extends HTMLElement
{
  constructor()
  {
    super();
    this.attachShadow({mode: "open"});
    this.shadowRoot.appendChild(template.content.cloneNode(true));
  }
}

customElements.define('poke-footer', Footer);