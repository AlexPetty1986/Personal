//variables
let page = 1;

// 2
let displayTerm = "";
const searchURL = [];

// 3
function searchButtonClicked(){
    console.log("searchButtonClicked() called");
}

//4
const prefix = "ap8180-";
const termKey = prefix + "search";
const storedTerm = localStorage.getItem(termKey);

window.onload = () => {
    const searchTerm = document.querySelector("#searchTerm");
    if(storedTerm)
    {
        searchTerm.value = storedTerm;
    }
    else
    {
        searchTerm.value = "dog";
        localStorage.setItem(termKey, searchTerm.value);
    }

    searchTerm.onchange = () =>{ localStorage.setItem(termKey, searchTerm.value); };
}

function searchButtonClicked() 
{
    console.log("searchButtonClicked() called");

    // 1
    const GIPHY_URL = "https://api.giphy.com/v1/gifs/search?";

    // 2
    // Public API key from here: https://developers.giphy.com/docs/
    // If this one no longer works, get your own (it's free!)
    let GIPHY_KEY = "NtA0qceSeY1F8VLodPmYsOfeMHq9TSEy";

    // 3 - build up our URL string
    let url = GIPHY_URL;
    url += "api_key=" + GIPHY_KEY;

    //4 - parse the user entered term we wish to search
    let term = document.querySelector("#searchTerm").value;
    displayTerm = term;

    // 5 - get rid of any leading and trailing spaces
    term = term.trim();

    // 6 - encode spaces and special characters
    term = encodeURIComponent(term);

    // 7 - if there's no term to search then bail out of the function (return does this)
    if(term.length < 1) return;

    // 8 - append the search term to the URL - the parameter name is at
    url += "&q=" + term;

    // 9 - grab the user chosen search "limit" from the <select> and append it to the URL
    let limit = document.querySelector("#limit").value * page;
    url += "&limit=" + limit;

    // 10 - update the UI
    document.querySelector("#status").innerHTML = "<b>Searching for '"
    + displayTerm + "'</b>";

    // 11 - see what the URL looks like
    console.log(url);

    // 12 Request data!
    getData(url);
}

function getData(url)
{
    // 1 - create a new XHR object
    let xhr = new XMLHttpRequest();

    // 2 - set the onload handler
    xhr.onload = dataLoaded;

    // 3 - set the onerror handler
    xhr.onerror = dataError;

    // 4 - open connection and send the request
    xhr.open("GET", url);
    xhr.send();
}

// Callback Functions
function dataLoaded(e)
{
    // 5 - event.target is the xhr object
    let xhr = e.target;

    // 7 - turn the text into a parsable JavaScript object
    let obj = JSON.parse(xhr.responseText);

    // 8 - if there are no results, print a message and return
    if(!obj.data || obj.data.length == 0)
    {
        document.querySelector("#status").innerHTML = "<b>No results found for " + displayTerm + "</b>";
        return; // Bail out
    }
    
    // 9 - Start building an HTML string we will display to the user
    let results = obj.data;
    console.log("results.length + results.length");
    let bigString = "";

    // 10 - loop through the array of results
    for (let i=0;i<results.length;i++)
    {
        let result = results[i];
        searchURL[i] = results[i].embed_url;

        // 11 - get the URL to the GIF
        let smallURL = result.images.fixed_width_downsampled.url;
        if (!smallURL) smallURL = "../images/no-image-found.png";

        // 12 - get the URL to the GIPHY Page
        let url = result.url;

        //12.5 get rating
        let rating = (result.rating ? result.rating : "NA").toUpperCase();

        // 13 - Build a <div> to hold each result
        // ES6 String Templating
        let line = `<div class='result'>`;
        line += `<img src='${smallURL}' title= '${result.id}' />`;
        line += `<span>
        <a target='_blank' href='${url}'>View on Giphy</a>
        <p>Rating: ${rating}</p>
        <button class='red copy'>Copy Image</button>
        </span>`;
        line += `</div>`;

        // 15 - add the <div> to 'bigString and loop
        bigString += line;
    }

        // 16 - all done building the HTML - show it to the user!
        document.querySelector("#content").innerHTML = bigString;

        // 17 update the status
        document.querySelector("#status").innerHTML = "<b>Huzzah! <i> We have found " + results.length + " results for "
        + displayTerm + " gifs</i></b>";

        //copy urls of gifs to copy buttons
        let copyButtons = document.querySelectorAll(".copy");

        //for the total number gifs
        for(let i = 0; i < copyButtons.length; i++)
        {
            //copy the urls to the associated buttons
            copyButtons[i].onclick = (e) => {
                navigator.clipboard.writeText(searchURL[i]);
                alert("Gif Copied!");
              }
        }
}

function dataError(e)
{
    console.log("An error occurred");
}

//loads in more gifs
function loadMore()
{
    page++;
    searchButtonClicked();
}

//lessons the amount of gifs on screen
function loadLess()
{
    page--;
    if(page < 1)
    {
        page = 1;
    }
    
    searchButtonClicked();
}

//resets the page when a new search is done
function resetPage()
{
    document.body.scrollTop = 0;
    document.documentElement.scrollTop = 0;
    if(page != 1)
    {
        page = 1;
    }

    searchButtonClicked();
}