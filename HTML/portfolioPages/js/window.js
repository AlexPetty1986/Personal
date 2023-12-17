//Load up projects section on loadup of page
window.onload = () =>{
    projectLoad = document.querySelector("#projects");
    //Web Based Programs
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingOne">
            <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
            Web-Based Programs
            </button>
        </h1>
        <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><h3 style="text-align: center; color: white;">Click the Project Title to Test it Out</h3><div id="project1" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
              <button type="button" data-bs-target="#project1" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
              <button type="button" data-bs-target="#project1" data-bs-slide-to="1" aria-label="Slide 2"></button>
              <button type="button" data-bs-target="#project1" data-bs-slide-to="2" aria-label="Slide 3"></button>
                <button type="button" data-bs-target="#project1" data-bs-slide-to="3" aria-label="Slide 4"></button>
                    <button type="button" data-bs-target="#project1" data-bs-slide-to="4" aria-label="Slide 5"></button>
                        <button type="button" data-bs-target="#project1" data-bs-slide-to="5" aria-label="Slide 6"></button>
            </div>
            <div class="carousel-inner">
              <div class="carousel-item active">
                <img src="./HTML/portfolioPages/media/webProj1.webp" alt="RandomPhrases" id="webImg1"/>
                <a href="./HTML/randPhrase/random-phrases.html" target="_blank" rel="noopener noreferrer"><h2>Random Phrase Generator</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning web" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#webInfo1" aria-expanded="false" aria-controls="webInfo1">
                      Information
                    </button>
                </p>
                <div class="collapse" id="webInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This is one of my homework assignments, a webpage that will print out a random phrase every time the button is pressed or the page is reset.  I decided to choose the video game character Gex from, "Gex," because he has some funny quotes.
                        <br><br>Technologies used: Query Selector, innerHTML, Slice, on Change, Parent Elements, Javascript
                        <br><br>Role in Project: My role in this project was getting it work based on the instructions provided, while we were given an example on what the project was supposed to look like, we had to design everything one our own.
                        <br><br>What I learned: What I learned during this was what Javascript can do.  How much it can change the way a web page works, which was astounding to see after working with it.
                        <br><br>Challenges: I do think I had any challenges when it came to the coding of this assignment.  I think the most challenge I has is choosing the character for the site.</p>
                    </div>
                </div>
                <br><br>
              </div>
              <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/webProj2.webp" alt="GifFinder" id="webImg2"/>
                <a href="./HTML/project2/project2.html" target="_blank" rel="noopener noreferrer"><h2>Gif Locator</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning web" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#webInfo2" aria-expanded="false" aria-controls="webInfo2">
                      Information
                    </button>
                </p>
                <div class="collapse" id="webInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This was a project that I had worked on for a class.  This was originally a homework assignment but I decided to try and modify it and make it better than it originally was.  Using a GIPHY API key I was able to pull gifs from the GIPHY website and have them display on the webpage.  When a user types in the specified gifs they want to looks up, like a dog or fish.  The search will then be used to search up what you are looking for and then load them up on the web page.  There is an option to load in more or less gifs on the page by pushing the buttons at the bottom.  If you hover over the gifs with your mouse they will get bigger in size, allowing to view them much more easily.  Also, you can copy the gif url to your clipboard by clicking the button right above the image, with the rating and a direct link to the GIPHY page right above it.
                        <br><br>Technologies used: Copy to Clipboard, Using user input to look something up, saving something to local storage, load in more or less images, Javascript
                        <br><br>Role in Project: My role in this project was trying to get the Gif FInder to be different form what it had originally looked like.  This meant adding in new stuff, changing the layout and design of certain things like the search bar and the title.  
                        <br><br>What I learned: I learned during this assignment how much much Javascript can affect a webpage, while it would not be my first time using Javascript, due to having many other assignments before it that relied heavily on Javascript, it still astounds me.
                        <br><br>Challenges: The main challenges I had was what new things I would add into the Gif FInder to make it different from the original assignment.</p>
                    </div>
                </div>
                <br><br>
              </div>
              <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/webProj3.webp" alt="AlienDefender!" id="webImg3"/>
                <a href="./HTML/project3/game.html" target="_blank" rel="noopener noreferrer"><h2>Alien Defender!</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning web" id="3" type="button" data-bs-toggle="collapse" data-bs-target="#webInfo3" aria-expanded="false" aria-controls="webInfo3">
                      Information
                    </button>
                </p>
                <div class="collapse" id="webInfo3">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This was another project I had worked on, an updated version of one of my homework assignments that was known as Circle Blast!  I decided to modify and try to make it different from the source material.  One of the main differences is that you are able to choose between four different ships, each one having a different way of firing.  There are also two new aliens that were not in the original assignment, as well as your high score being stored in local storage.
                            <br><br>Technologies used: Classes, pushing objects, Scenes, Howl, PIXI, Sprites, Local Storage, Javascript
                            <br><br>Role in Project: My role in this project was getting the game to be as unique as possible, make it as different as possible from the assignment it was based on.
                            <br><br>What I learned: What I learned during this assignment was how much I have grown from when I first learned Javascript.  While I definitely still have mroe to learn, I think that my skills with Javascript have grown.
                            <br><br>Challenges: The main challenge that I had for this assignment was figuring out how to change the sprite depending on what button you pressed.  For some time, I had been unable to figure that out, with the last sprite loaded in always being the one used.  I was able to solve this issue though by removing the default ship from the game scene, that being the first ship.  I would then use a function to load in a new ship with the new ship sprite.  I also used these same functions to change the firing types of each ship.</p>
                    </div>
                </div>
                <br><br>
              </div>
              <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/webProj4.webp" alt="PokeFinder" id="webImg4"/>
                <a href="./HTML/project-1/home.html" target="_blank" rel="noopener noreferrer"><h2>PokéFinder</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning web" id="4" type="button" data-bs-toggle="collapse" data-bs-target="#webInfo4" aria-expanded="false" aria-controls="webInfo4">
                      Information
                    </button>
                </p>
                <div class="collapse" id="webInfo4">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This was a project I had worked on during my time learning about Web Applications, a webpage that uses an API to print out cards onto the page.  The particular API I had used was a Pokemon GO API, I had chose this one because it is based around the series that I know well.
                        <br><br>Technologies used: FireBase, Local Storage, API, Bulma
                        <br><br>Role in Project: My role for this project was to create a page that produces cards based on the information collected from the API.  We were provided multiple options when it came to the APi we used, each one having different data as well as format style, making it intriguing to figure out how to get that data to print onto the screen correctly.
                        <br><br>What I learned: During the time I had put into working on this project I had learned a lot on how FireBase works, which was interesting to find out.  I had also learned more on the different ways APIs set up data, with some giving you different sections of data with each one in the form of a JSON, or just a singlular JSON file with all of the information needed.
                        <br><br>Challenges: The main challenge I had when it came to this project was getting the information form the JSON file stored within the API.</p>
                    </div>
                </div>
                <br><br>
              </div>
              <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/webProj5.webp" alt="RetroAudio" id="webImg5"/>
                <a href="./HTML/project-2/home.html" target="_blank" rel="noopener noreferrer"><h2>Retro Audio Visualizer</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning web" id="5" type="button" data-bs-toggle="collapse" data-bs-target="#webInfo5" aria-expanded="false" aria-controls="webInfo5">
                      Information
                    </button>
                </p>
                <div class="collapse" id="webInfo5">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This was my final project that I had created for the Web Applications course I had taken, an Audio Visualizer that uses Audio to manipulate the drawing that is present on the canvas.  
                        <br><br>Technologies used: Canvas, Audio and Video Elements, Manipulating Canvas using Audio
                        <br><br>Role in Project: I was tasked in creating something using canvas, an HTML element that allows the user to draw graphics onto the web page.  Using one of my past assignments, an audio visualizer, I modified to make it as different as possible to the original assignment.  This includes changing the overall design of the visualizer, changing the music to match with the new aesthetic, to even adding in brand new elements, like having video play through the canvas element.
                        <br><br>What I learned: During this project I had learned how to make a video element play through a canvas element, mkaing it possible to have the video be affected by the filters created using canvas.
                        <br><br>Challenges: The main challenge that I had with this project was figuring out how to make it as different to the original assignement as possible.</p>
                    </div>
                </div>
                <br><br>
              </div>
              <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/webProj6.webp" alt="HerosQuest" id="webImg6"/>
                <a href="./HTML/HeroQuest/HerosQuest.html" target="_blank" rel="noopener noreferrer"><h2>Hero's Quest</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning web" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#webInfo6" aria-expanded="false" aria-controls="webInfo6">
                      Information
                    </button>
                </p>
                <div class="collapse" id="webInfo6">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: Journey through the castle of the Demon Lord to save the land you call home.  Find secrets, uncover clues and discover the truth behid it all.  Do your best to unlock all of the endings. 
                        <br><br>Technologies used: Javascript, Twine, If Statements, CSS, HTML, Audio Elements, User Input, Branching Paths
                        <br><br>Role in Project: The purpose of this project was to create a text-based game where the player gets to choose what there choices.  
                        <br><br>What I learned: Throughout the course of this project I learned more about how Twine works and how I could use it to create stories in the way I wanted to.
                        <br><br>Challenges: The main challenges came with figuring out what the story will be and how I would like it progress and then end.  This also includes the mechanics I wanted to add to make it even more interesting.</p>
                    </div>
                </div>
                <br><br>
              </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project1" data-bs-slide="prev" onclick="closeInfo('web');">
              <span class="carousel-control-prev-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project1" data-bs-slide="next" onclick="closeInfo('web');">
              <span class="carousel-control-next-icon" aria-hidden="true"></span>
              <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //C++ Programs
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingTwo">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
            C++ Programs
            </button>
        </h1>
        <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><div id="project2" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project2" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project2" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#project2" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <img src="./HTML/portfolioPages/media/plusProj1.webp" alt="Register" id="plusImg1"/>
                <h2 style="text-align: center; color: black;">Cash Register</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning plus" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#plusInfo1" aria-expanded="false" aria-controls="plusInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="plusInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: The player is shown a variety of items and their current stock of each.  They will input the number associated with the item and then be asked how many they would like to purchase.  After they chose the item and quantity, the screen will print out the price before tax, the tax and then the sum of the two showing the final price of the purchase.  They will then be asked if they would like to buy another item, yes continues the code while no exits it.
                        <br><br>Technologies used: While Loops, If Statements, User Input, Objects/Object Arrays
                        <br><br>Role in Project: My task was setting up an array that took object variables, those being the items and their quantity and prices, then printing them out on the screen.  After this getting user input to determine what item they want to buy and how many they want.
                        <br><br>What I learned: During this assignment I learned how to create object variables and then store them into an array.
                        <br><br>Challenges: The warning challenge of this was creating the object variable itself, due to this being the first time I had worked with them.</p>                        
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/plusProj2.webp" alt="stackQueue" id="plusImg2"/>
                <h2 style="text-align: center; color: black;">Stack/Queue</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning plus" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#plusInfo2" aria-expanded="false" aria-controls="plusInfo2">
                        Information
                    </button>
                </p>
                <div class="collapse" id="plusInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This is two different programs, the first one replicates how a stack works, where variables are pushed(added) in from the front of the stack and the last variable in the stack is popped(removed).  While the other replicates how a queue works, where variables are queued(added) in to the front of the queue and the variable at the front of the queue is dequeued(removed).  The queue program also sorts the values in the queue from least to greatest.
                        <br><br>Technologies used: Push/Queue, Pop/Dequeue, Template Classes, Pointers, Arrays
                        <br><br>Role in Project: My task for both of these programs was to replicate how a stack and a queue function.  That includes being able to add values to the front of the stack/queue and remove from the back of the stack and the front of the queue.
                        <br><br>What I learned: I learned the inner machinations of both a stack and a queue.
                        <br><br>Challenges: The warning challenge between the two programs was getting the pop/dequeue methods working, mainly due to having to worry about the program crashing because the size of the array that the items are stored in has become too small.</p>
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/plusProj3.webp" alt="GravitySnake" id="plusImg3" style="height: 50%; width: 80%;"/>
                <h2 style="text-align: center; color: black;">Gravity Snake!</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning plus" id="3" type="button" data-bs-toggle="collapse" data-bs-target="#plusInfo3" aria-expanded="false" aria-controls="plusInfo3">
                        Information
                    </button>
                </p>
                <div class="collapse" id="plusInfo3">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This is Gravity Snake, a game that has a similar game loop to the game Snake.  The main difference being that you have full control of what way you are going, so you are able to go in any direction you want.  You goal is to collect the five circles in the shortest amount of key-presses possible.
                        <br><br>Technologies used: Box2D, SFML, Keyboard Input, Random/Time
                        <br><br>Role in Project: My task was creating a Graphical version of a previous assignment, also know as Gravity Snake.  The original Gravity Snake consisted of only the coordinates of both the target and the snake, all in text in the output window.
                        <br><br>What I learned: During this I had learned how to work with Box2D, the engine used to create the visuals for the game as well as the physics for the square that the player plays as.
                        <br><br>Challenges: The challenge working on this was working with Box2D, since this was the first time I had worked with the engine.</p>
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project2" data-bs-slide="prev" onclick="closeInfo('plus');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project2" data-bs-slide="next" onclick="closeInfo('plus');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //C# Programs
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingThree">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
            C# Programs
            </button>
        </h1>
        <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><div id="project3" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project3" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project3" data-bs-slide-to="1" aria-label="Slide 2"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <center><video src="./HTML/portfolioPages/media/sharpProj1.webm" id="sharpImg1" width="40%" muted></video></center>
                <h2 style="text-align: center; color: black;">LiveWire</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning plus" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#sharpInfo1" aria-expanded="false" aria-controls="sharpInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="sharpInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: You play as a tiny little robot, whose task is to lgiht the world back up after it has gone dark.  Get to the end of the level while using your trusty wire to power generators to create platforms and remove obstacles to help you advance.  Play through six levels to test your skill in platforming and if you want to test your skill, try and beat the extra level that playtesters struggled to beat.
                        <br><br>Technologies used: Enumerations, Player Input, Abstract Classes, File IO, MonoGame, Parent/Child Classes, Finite State Machine, SortedList, Vector2, Coyote Frames
                        <br><br>Role in Project: My task in this project was designing the levels using the sprite sheets we created.  I did this by creatign the level layouts in text files that would be sent into the program and choose the correct sprites based on that.  I also was in charge of debugging and lcoating any issues that arose in the code.
                        <br><br>What I learned: During this project I leanred what it was like to work on a program/game in a team environment as well as how to coordinate between members so that work would be done efficiently.
                        <br><br>Challenges: The warning challenge when working on this project was figuring out how some things would work, like the wire that the robot carries around as well as the generators that would activate or deactivate the platforms.</p>                        
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/sharpProj2.webp" alt="" id="sharpInfo2"/>
                <h2 style="text-align: center; color: black;">Player Battle</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning plus" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#sharpInfo2" aria-expanded="false" aria-controls="sharpInfo2">
                        Information
                    </button>
                </p>
                <div class="collapse" id="sharpInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This program is a simulation of a battle between four different character with two having the class of swordsmans while the other two had the class of archer.  The four characters would fight each other in a round based format, with the winner being the last one standing.
                        <br><br>Technologies used: Classes, Inheritance, Override Methods, While Loops
                        <br><br>Role in Project: My task for this assignment was to create another class besides the original one I made, that being the swordsman.  I then needed to set it up so that they would fight each other till there was only one left.
                        <br><br>What I learned: During this assignment I learned more about how class inheritance works in C# and how multiple classes can inherit from the same one.
                        <br><br>Challenges: The warning challenge was getting the four characters hit random targets and not themselves,  I also had to come up with ideas on how to make the two classes balanced so one wasn;t better than the other.</p>
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project3" data-bs-slide="prev" onclick="closeInfo('plus');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project3" data-bs-slide="next" onclick="closeInfo('plus');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //Python Programs
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingFour">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour" aria-expanded="false" aria-controls="collapseThree">
            Python Programs
            </button>
        </h1>
        <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingFour" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><h3 style="text-align: center; color: white;">Code recreated in Javascript</h3><div id="project4" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project4" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project4" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#project4" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <center><section id="adventureWindow">You are in the Front Yard! There is a door to the North(N).<br>0</section><br>
                <button onclick="Adventure(adventInput.value), adventInput.value=''">Confirm Input</button><input id="adventInput" type="text" placeholder="What Direction?"></center>
                <h2 style="text-align: center; color: black;">Mansion Adventure</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning python" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#pythonInfo1" aria-expanded="false" aria-controls="pythonInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="pythonInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: A python program/game using arrays and while loops to simulate a text based game where you are exploring different rooms of a mansion.  Typing in a letter representing one of the cardinal directions allows you to keep exploring, or run into a wall.  Type anything else and you might be ridiculed.
                            <br><br>Technologies used: Arrays, Append, While Loops, User Input
                            <br><br>Role in Assignment: My role was to make it possible to change rooms based on the users current location.  If they were in one room, they would only be able to enter rooms that are adjacent to them.
                            <br><br>What I learned: I learned how to use while loops, as well as see how helpful they are in keeping a program in motion and not having it stop.
                            <br><br>Challenges: The challenge when working on this was figuring out how to change what rooms you are able to enter based on your current location.</p>                                   
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <center><div id="camelWindow">Welcome to Legend of Zelda: Dungeon Crawler!
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
                <br>(q) Quit</div><br>
                    <button onclick="Camel(camelInput.value), camelInput.value=''">Confirm Input</button><input id="camelInput" type="text" placeholder="What will you do?"></center>
                <h2 style="text-align: center; color: black;">Legend of Zelda: Dungeon Crawler</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning python" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#pythonInfo2" aria-expanded="false" aria-controls="pythonInfo2">
                        Information
                    </button>
                </p>
                <div class="collapse" id="pythonInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: A python program/game that plays like a Camel Game, where you must reach the end before you are either caught by whatever is chasing you or from exhaustion or dehydration.  The spin on this one is that is based on the Legend of Zelda series, with you playing as Link while you are being chased through a dungeon by Dark Link.
                        <br><br>Technologies used: While Loops, If/Else If Statements, Random, Boolean Values
                        <br><br>Role in Assignment: My role while working on this was to create a game that plays similarily, while also adding to it seem different.
                        <br><br>What I learned: I learned how to expand my usage of user input, making it possible to ask for different kinds of inputs, especially ones that would not affect what the user is doing. 
                        <br><br>Challenges: The challenges that I had with this was balancing the game.  I don't want the player to die of dehydration or exhaustion after just a couple of turns.  I also don't want Dark Link to reach the player after a certain amount of time either.</p>                
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <center><section id="quizWindow">True or False:<br>
                The Yato from Fire Emblem: Fates has the most forms in the series.<br>(a) True<br>(b) False</section><br>
                <button onclick="Quiz(quizInput.value), quizInput.value=''">Confirm Input</button><input id="quizInput" type="text" placeholder="Your Choice?"></center>
                <h2 style="text-align: center; color: black;">Video Game Quiz Show</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning python" id="3" type="button" data-bs-toggle="collapse" data-bs-target="#pythonInfo3" aria-expanded="false" aria-controls="pythonInfo3">
                        Information
                    </button>
                </p>
                <div class="collapse" id="pythonInfo3">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: A python program that quizzes the user on their video game knowledge.  Each answer they get right will reward them with points, getting it wrong results in losing points.
                        <br><br>Technologies used: If/Else If Statements, User Input
                        <br><br>Role in Assignment: My role was to create a program that takes in user input and is used in if statements, while also being fun at the same time.
                        <br><br>What I learned: I was able to understand how to use user input to affect if statements.
                        <br><br>Challenges: The warning challenge was figuring out what kinds of questions I wanted to ask.</p>
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project4" data-bs-slide="prev" onclick="closeInfo('python');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project4" data-bs-slide="next" onclick="closeInfo('python');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //Assembly Language Programs
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingFive">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFive" aria-expanded="false" aria-controls="collapseThree">
            Assembly Language Programs
            </button>
        </h1>
        <div id="collapseFive" class="accordion-collapse collapse" aria-labelledby="headingFive" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><div id="project5" class="carousel carousel-dark slide">
            <h1 style="text-align: center;">Assembly Language Programs</h1>
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project5" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project5" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#project5" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <img src="./HTML/portfolioPages/media/aslangProj1.webp" alt="AddCount" id="langImg1"/>
                <h2 style="text-align: center; color: black;">Add Count</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning assembly" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#langInfo1" aria-expanded="false" aria-controls="langInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="langInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: This program will continuously add numbers inputted by the user until -1 is typed in.  It will print the total sum of all numbers used as well as how many numbers were used in total, not including the variable the user uses to quit the program.
                        <br><br>Technologies used: While Loops, User Input, Addition, Printing to Screen, Storing Values in Variables
                        <br><br>Role in Assignment: My role in this assignment was to get the integers to add up, not including the integer the user will put in to quit the program.
                        <br><br>What I learned: I learned during my work on this assignment how to constantly change the user input and add it to the final count by using a while loop to keep prompting the user for values.
                        <br><br>Challenges: The primary challenge when working on this assignment was figuring out how assembly language works since it was my first time using it.</p>                       
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/aslangProj2.webp" alt="Largest" id="langImg2"/>
                <h2 style="text-align: center; color: black;">Find Largest</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning assembly" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#langInfo2" aria-expanded="false" aria-controls="langInfo2">
                        Information
                    </button>
                </p>
                <div class="collapse" id="langInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: The program will prompt the user for three numbers, once that is done it will determine which of the 3 is the largest number.  It will then prompt the user asking them if they want to keep going or quit.
                        <br><br>Technologies used: User Input, If Statements, While Loops, Storing Values in Variables
                        <br><br>Role in Assignment: My role in this assignment was getting the code to compare three different integers to see which of the three is the largest.
                        <br><br>What I learned: I figured out how to compare different variables using if statements, then modify another variables using the statement itself.
                        <br><br>Challenges: The challenge was comparing the three values the user was inputting.  There would be times where after the first value compared itself with the second value it would not compare with the final value.</p>
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/aslangProj3.webp" alt="SumAvg" id="langImg3" style="height: 50%; width: 80%;"/>
                <h2 style="text-align: center; color: black;">Sum & Average</h2>
                <p style="text-align: center;">
                    <button class="btn btn-warning assembly" id="3" type="button" data-bs-toggle="collapse" data-bs-target="#langInfo3" aria-expanded="false" aria-controls="langInfo3">
                        Information
                    </button>
                </p>
                <div class="collapse" id="langInfo3">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: The user will be prompted to input three different integer values.  Once they have inputted them, the program will print out the total sum as well as the average of the sum rounded to the nearest integer.
                        <br><br>Technologies used: User Input, Addition, Division, Storing Values in Variables
                        <br><br>Role in Assignment: I was tasked with getting the total sum and rounded average of the three numbers inputted by the user.
                        <br><br>What I learned: This assignment I learned how to modify a variable using other variables, these ones being the ones inputted by the user themselves.
                        <br><br>Challenges: The warning challenge was getting the average to figure out whether to round up or down depending on the actual total.</p>
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project5" data-bs-slide="prev" onclick="closeInfo('assembly');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project5" data-bs-slide="next" onclick="closeInfo('assembly');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //Unity Programs
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingSix">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSix" aria-expanded="false" aria-controls="collapseThree">
            Unity Programs
            </button>
        </h1>
        <div id="collapseSix" class="accordion-collapse collapse" aria-labelledby="headingSix" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><div id="project6" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project6" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project6" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#project6" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <img src="./HTML/portfolioPages/media/unityProj1.webp" alt="Agents" style="display: block;">
                <a href="./Unity/docs/builds/project_2/index.html"><h2>Invasion of the Demon King</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning unity" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#unityInfo1" aria-expanded="false" aria-controls="pythonInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="unityInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: A Unity Program where you watch members of the Demon King's Army attack and convert residents of the Kingdom into their ranks.  Interact with the game by pressing the buttons found at the top of the screen to spawn in more characters, delete them all from the environment as well as randomize the boulders that act as obstacles.  But that is not the only thing you can do, you can also click on the present characters to either cure them or curse them, changing what side they are aligned with.
                            <br><br>Technologies used: Class Inheritance, Buttons, Arrays, Agents, Arrays, Sprites,
                            <br><br>Role in Assignment: My role was to create a simulation or game using the classes we had created, that being the Agent classes, which give the characters their traits like chasing and hiding from certain characters, and expand on it.
                            <br><br>What I learned: I learned more about how Agents work in Unity as well as how to modify them so that their behavior changes based on key criteria in the code.
                            <br><br>Challenges: The main challenge for this was when it came to implementing the new Agent classes and how they would work, as well as figuring out how to get the Agents to be interactible with a mouse.</p>                                   
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/unityProj1.webp" alt="Agents" style="display: block;">
                <a href="./Unity/docs/builds/project_2/index.html"><h2>Invasion of the Demon King</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning unity" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#unityInfo1" aria-expanded="false" aria-controls="pythonInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="unityInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: A Unity Program where you watch members of the Demon King's Army attack and convert residents of the Kingdom into their ranks.  Interact with the game by pressing the buttons found at the top of the screen to spawn in more characters, delete them all from the environment as well as randomize the boulders that act as obstacles.  But that is not the only thing you can do, you can also click on the present characters to either cure them or curse them, changing what side they are aligned with.
                            <br><br>Technologies used: Class Inheritance, Buttons, Arrays, Agents, Arrays, Sprites,
                            <br><br>Role in Assignment: My role was to create a simulation or game using the classes we had created, that being the Agent classes, which give the characters their traits like chasing and hiding from certain characters, and expand on it.
                            <br><br>What I learned: I learned more about how Agents work in Unity as well as how to modify them so that their behavior changes based on key criteria in the code.
                            <br><br>Challenges: The main challenge for this was when it came to implementing the new Agent classes and how they would work, as well as figuring out how to get the Agents to be interactible with a mouse.</p>                                   
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/unityProj1.webp" alt="Agents" style="display: block;">
                <a href="./Unity/docs/builds/project_2/index.html"><h2>Invasion of the Demon King</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning unity" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#unityInfo1" aria-expanded="false" aria-controls="pythonInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="unityInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: A Unity Program where you watch members of the Demon King's Army attack and convert residents of the Kingdom into their ranks.  Interact with the game by pressing the buttons found at the top of the screen to spawn in more characters, delete them all from the environment as well as randomize the boulders that act as obstacles.  But that is not the only thing you can do, you can also click on the present characters to either cure them or curse them, changing what side they are aligned with.
                            <br><br>Technologies used: Class Inheritance, Buttons, Arrays, Agents, Arrays, Sprites,
                            <br><br>Role in Assignment: My role was to create a simulation or game using the classes we had created, that being the Agent classes, which give the characters their traits like chasing and hiding from certain characters, and expand on it.
                            <br><br>What I learned: I learned more about how Agents work in Unity as well as how to modify them so that their behavior changes based on key criteria in the code.
                            <br><br>Challenges: The main challenge for this was when it came to implementing the new Agent classes and how they would work, as well as figuring out how to get the Agents to be interactible with a mouse.</p>                                   
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project6" data-bs-slide="prev" onclick="closeInfo('unity');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project6" data-bs-slide="next" onclick="closeInfo('unity');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //Levels
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingSeven">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseSeven" aria-expanded="false" aria-controls="collapseThree">
            Created Levels
            </button>
        </h1>
        <div id="collapseSeven" class="accordion-collapse collapse" aria-labelledby="headingSeven" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><div id="project7" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project7" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project7" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#project7" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <img src="./HTML/portfolioPages/media/levelProj1.webp" alt="reversePyramid" id="levelImg1"/>
                <a href="https://steamcommunity.com/sharedfiles/filedetails/?id=2948309685" target="_blank" rel="noopener noreferrer"><h2>Reverse Pyramid</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning level" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#levelInfo1" aria-expanded="false" aria-controls="levelInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="levelInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: Uh-oh, looks like Wheatley got a hold of a book about Ancient Egypt and was fascinated by the pyramids. Sadly, he read the whole book upside-down, built it the wrong way. Reach the top(bottom?) of the pyramid and escape.
                        <br><br>Technologies used: Button, Pedestal Button, Faith Plate, Light Bridge, Laser Field, Fizzler, Cube Button, Goo, Angled Panel, Glass Panel, Tractor Beam, Turret, Laser Emitter, Reflector Cube, Reflector Cube Dropper, Stairs, Glass, Speed Gel, Conversion Gel, Bounce Gel, Piston Platform, Sphere Button, Edgeless Safety Cube, Edgeless Safety Cube Dropper, Laser Relay
                        <br><br>Role in Assignment: My role was to create a puzzle level in a 3D environment, that environment being the game, "Portal 2".  I wanted to create something that had challenge to it, but not be too difficult that players found it frustrating to play.  That is when I came up with the idea of the level, have the level start out small, then get bigger and a little more challenging as you progressed through the pyramid.
                        <br><br>What I learned: During this project I learned what it was like to work on a level in 3D.  Compered to levels created in a 2D environment, levels created in 3D have a lot more work needed to be put into it due to the new perspective as well as the addition of the z-axis.  This also ended up with the napkin sketch being a lot more important.
                        <br><br>Challenges: The challenge when it came to working on this was figuring out how to make sure that the segments of the level were increasing in difficulty while still being fair.  This took a lot of trial and error as well as relying on feedback I received during playtests.</p>                       
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/levelProj2.webp" alt="yourChoice" id="levelImg2"/>
                <a href="https://steamcommunity.com/sharedfiles/filedetails/?id=2930262886" target="_blank" rel="noopener noreferrer"><h2>Your Choice</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning level" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#levelInfo2" aria-expanded="false" aria-controls="levelInfo2">
                        Information
                    </button>
                </p>
                <div class="collapse" id="levelInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: Seems the cats have decided to mix up the level, this time letting you pick what path you take to continue forward. Have they decided to go easy on you, or are they just looking for a more twisted form of entertainment?
                        <br><br>Technologies used: Classic Maps, Sticky Blocks, Lasers, Moving Platforms, Springs, Collectibles, Goal Post, Lava, Ice Blocks, Pushing Blocks, Light Platforms, Saw Blades, Exploding Platforms
                        <br><br>Role in Assignment: My role was I had to create a 2D platformer level in the game, "BattleBlock Theater," making it possible for me to get used to creating levels.  I wanted to create a level that allowed the player to choose how they progressed, this is how I ended up coming up with the idea of the splitting paths.  I wanted to add another set of split paths but did not have enough room to put them in, so I stuck with two and added a final jump challenge at the end.
                        <br><br>What I learned: What I learned during this assignment was how to create a level, this being the first one I created for the class.  I also learned the work that goes into creating a level, from the rough sketch of the level I wanted to create to the restrictions that appear once you start working on the level to the final product.
                        <br><br>Challenges: The primary challenge was adjusting the level so that it would fit into the max level size the game allows.  My original sketch was too big for the game so I had to downsize it, makingme choose what parts of the original design I wanted to keep and what ones I wanted to remove.</p>
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <center><iframe width="1058" height="595" src="https://www.youtube.com/embed/t8RlMCYCS8g" title="Antigen - Quake 1 Level" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share" allowfullscreen></iframe></center>
                <h6 style="text-align: center; color:white;">Click the level name to download the WAD file of the map!</h6>
                <a href="./HTML/portfolioPages/media/antigen.zip" target="_blank" rel="noopener noreferrer"><h2>Antigen</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning level" id="3" type="button" data-bs-toggle="collapse" data-bs-target="#levelInfo3" aria-expanded="false" aria-controls="levelInfo3">
                        Information
                    </button>
                </p>
                <div class="collapse" id="levelInfo3">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Description: Welcome to Antigen Prison, one of the most secure prisons in hell.  You have been captured by demons, hoping to torture you for the rest of eternity.  While in your cell, someone drops you an axe and shotgun, then your cell door opens.  Determined to make your way out fo the prison, you get ready to fight the hordes of demons that guard the prison.
                        <br><br>Technologies used: Quake Engine, Enemy/Enemy Placement, Locked Doors/Keys, Secrets, Powerups, Weapons, Ammo/Health/Armor, Start/End Positions
                        <br><br>Role in Assignment: My role for this assignment was to create a level for an FPS game of my choice.  While we were recommended to use Half-Life 2 due to it being one of the easier games to work with as well as gain some knowledge on the Hammer Engine, I wanted to work on Quake and learn more about the Quake Engine.
                        <br><br>What I learned: During the time I worked on my level I learned more about the Quake Engine and how it works.  I feel if I were to go back and try and create another level, I would have a much easier time.
                        <br><br>Challenges: The primary challenge was trying to learn how Quake Engine works.  Since I had no experience working with it before, it was a long task to learn the functions of the engine before I could start on my level.</p>
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project7" data-bs-slide="prev" onclick="closeInfo('level');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project7" data-bs-slide="next" onclick="closeInfo('level');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div>`
    //Internships
    projectLoad.innerHTML += `
    <div class="accordion-item">
        <h1 class="accordion-header" id="headingEight">
            <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseEight" aria-expanded="false" aria-controls="collapseEight">
            Internships
            </button>
        </h1>
        <div id="collapseEight" class="accordion-collapse collapse" aria-labelledby="headingEight" data-bs-parent="#projects">
            <div class="accordion-body">
            <strong><div id="project8" class="carousel carousel-dark slide">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#project8" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#project8" data-bs-slide-to="1" aria-label="Slide 2"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                <img src="./HTML/portfolioPages/media/internProj1.webp" alt="reversePyramid" id="internImg1"/>
                <a href="https://www.arkheproject.org/" target="_blank" rel="noopener noreferrer"><h2>Arkhé</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning intern" id="1" type="button" data-bs-toggle="collapse" data-bs-target="#internInfo1" aria-expanded="false" aria-controls="internInfo1">
                        Information
                    </button>
                </p>
                <div class="collapse" id="internInfo1">
                    <div class="card card-body" style="color: black; margin: 10px;">
                        <p>Job Description: Help create an experiment with tangible digital interactions for participants in the form of the typical American living room using a variety of embedded sensors, computer vision, and functional programming.
                        <br><br>Job Title: Debug Technician
                        <br><br>Technologies used: Python, OpenCV, Redis, Heroku, Teamwork, Software Development, Debugging
                        <br><br>What I learned: I ended up learning a lot more about Python and what you could do with it, like OpenCV.  I also learned how to set up stuff like Heroku, a cloud platform for websites and apps and Redis, a program that lets you modify code in real time and see the changes.  I also was able to improve my skills in debugging code.
                        <br><br>Challenges: The primary challenges that came up when working during the internship was figuring out how to get certain things working.  The team I was a part of came up with multiple ideas but had a hard time coming up with the best option.  After a while though we were able to settle on an idea and was able to continue our progress on the assignment we were given.                
                    </div>
                </div>
                <br><br>
                </div>
                <div class="carousel-item">
                <img src="./HTML/portfolioPages/media/internProj2.webp" alt="yourChoice" id="internImg2"/>
                <a href="https://www.changelingvr.com/" target="_blank" rel="noopener noreferrer"><h2>Changeling VR</h2></a>
                <p style="text-align: center;">
                    <button class="btn btn-warning intern" id="2" type="button" data-bs-toggle="collapse" data-bs-target="#internInfo2" aria-expanded="false" aria-controls="internInfo2">
                        Information
                    </button>
                </p>
                <div class="collapse" id="internInfo2">
                    <div class="card card-body" style="color: black; margin: 10px;">
                    <p>Job Description: Continue to work on the ongoing development of a VR mystery game in Unreal Engine titled Changeling VR, Virtual Reality (VR) narrative mystery game for an independent studio.
                    <br><br>Job Title: Game Developer/Level Designer
                    <br><br>Technologies used: Unreal Engine 4, Unreal Engine Blueprints, Game Design, Level Design, 3D Models, Perforce
                    <br><br>What I learned: Before the internship my knowledge on Unreal Engine was very limited due to only using it for a singular course.  I now have a much better understanding of how it works.
                    <br><br>Challenges: The main challenge that came up during the internship was fixing any issues that I found.  Since multiple different groups of people have worked on it over the years, there will always be something that might have been missed or they could not fix it.  Since I had limited skill in Unreal Engine at the start of the internship it was challenging.  But over time I had a better understanding of Unreal Engine and was able to fix all of the issues I came across. 
                    </div>
                </div>
                <br><br>
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#project8" data-bs-slide="prev" onclick="closeInfo('intern');">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#project8" data-bs-slide="next" onclick="closeInfo('intern');">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
            </div>
        </div>
    </div><br>`
}