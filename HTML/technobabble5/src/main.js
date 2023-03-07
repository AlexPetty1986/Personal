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
    const url = "data/babble-data.xml";
    const xhr = new XMLHttpRequest();
    xhr.onload = (e) => {
        console.log(`In onload - HTTP Status Code = ${e.target.status}`);
        const xml = e.target.responseXML;
        
        const firstBab = xml.querySelector("wordlist[cid='babbleOne']").textContent.split(",");
        const secondBab = xml.querySelector("wordlist[cid='babbleTwo']").textContent.split(",");
        const thirdBab = xml.querySelector("wordlist[cid='babbleThree']").textContent.split(",");

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