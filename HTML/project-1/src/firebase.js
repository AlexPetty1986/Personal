// Import the functions you need from the SDKs you need
import { initializeApp } from "https://www.gstatic.com/firebasejs/9.12.1/firebase-app.js";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
const firebaseConfig = {
  apiKey: "AIzaSyDw8RjxoGZiZkuU4H3CVba599FDjTVZAT0",
  authDomain: "poke-card-e2905.firebaseapp.com",
  projectId: "poke-card-e2905",
  storageBucket: "poke-card-e2905.appspot.com",
  messagingSenderId: "651443373099",
  appId: "1:651443373099:web:44f32e0f6df9c5ca2ed66e"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
console.log(app);

import { getDatabase, ref, set, onValue, increment } from  "https://www.gstatic.com/firebasejs/9.12.1/firebase-database.js";

//write card data to fire base
export const writeCardData = (title, form, attack, defense, stamina) => {
  const db = getDatabase();
  set(ref(db, 'pokecards/' + title + " " + form), {
    title,
    form, 
    attack, 
    defense, 
    stamina,
    likes: increment(1)
  });
};

export { getDatabase, ref, onValue };