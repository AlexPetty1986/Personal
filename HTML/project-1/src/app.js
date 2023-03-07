import {loadJSONFetch} from "./ajax.js";
import "./poke-resultcard.js";
import * as storage from "./localStorage.js";
import { writeCardData } from "./firebase.js";

//UI references
let btnClearAll = null,
    btnSearch = null,
    elementCardHolder = null,
    elementStatus = null,
    pokeName = null,
    fieldLimit = null;

const baseURL = () => `https://pokemon-go1.p.rapidapi.com/pokemon_stats.json`;

//variables
const searchTerm = document.querySelector("#field-mon");
let limitParam;

let pokeList = [];
let pokeMon = [];
let notFound = 0;


const init = () => {
    btnClearAll = document.querySelector("#btn-clear-all");
    btnSearch = document.querySelector("#btn-search");
    elementCardHolder = document.querySelector("#element-card-holder");
    elementStatus = document.querySelector("#element-status-app");
    pokeName = document.querySelector("#field-mon");
    fieldLimit = document.querySelector("#field-limit");

    pokeName.value = storage.getSearch();
    fieldLimit.value = storage.getLimit();
    limitParam = fieldLimit.value;

    if(pokeName.value != "" || limitParam == "All")
    {
        loadJSONFetch(baseURL(), showResults);
    }

    //Event Handlers
    btnSearch.onclick = (evt) => {
        storage.setSearch(searchTerm.value);
        storage.setLimit(limitParam);
        console.log(`downloading ${baseURL()}`);
        loadJSONFetch(baseURL(), showResults);
        evt.target.classList.add("is-loading");
    };

    //clears all cards that have come up
    btnClearAll.onclick = () => {
        elementCardHolder.innerHTML = "";
        elementStatus.innerHTML = "Click the <b>Search</b> button to view Pokémon"
    };

    //limit parameter
    fieldLimit.onchange = (evt) => {
        limitParam = evt.target.value;
    };
};

//adds card to favorites(local storage)
const addToFavorites = (pokeObj) => {
    console.log("** In app.js - Now we can call any method we want to here");
    // TODO: now add this pokemon to favorites
    storage.addFavorite(pokeObj);
    addToCommunity(pokeObj);
    console.log("New favorite added!");
};

//adds card to community (firebase)
const addToCommunity = (pokeObj) => {
    writeCardData(pokeObj.title, pokeObj.form, pokeObj.base_attack,
        pokeObj.base_defense, pokeObj.base_stamina);
    console.log("New community post added!");
}

//creates the cards based on the results
const createResultCards = (array) => {
    let totalCards = 0;
    pokeList.length = 0;
    notFound = 0;
    elementCardHolder.innerHTML = "";

    //if limit param is set to all
    if(limitParam == "All" )
    {
        //if there is no search term typed in
        if(searchTerm == "")
        {
            //for each pokemon in the array
            for(let poke of array)
            {
                const newCard = document.createElement('poke-resultcard');
                newCard.dataset.title = poke.pokemon_name;
                newCard.dataset.src = poke.src;
                newCard.dataset.form = poke.form;
                newCard.dataset.base_attack = poke.base_attack;
                newCard.dataset.base_defense = poke.base_defense;
                newCard.dataset.base_stamina = poke.base_stamina;
                newCard.callback = addToFavorites;
    
                //for each pokemon in poke list
                for(let copy of pokeList)
                {
                    //if the pokemon already exists in the list
                    if(copy.pokemon_name == poke.pokemon_name && copy.form == poke.form)
                    {
                        return;
                    }
                }
    
                elementCardHolder.appendChild(newCard);
                pokeList.push(poke);
                elementStatus.innerHTML = "A Total of " + pokeList.length + " Pokémon have been found."
            }
        }
        //if there is a search term
        else
        {
            //for each pokemon in the array
            for(let result of array)
            {
                //if a result comes up based on the search term
                if(result.pokemon_name.includes(searchTerm.value) || result.pokemon_name.toLowerCase().includes(searchTerm.value.toLowerCase()) || result.pokemon_name.toUpperCase().includes(searchTerm.value.toUpperCase()))
                {
                    const newCard = document.createElement('poke-resultcard');
                    newCard.dataset.title = result.pokemon_name;
                    newCard.dataset.src = result.value;
                    newCard.dataset.form = result.form;
                    newCard.dataset.base_attack = result.base_attack;
                    newCard.dataset.base_defense = result.base_defense;
                    newCard.dataset.base_stamina = result.base_stamina;
                    newCard.callback = addToFavorites;

                    //for each pokemon in poke list
                    for(let copy of pokeList)
                    {
                        //if the pokemon already exists in the list
                        if(copy.pokemon_name == result.pokemon_name && copy.form == result.form)
                        {
                            return;
                        }
                    }

                    elementCardHolder.appendChild(newCard);
                    pokeList.push(result);
                    elementStatus.innerHTML = "A Total of " + pokeList.length + " Pokémon have been found."
                }
            }
        }
    }

    //if there is a search term and it is not set to all
    else if(searchTerm.value != "" && limitParam != "All")
    {
        //for each pokemon in the array
        for(let result of array)
        {
            //if a result comes up based on the search term
            if(result.pokemon_name.includes(searchTerm.value) || result.pokemon_name.toLowerCase().includes(searchTerm.value.toLowerCase()) || result.pokemon_name.toUpperCase().includes(searchTerm.value.toUpperCase()))
            {
                const newCard = document.createElement('poke-resultcard');
                newCard.dataset.title = result.pokemon_name;
                newCard.dataset.src = result.value;
                newCard.dataset.form = result.form;
                newCard.dataset.base_attack = result.base_attack;
                newCard.dataset.base_defense = result.base_defense;
                newCard.dataset.base_stamina = result.base_stamina;
                newCard.callback = addToFavorites;

                //for each pokemon in poke list
                for(let copy of pokeList)
                {
                    //if the pokemon already exists in the list
                    if(copy.pokemon_name == result.pokemon_name && copy.form == result.form)
                    {
                        return;
                    }
                }

                elementCardHolder.appendChild(newCard);
                pokeList.push(result);
                totalCards++;
                elementStatus.innerHTML = "A Total of " + totalCards + " Pokémon have been found."
            }

            //if the search term does not match with something in the array
            else if(!result.pokemon_name.includes(searchTerm.value) || !result.pokemon_name.toLowerCase().includes(searchTerm.value.toLowerCase()) || !result.pokemon_name.toUpperCase().includes(searchTerm.value.toUpperCase()))
            {
                notFound++;
            }

            //if all cards are loaded
            if(totalCards >= limitParam)
            {
                break;
            }

            //if your search term did nor match with anything in the array
            if(notFound >= array.length)
            {
                elementCardHolder.innerHTML = `<div class="box">No results found! :-(</div>`;
                elementStatus.innerHTML = "A Total of 0 Pokémon have been found."
            }
        }
    }

    //if you don't type in a search term and the limit is not all
    else if(searchTerm.value == "" && limitParam != "All")
    {
        elementStatus.innerHTML = "Why don't you try and enter something in first?"
    }
};

//shows the results that were found
const showResults = (evt) => {
    btnSearch.classList.remove("is-loading");
    const jsonText = evt;

    console.log(jsonText);

    let json;
    try{
        json = jsonText;
    }catch(err){
        console.log(`ERROR: ${err}`);
        elementCardHolder.innerHTML = `<div class="box">There was some kind of error!</div>`;
        return;
    }

    const results = Object.keys(json);

    for(let key of results)
    {
        let poke = json[key];
        pokeMon.push(poke);
    }

    if(pokeMon && Array.isArray(pokeMon) && pokeMon.length > 0)
    {
        console.log(results);
        createResultCards(pokeMon);
    }
    else
    {
        elementCardHolder.innerHTML = `<div class="box">No results found! :-(</div>`;
    }
};

init();