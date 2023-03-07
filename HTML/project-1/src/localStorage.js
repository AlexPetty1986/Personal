/* Checked by ESLint - https://eslint.org/demo */
const defaultData = {
  "favorites": [],
  "search": "",
  "limit": "1"
},

//local storage key
storeName = "ap8180-p1-settings";

//reads local storage
const readLocalStorage = () => {
  let allValues = null;

  try{
    allValues = JSON.parse(localStorage.getItem(storeName)) || defaultData;
  }catch(err){
    console.log(`Problem with JSON.parse() and ${storeName} !`);
    throw err;
  }

  return allValues;
};

//writes values to local storage
const writeLocalStorage = (allValues) => {
  localStorage.setItem(storeName, JSON.stringify(allValues));
};

//clears local storage
export const clearLocalStorage = () => writeLocalStorage(defaultData);

//add favorites to local storage
export const addFavorite = (obj) => {
  const allValues = readLocalStorage();
  allValues.favorites.push(obj);
  writeLocalStorage(allValues);
};

//gets favorites from local storage
export const getFavorites = () => readLocalStorage().favorites;

export const removeFavorite = (obj) => {
  const allValues = readLocalStorage();
  const changeValues = allValues.favorites;
  for(let i = 0; i < allValues.favorites.length; i++)
  {
      if(changeValues[i].title == obj.title && changeValues[i].form == obj.form)
      {
        changeValues.splice(i, 1);
        break;
      }
  }
  allValues.favorites = changeValues;
  writeLocalStorage(allValues);
}

//clears favorites from local storage
export const clearFavorites = () => {
  const allValues = readLocalStorage();
  allValues.favorites = [];
  writeLocalStorage(allValues);
};

//saves limit
export const setLimit = (str) => {
  const allValues = readLocalStorage();
  allValues.limit = str;
  console.log(allValues);
  writeLocalStorage(allValues);
}

//gets limit
export const getLimit = () => readLocalStorage().limit;

//saves search term
export const setSearch = (str) => {
  const allValues = readLocalStorage();
  allValues.search = str;
  writeLocalStorage(allValues);
}

//gets search term
export const getSearch = () => readLocalStorage().search;
