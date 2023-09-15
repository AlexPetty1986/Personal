//variables for Adventure Code
let nextRoom;
let currentRoom = 0;
let roomList = [];
let direction;
let advWindow;

//Recreations of Python examples in the form of JS
function Adventure(userInput)
{
    //Initialize the variables
    currentRoom;
    direction = userInput;
    advWindow = document.getElementById("adventureWindow");

    //Create the arrays of rooms and then store them in the room list array
    room = [null,null,null,null,null];
    room = ["You are in the Front Yard! There is a door to the North(N).",1,null,null,null];
    roomList.push(room);

    room = [null,null,null,null,null];
    room = ["You are in the Main Room! There is a door to the North(N), South(S), East(E), & West(W)",4,2,0,3];
    roomList.push(room);

    room = [null,null,null,null,null];
    room = ["You are at the Demon Altar! There is a door to the North(N) and a door to the West(W).",6,null,null,1];
    roomList.push(room);

    room = [null,null,null,null,null];
    room = ["You are on the Balcony! There is a door to the East(E).",null,1,null,null];
    roomList.push(room);

    room = [null,null,null,null,null];
    room = ["You are in the Family Crypt! The is a door to the South(S) and West(W).",null,null,1,5];
    roomList.push(room);

    room = [null,null,null,null,null];
    room = ["You are in the Guest Room! There is a door to the East(E)",null,4,null,null];
    roomList.push(room);

    room = [null,null,null,null,null];
    room = ["You are in the Devil's Den! there is a door to the South(S).",null,null,2,null];
    roomList.push(room);

    direction = direction.toUpperCase();

    //Check what the input was
    if(direction == "N")
    {
        nextRoom = roomList[currentRoom][1];
        if(nextRoom == null)
        {
            advWindow.innerHTML += "<br>There's no invisible door there pal!<br>^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
        }
        else
        {
            currentRoom = nextRoom;
        }
    }
    else if(direction == "E")
    {
        nextRoom = roomList[currentRoom][2];
        if(nextRoom == null)
        {
            advWindow.innerHTML += "<br>There's no invisible door there pal!<br>^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
        }
        else
        {
            currentRoom = nextRoom;
        }
    }
    else if(direction == "S")
    {
        nextRoom = roomList[currentRoom][3];
        if(nextRoom == null)
        {
            advWindow.innerHTML += "<br>There's no invisible door there pal!<br>^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
        }
        else
        {
            currentRoom = nextRoom;
        }
    }
    else if(direction == "W")
    {
        nextRoom = roomList[currentRoom][4];
        if(nextRoom == null)
        {
            advWindow.innerHTML += "<br>There's no invisible door there pal!<br>^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
        }
        else
        {
            currentRoom = nextRoom;
        }
    }
    else
    {
        advWindow.innerHTML += "<br>What on Earth are you doing?<br>^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^";
    }

    advWindow.innerHTML += ("<br>" + roomList[currentRoom][0] + "<br>" + currentRoom);
}

//variables for Camel Game Code
let disFromExit = 250;
let stamina = 25;
let distFromDarkLink = -30;
let thirst = 0;
let potionBottle = 5;
let camWindow;
let gamePlay = true;

function Camel(userChoice)
{
    let choice = userChoice;

    if(gamePlay == true)
    {
        camWindow = document.getElementById("camelWindow");

        choice = choice.toLowerCase();

        if(choice == "a")
        {
            let meters = Math.floor(Math.random() * 10) + 1;
            if(thirst >= 0)
                thirst++;
            if(stamina <= 25)
                stamina -= Math.floor(Math.random() * 5) + 1
            if(distFromDarkLink >= -30)
                distFromDarkLink += Math.floor(Math.random() * 5) + 1
            if(disFromExit <= 350)
            {
                disFromExit -= meters
            }
            camWindow.innerHTML += "<br>=============================================================<br>You decided to walk at a slow pace and moved " + meters + " meters.<br>=============================================================<br>(a) Walk<br>(b) Run<br>(c) Hide<br>(d) Status<br>(e) Drink<br>(q) Quit" 
        }
        else if(choice == "b")
        {
            let meters = Math.floor(Math.random() * 15) + 5;
            if(thirst >= 0)
                thirst+=2;
            if(stamina <= 25)
                stamina -= Math.floor(Math.random() * 10) + 5
            if(distFromDarkLink >= -30)
                distFromDarkLink += Math.floor(Math.random() * 10) - 8
            if(disFromExit <= 350)
            {
                disFromExit -= meters
            }
            camWindow.innerHTML += "<br>=============================================================<br>You decide not to take any chances and ran " + meters + " meters.<br>=============================================================<br>(a) Walk<br>(b) Run<br>(c) Hide<br>(d) Status<br>(e) Drink<br>(q) Quit" 
        }
        else if(choice == "c")
        {
            if(stamina < 25)
                stamina = 25
            if(distFromDarkLink >= -30)
                distFromDarkLink += Math.floor(Math.random() * 5)
            camWindow.innerHTML += "<br>=============================================================<br>You decide to hide to regain some of your stamina.<br>=============================================================<br>(a) Walk<br>(b) Run<br>(c) Hide<br>(d) Status<br>(e) Drink<br>(q) Quit"
        }
        else if(choice == "d")
        {
            camWindow.innerHTML += "<br>=============================================================<br>Distance From Exit: " + disFromExit + " yards left<br>Stamina: "+  + stamina + "<br>Distance From Dark Link: " + distFromDarkLink + " yards<br>Thirst: " + thirst + "<br>Potion Bottles Left: " + potionBottle + "<br>=============================================================<br>(a) Walk<br>(b) Run<br>(c) Hide<br>(d) Status<br>(e) Drink<br>(q) Quit"
        }
        else if(choice == "e")
        {
            if(potionBottle >= 1)
            {
                thirst = 0;
                potionBottle--;
                camWindow.innerHTML += "<br>=============================================================<br>You decide to drink a potion and now have " + potionBottle +" bottles left." + "<br>=============================================================<br>(a) Walk<br>(b) Run<br>(c) Hide<br>(d) Status<br>(e) Drink<br>(q) Quit"
                if(distFromDarkLink >= -30)
                    distFromDarkLink += Math.floor(Math.random() * 10) + 1;
            }
            else
            {
                camWindow.innerHTML += "<br>=============================================================<br>You have no more potions left!<br>=============================================================<br>(a) Walk<br>(b) Run<br>(c) Hide<br>(d) Status<br>(e) Drink<br>(q) Quit"
            }
        }
        else if(choice == "alex")
        {
            camWindow.innerHTML += "<br>=============================================================<br>You realize you have the Ocarina of Time.  You play you Ocarina and warp out of the dungeom unharmed. Congrats you won the game. (SECRET)<br>=============================================================<br>"
        }
        else if(choice == "q")
        {
            camWindow.innerHTML += "<br>=============================================================<br>What a sore loser!<br>=============================================================<br>"
            gamePlay = false;
        }
        if(stamina >= 0 && stamina <= 10)
        {
            camWindow.innerHTML += "<br>=============================================================<br>You are getting tired!<br>============================================================="
        }
        else if(stamina < 0)
        {
            camWindow.innerHTML += "<br>=============================================================<br>You collapsed from exhaustion!<br>============================================================="
            gamePlay = false;
        }
        if(thirst >= 4 && thirst < 6)
        {
            camWindow.innerHTML += "<br>=============================================================<br>You are getting thirsty!<br>============================================================="
        }
        else if(thirst > 6)
        {
            camWindow.innerHTML += "<br>=============================================================<br>You died from dehydration!<br>============================================================="
            gamePlay = false;
        }
        if(distFromDarkLink >= 0 && distFromDarkLink < 25)
        {
            camWindow.innerHTML += "<br>=============================================================<br>You notice that Dark Link is behind you and closing in!<br>============================================================="
        }
        else if(thirst > 6)
        {
            camWindow.innerHTML += "<br>=============================================================<br>Dark Link has captured you! The return of Ganon is now!<br>============================================================="
            gamePlay = false;
        }
        if(disFromExit <= 0)
        {
            "<br>=============================================================<br>You've escaped the dungeon without getting caught by Dark Link.  But it isn't the last time you will see him.  Congrats you won the game.<br>============================================================="
        }
        if(1 == Math.floor(Math.random() * 10) + 1)
        {
            potionBottle = 5;
            camWindow.innerHTML += "<br>=============================================================<br>You found a cauldron full of potion and decide to refill all of your bottles.<br>============================================================="
        }
    }

    if(choice != 'r' && gamePlay == false)
    {
        camWindow.innerHTML += "<br>=============================================================<br>Enter R to play again.<br>============================================================="
    }
    else if(choice == 'r' && gamePlay == false)
    {
        camWindow.innerHTML = `Welcome to Legend of Zelda: Dungeon Crawler!
        You are Link.
        You've just found a dungeon that is said to have a rare treasure.
        But after walking into the dungeon you're trapped inside.
        While being confronted by your mirror self Dark Link.
        You must find a way to escape without Dark Link killing you.
        <br>(a) Walk
        <br>(b) Run
        <br>(c) Hide
        <br>(d) Status
        <br>(e) Drink
        <br>(q) Quit`
        disFromExit = 250;
        stamina = 25;
        distFromDarkLink = -30;
        thirst = 0;
        potionBottle = 5;
        gamePlay = true;
    }
}

//variables for Quiz Code
let score = 0;
let quizGame = true;
let currentQuestion = -1;
let quizWindow;
let quizQuestion = [`<br>Which of these Limit Breaks is only usable by Cloud?
<br>(a) Final Heaven
<br>(b) Death Gigas
<br>(c) Meteorain
<br>(d) Lunatic High`, `<br>What year did The Legend of Zelda: The Wind Waker come out in the US?`, `<br>Name the character who says this quote: "Your range is one fist short."`, `<br>What is the strongest summon in Golden Sun: Lost Age
and Golden Sun: Dark Dawn?`, `<br>Which of these Legend of Zelda games
did not have the Master Sword?
<br>(a) Phantom Hourglass
<br>(b) Link to the Past
<br>(c) Twilight Princess
<br>(d) Skyward Sword`, `<br>What is the name of the first Limit Break that Squall has in Final Fantasy VIII?`, `<br>Mario's original name was Luigi.
<br>(a) True
<br>(b) False`, `<br>Name this quote said by a character:
<br>"You answered the call of battle.
<br>So I'll give you fight you'll never forget!"`];
let quizAnswer = [['a', `<br>Correct!
<br>Birthright: Noble Yato and Blazing Yato
<br>Conquest: Grim Yato and Shadow Yato
<br>Revelation: Alpha Yato and Omega Yato`], ['c', `<br>Correct!
<br>Final Heaven is used by Tifa, Death Gigas is used by Vincent and Lunatic High is used by Red XIII`], [2003, `<br>Correct!
<br>The Wind Waker would then get a HD remake in 2013
on the Wii U.`], ["ryu", `<br>Correct!
<br>Ryu says this victory taunt in Street Fighter III: Third Strike as well as Super Smash Bros. for the 3DS/Wii U & Ultimate.`] ,["iris", `<br>Correct!
<br>Iris will do massive damage at the cost of
9 Mars and 4 Mercury Djinn. As well has heal the entire party.`], ['a', `<br>Correct!
<br>In Phantom Hourglass Link uses the Phantom Sword to defeat Bellum.`], ["renzokuken", `<br>Correct!
<br>After using the Renzokuken Squall will use one of the four
finishing moves that he knows.`], ['b', `<br>Correct!
<br>Mario's original name was Jump Man.  Luigi is the name of his brother.`], ["ike", `<br>Correct!
<br>Ike will say this after initiating combat with him
in Fire Emblem Fates.`]];

function Quiz(quizChoice)
{
    if(quizGame == true)
    {
        quizWindow = document.getElementById("quizWindow");
        if(quizChoice.toLowerCase() == quizAnswer[currentQuestion + 1][0])
        {
            quizWindow.innerHTML += quizAnswer[currentQuestion + 1][1] + `<br>=============================================================`;
            score += 10;
        }
        else
        {
            quizWindow.innerHTML += "<br>Incorrect!<br>=============================================================";
            score -= 10;
        }
        currentQuestion++;
        if(currentQuestion < quizQuestion.length)
        {
            quizWindow.innerHTML += quizQuestion[currentQuestion]
        }
        else
        {
            quizGame == false;
            quizWindow.innerHTML += `<br>Final Score: ` + score + `<br>=============================================================`
        }
    }

}