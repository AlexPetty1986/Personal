// We will use `strict mode`, which helps us by having the browser catch many common JS mistakes
// https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Strict_mode
"use strict";
const app = new PIXI.Application({
    width: 600,
    height: 600
});
document.body.appendChild(app.view);

// constants
const sceneWidth = app.view.width;
const sceneHeight = app.view.height;	

// pre-load the images
app.loader.
    add([
        "images/OneShip.png",
        "images/TriShip.png",
        "images/BackShip.png",
        "images/PierceShip.png",
        "images/explosion.png",
        "images/Alien.png",
        "images/AlienWrap.png",
        "images/AlienSeeker.png"
    ]);
app.loader.onComplete.add(setup);
app.loader.load();

// aliases
let stage;

// game variables
let startScene;
let gameScene, ship, scoreLabel, lifeLabel, roundLabel, gameOverScoreLabel, gameOverHighScoreLabel, 
shootSound, hitSound, fireballSound, levelComplete, gameOverSound, music;
let gameOverScene;

let Aliens = [];
let bullets = [];
let aliens = [];
let explosions = [];
let explosionTextures;
let score;
let highScore;
let life = 5;
let round = 0;
let paused = true;
let singFire = true;
let tripFire = false;
let backFire = false;
let pierceFire = false;
const prefix = "ap8180-";
const scoreKey = prefix + "highScore"
const storedScore = localStorage.getItem(scoreKey);

function setup() 
{
	stage = app.stage;
    score = 0;
    highScore = 0;

    // #1 - Create the start' scene
    startScene = new PIXI.Container();
    stage.addChild(startScene);

    // #2 - Create the main game scene and make it invisible
    gameScene = new PIXI.Container();
    gameScene.visible = false;
    stage.addChild(gameScene);

    // #3 - Create the 'gameOver' scene and make it invisible
    gameOverScene = new PIXI.Container();
    gameOverScene.visible = false;
    stage.addChild(gameOverScene);

    // #4 - Create Labels for all 3 scenes
    createLabelsAndButtons();
	
	// #5 - Create ship
    ship = new Ship(0, 0, "images/OneShip.png");

    gameScene.addChild(ship);
	
	// #6 - Load Sounds
    shootSound = new Howl(
    {
        src: ['sounds/shoot.wav']
    });

    hitSound = new Howl(
    {
        src: ['sounds/hit.wav']
    });

    fireballSound = new Howl(
    {
        src: ['sounds/fireball.wav']
    });

    levelComplete = new Howl(
    {
        src: ['sounds/levelComplete.wav']
    });

    gameOverSound = new Howl(
    {
        src: ['sounds/gameOver.wav']
    });

    music = new Howl(
    {
        src: ['sounds/InterplanetaryOdyssey.mp3']
    });
	
	// #7 - Load sprite sheet
    explosionTextures = loadSpriteSheet();
		
	// #8 - Start update loop
    app.ticker.add(gameLoop);
	
	// #9 - Start listening for click events on the canvas
    app.view.onclick = fireBullet;

    music.loop();
    music.play();
}

//swap to ship 2
function swapShip2()
{
    gameScene.removeChild(ship);
    singFire = false;
    tripFire = true;
    ship = new Ship(0, 0, "images/TriShip.png");
     ship.x = 300;
     ship.y = 550;
    gameScene.addChild(ship);
}

//swap to ship 3
function swapShip3()
{
    gameScene.removeChild(ship);
    singFire = false;
    backFire = true;
    ship = new Ship(0, 0, "images/BackShip.png");
     ship.x = 300;
     ship.y = 550;
    gameScene.addChild(ship);
}

//swap to ship 4
function swapShip4()
{
    gameScene.removeChild(ship);
    singFire = false;
    pierceFire = true;
    ship = new Ship(0, 0, "images/PierceShip.png");
     ship.x = 300;
     ship.y = 550;
    gameScene.addChild(ship);
}

//starts the game
function startGame()
{
    startScene.visible = false;
    gameOverScene.visible = false;
    gameScene.visible = true;
     score = 0;
     life = 5;
     round = 0;
     increaseScoreby(0);
     decreaseLifeBy(0);
     increaseRoundby(1);
     ship.x = 300;
     ship.y = 550;
     loadLevel();
}

//title screen of game
function titleScreen()
{
    startScene.visible = true;
    gameOverScene.visible = false;
    gameScene.visible = false;
}

//increases score
function increaseScoreby(value)
{
    score += value;
    scoreLabel.text = `Score: ${score}`;
}

//increases round count
function increaseRoundby(value)
{
    round += value;
    roundLabel.text = `Round: ${round}`;
}

//descreases live
function decreaseLifeBy(value)
{
    life -= value;
    life = parseInt(life);
    lifeLabel.text = `Lives: ${life}`;
}

//game loop
function gameLoop(){
	if (paused) return;

	// #1 - Calculate "delta time"
    let dt = 1/app.ticker.FPS;
    if (dt > 1/12) dt=1/12;
	
	// #2 - Move Ship
    let mousePosition = app.renderer.plugins.interaction.mouse.global;

    let amt = 6 * dt; //60 fps

    //lerp the x & y values with lerp()
    let newX = lerp(ship.x, mousePosition.x, amt);
    let newY = lerp(ship.y, mousePosition.y, amt);

    //keep the ship on screen using clamp()
    let w2 = ship.width/2;
    let h2 = ship.height/2;
    ship.x = clamp(newX, 0+w2, sceneWidth - w2);
    ship.y = clamp(newY, 0+h2, sceneHeight - h2);

	// #3 - Move Aliens
    for(let a of Aliens)
    {
        a.move(dt);
        if(a.x <= a.width || a.x >= sceneWidth - a.width)
        {
            a.reflectX();
            a.move(dt);
        }

        if(a.y <= a.height || a.y >= sceneHeight - a.height)
        {
            a.reflectY();
            a.move(dt);
        }
    }
		
	// #4 - Move Bullets
	for (let b of bullets)
    {
		b.move(dt);
	}
	
	// #5 - Check for Collisions
    for(let a of Aliens)
    {
        for (let b of bullets) 
        {
            // #5A - Aliens & bullets
            if (rectsIntersect(a,b))
            {
                fireballSound.play();
                createExplosion (a.x, a.y, 70, 64);
                gameScene.removeChild(a);
                a.isAlive = false;

                //ships 1, 2 & 3
                if(!pierceFire)
                {
                    gameScene.removeChild(b);
                    b.isAlive = false;
                }
                increaseScoreby(1);
            }
            
            if (b.y < -10) b.isAlive = false;
        }

        //5B - Aliens & ship
        if(a.isAlive && rectsIntersect(a,ship))
        {
            hitSound.play();
            gameScene.removeChild(a);
            a.isAlive = false;
            decreaseLifeBy(1);
        }
    }
		
	// #6 - Now do some clean up
    bullets = bullets.filter(b => b.isAlive);
    Aliens = Aliens.filter(a => a.isAlive);
    explosions = explosions.filter(e => e.playing);
		
	// #7 - Is game over?
    if(life <= 0)
    {
        gameOverSound.play();
        end();
        return;
    }
		
	// #8 - Load next level
    if (Aliens.length == 0)
    {
        levelComplete.play();
        increaseRoundby(1);
        loadLevel();
    }
}

//create the aliens
function createAliens()
{
    //Standard Aliens
    for(let i = 0; i < round + 2; i++)
    {
        let a = new Alien(10, 10, "images/Alien.png");
        a.x = Math.random() * (sceneWidth - 50) + 25;
        a.y = Math.random() * (sceneHeight - 400) + 25;
        Aliens.push(a);
        gameScene.addChild(a);
    }

    if(round >= 5)
    {
        //Alien Wrappers
        for(let i = 0; i < round - 4; i++)
        {
            let a = new AlienWrap(10, 10, "images/AlienWrap.png");
            a.x = Math.random() * (sceneWidth - 50) + 25;
            a.y = Math.random() * (sceneHeight - 400) + 25;
            Aliens.push(a);
            gameScene.addChild(a);
        }
    }

    if(round >= 10  && round % 5 == 0)
    {
        for(let i = 0; i < round / 5; i++)
        {
            //Alien Seekers
            let a = new AlienSeek(0, 0, "images/AlienSeeker.png");
            a.x = Math.random() * (sceneWidth - 50) + 25;
            a.y = (sceneHeight / 2 - 400) + 25;
            a.speed = 5;
            a.activate(ship);
            Aliens.push(a);
            gameScene.addChild(a);
        }
    }
}

//load in the aliens
function loadLevel(){
	createAliens();
	paused = false;
}

//deals with bullets
function fireBullet(e)
{
    if (paused) return;

    //ship 1
    if(singFire)
    {
        let b = new Bullet(0x00FFFF, ship.x, ship.y);
        bullets.push(b);
        gameScene.addChild(b);
    }

    //ship 2
    else if(tripFire)
    {
        let b2 = new Bullet(0xFF0000, ship.x, ship.y);
        let b3 = new Bullet(0xFF0000, ship.x + 10, ship.y);
        let b4 = new Bullet(0xFF0000, ship.x - 10, ship.y);
        bullets.push(b2, b3, b4);
        gameScene.addChild(b2, b3, b4);
    }

    //ship 3
    else if(backFire)
    {
        let b5 = new Bullet(0x008000, ship.x, ship.y);
        let b6 = new BackBullet(0x008000, ship.x - 10, ship.y);
        let b7 = new BackBullet(0x008000, ship.x + 10, ship.y);
        bullets.push(b5, b6, b7);
        gameScene.addChild(b5, b6, b7);
    }

    //ship 4
    else if(pierceFire)
    {
        let b8 = new Bullet(0xFF8C00, ship.x, ship.y);
        bullets.push(b8);
        gameScene.addChild(b8);
    }
    shootSound.play();
}

//game over man
function end()
{
    paused = true;
    //if toal score is higher than the recorded high score
    if(score > highScore)
    {
        highScore = score;
        localStorage.setItem(scoreKey, highScore);
    }
    //if a high score is stored in local storage
    else if(storedScore)
    {
        highScore = storedScore;
    }

    gameOverScoreLabel.text = `Your Final Score: ${score}`;
    gameOverHighScoreLabel.text = `High Score: ${highScore}`;

    //delete aliens
    Aliens.forEach(a => gameScene.removeChild(a));
    Aliens = [];
    
    //delete bullets
    bullets.forEach(b => gameScene.removeChild(b));
    bullets = [];

    //delete explosions
    explosions.forEach(e => gameScene.removeChild(e));
    explosions = [];

    gameOverScene.visible = true;
    gameScene.visible = false;

    //reset all firing types
    singFire = true;
    tripFire = false;
    backFire = false;
    pierceFire = false;
}