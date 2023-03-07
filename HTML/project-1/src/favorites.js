/* Checked by ESLint - https://eslint.org/demo */
import * as storage from "./localStorage.js";
import "./poke-favcard.js";

//UI references
let favorites = storage.getFavorites();
let elementCardHolder = null, 
    btnClear = null,
    elementStatus = null;

//initializes the page
const init = () => {
  elementCardHolder = document.querySelector("#element-card-holder-fav")
  btnClear = document.querySelector("#btn-clear-storage");
  elementStatus = document.querySelector("#element-status");

  createResultCards(favorites);
  showTotal(favorites);

  //removes all favorties from the page
  btnClear.onclick = () => {
    storage.clearFavorites();
    elementCardHolder.innerHTML = "";
    elementStatus.innerHTML = "You have no Pokémon saved as favorites...try favoriting some!"
  };

  window.onstorage = () => {
    createResultCards(favorites);
    showTotal(favorites);
  }
};

//removes a card from the favorites page
const removeCard = (pokeObj) => {
  storage.removeFavorite(pokeObj);
  favorites = storage.getFavorites();
  createResultCards(favorites);
  showTotal(favorites);
};

//create the favorites cards
const createResultCards = (array) => {
  elementCardHolder.innerHTML = "";

  //for each item in the array
  for(let i = array.length; i > 0; i--)
  {
    const newCard = document.createElement("poke-favcard");
    newCard.dataset.title = array[i-1].title;
    newCard.dataset.src = array[i-1].src;
    newCard.dataset.form = array[i-1].form;
    newCard.dataset.base_attack = array[i-1].base_attack;
    newCard.dataset.base_defense = array[i-1].base_defense;
    newCard.dataset.base_stamina = array[i-1].base_stamina;
    newCard.callback = removeCard;

    elementCardHolder.appendChild(newCard);
  }
};

//displays the total amount of cards in the favorites
const showTotal = (array) => {
  //if there are any cards
  if(array.length >= 1)
  {
    elementStatus.innerHTML = "You have " + array.length + " Pokémon saved as favorites!"
  }
  //if there aren't any
  else
  {
    elementStatus.innerHTML = "You have no Pokémon saved as favorites...try favoriting some!"
  }
};

init();