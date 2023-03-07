const template = document.createElement("template");
template.innerHTML = `
<style>
*{
  font-family: 'Press Start 2P', cursive;
}
header{
    color: white;
    background-color: rgba(108,190,113,255);
    padding: .2rem;
  }
header h2{
  text-align: center;
  font-size: 35px;
}
header h3{
  text-align: center;
  font-size:20px;
}
</style>
<header>
<h2>Retro Audio Visualizer</h2>
<h3>Experience A Blast From the Past!</h3>
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

customElements.define('retro-header', Header);