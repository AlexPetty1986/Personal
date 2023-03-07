let words1 = [];
let words2 = [];
let words3 = [];
loadXmlXHR();
init();

function init()
{	
    //document.querySelector("#my-button").onclick = generate;
    document.querySelector("#my-button").addEventListener("click", function(){generateTechno(1)});

    //document.querySelector("#my-five").onclick = generateFive;
    document.querySelector("#my-five").addEventListener("click", function(){generateTechno(5)});
}

function loadXmlXHR()
{
    const url = "data/babble-data.json";
    const xhr = new XMLHttpRequest();
    xhr.onload = (e) => {
        console.log(`In onload - HTTP Status Code = ${e.target.status}`);
        const json = JSON.parse(e.target.responseText);

        const keys = Object.keys(json);
        
        const firstBab = json[keys[0]].wordlist;
        const secondBab = json[keys[1]].wordlist;
        const thirdBab = json[keys[2]].wordlist;

        words1 = firstBab;
        words2 = secondBab;
        words3 = thirdBab;
        generateTechno(1);
    };

    xhr.onerror = e => console.log(`In onerror - HTTP Status Code = ${e.target.status}`);
    xhr.open("GET", url);
    xhr.send();
}

function randomElement(array)
{
    return array[Math.floor(Math.random() * array.length)];
}

function generateTechno(phraseTotal)
{
    let str = "";

    for(let i = 0; i < phraseTotal; i++)
    {
        str += `${randomElement(words1)} ${randomElement(words2)} ${randomElement(words3)} <br>`;
    }

    document.querySelector("#output").innerHTML = str;
}