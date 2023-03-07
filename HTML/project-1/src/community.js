import "./firebase.js"
import "./poke-communcard.js";
import { getDatabase, ref, onValue } from  "./firebase.js"

const elementCardHolder = document.querySelector("#element-card-holder-community");

const communityChanged = (snapshot) => {
    snapshot.forEach(community => {
      const childData = community.val();
      const newCard = document.createElement("poke-communcard");
      newCard.dataset.title = childData.title;
      newCard.dataset.form = childData.form;
      newCard.dataset.base_attack = childData.attack;
      newCard.dataset.base_defense = childData.defense;
      newCard.dataset.base_stamina = childData.stamina;
      newCard.dataset.likes = childData.likes;
      elementCardHolder.appendChild(newCard);
    });
}
  
const init = () => {
  const db = getDatabase();
  const communRef = ref(db, "pokecards");
  onValue(communRef, communityChanged);
  //communityUse();
}
  
  init();