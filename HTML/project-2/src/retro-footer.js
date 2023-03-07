const template = document.createElement("template");
template.innerHTML = `
<style>
*{
  font-family: 'Press Start 2P', cursive;
  margin-top: 20px;
}
footer{
    color: black;
    background-color: rgba(45,145,143,255);
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
<h4>&copyCAPCOM CO., LTD. ALL RIGHTS RESERVED, &copy1988 Nintendo Co., Ltd., &copySEGA. All rights reserved., &copySNK CORPORATION ALL RIGHTS RESERVED, Tetris&#174 & &copy1985~2022 Tetris Holding.</h4>
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

customElements.define('retro-footer', Footer);