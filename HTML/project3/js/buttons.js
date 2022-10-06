function createLabelsAndButtons() 
{
        let buttonStyle = new PIXI.TextStyle(
        {
            fill: 0xFF0000,
            fontSize: 32,
            fontFamily: 'Press Start 2P'
        });

        // 1 - set up 'startScene
        // 1A - make top start Label
        let startLabel1 = new PIXI.Text("Alien Defender!");
        startLabel1.style = new PIXI.TextStyle(
        {
            fill: 0x0000FF,
            fontSize: 36,
            fontFamily: 'Press Start 2P',
            stroke: 0xFF0000,
            strokeThickness: 6
        });
        startLabel1.x = 40;
        startLabel1.y = 120;
        startScene.addChild(startLabel1);

        // 1B - make middle start Label
        let startLabel2 = new PIXI.Text("Ready to Fight?");
        startLabel2.style = new PIXI.TextStyle(
        {
            fill: 0x0000FF,
            fontSize: 16,
            fontFamily: 'Press Start 2P',
            fontstyle: "italic",
            stroke: 0xFF0000,
            strokeThickness: 6
        });
        startLabel2.x = 170;
        startLabel2.y = 300;
        startScene.addChild(startLabel2);

        // 1B - make middle start Label
        let startLabel3 = new PIXI.Text("Select a ship");
        startLabel3.style = new PIXI.TextStyle(
        {
            fill: 0x0000FF,
            fontSize: 12,
            fontFamily: 'Press Start 2P',
            stroke: 0xFF0000,
            strokeThickness: 6
        });
        startLabel3.x = 210;
        startLabel3.y = 360;
        startScene.addChild(startLabel3);

        // 1C - make start game button
        let startButton = new PIXI.Sprite.from("images/OneShip.png");
        startButton.width = 32;
        startButton.height = 32;
        startButton.x = 125;
        startButton.y = sceneHeight - 175;
        startButton.interactive = true;
        startButton.buttonMode = true;
        startButton.on("pointerup", startGame); // startGame is a function reference
        startButton.on('pointerover', e => e.target.alpha = 0.7); // concise arrow function with no brackets
        startButton.on('pointerout', e => e.currentTarget.alpha = 1.0); // ditto
        startScene.addChild(startButton);

        // 1C - make start game button
        let startButton2 = new PIXI.Sprite.from("images/TriShip.png");
        startButton2.width = 32;
        startButton2.height = 32;
        startButton2.x = 225;
        startButton2.y = sceneHeight - 175;
        startButton2.interactive = true;
        startButton2.buttonMode = true;
        startButton2.on("pointerup", startGame); // startGame is a function reference
        startButton2.on("pointerup", swapShip2); // startGame is a function reference
        startButton2.on('pointerover', e => e.target.alpha = 0.7); // concise arrow function with no brackets
        startButton2.on('pointerout', e => e.currentTarget.alpha = 1.0); // ditto
        startScene.addChild(startButton2);

        // 1C - make start game button
        let startButton3 = new PIXI.Sprite.from("images/BackShip.png");
        startButton3.width = 32;
        startButton3.height = 32;
        startButton3.x = 325;
        startButton3.y = sceneHeight - 175;
        startButton3.interactive = true;
        startButton3.buttonMode = true;
        startButton3.on("pointerup", startGame); // startGame is a function reference
        startButton3.on("pointerup", swapShip3); // startGame is a function reference
        startButton3.on('pointerover', e => e.target.alpha = 0.7); // concise arrow function with no brackets
        startButton3.on('pointerout', e => e.currentTarget.alpha = 1.0); // ditto
        startScene.addChild(startButton3);

        // 1C - make start game button
        let startButton4 = new PIXI.Sprite.from("images/PierceShip.png");
        startButton4.width = 32;
        startButton4.height = 32;
        startButton4.x = 425;
        startButton4.y = sceneHeight - 175;
        startButton4.interactive = true;
        startButton4.buttonMode = true;
        startButton4.on("pointerup",startGame); // startGame is a function reference
        startButton4.on("pointerup", swapShip4); // startGame is a function reference
        startButton4.on('pointerover', e => e.target.alpha = 0.7); // concise arrow function with no brackets
        startButton4.on('pointerout', e => e.currentTarget.alpha = 1.0); // ditto
        startScene.addChild(startButton4);

        // 2 - set up ‘gameScene 
        let textStyle = new PIXI.TextStyle({
            fill: 0x0000FF, 
            fontSize: 12, 
            fontFamily: 'Press Start 2P', 
            stroke: 0xFF0000,
            strokeThickness: 4 
        }); 

        // 2A - make score label 
        scoreLabel = new PIXI.Text(); 
        scoreLabel.style = textStyle; 
        scoreLabel.x = 5; 
        scoreLabel.y = 5; 
        gameScene.addChild(scoreLabel); 
        increaseScoreby(0);

        // 2B - make life label 
        lifeLabel = new PIXI.Text(); 
        lifeLabel.style = textStyle; 
        lifeLabel.x = 5; 
        lifeLabel.y = 25; 
        gameScene.addChild(lifeLabel); 
        decreaseLifeBy(0);

        // 2C - make round label 
        roundLabel = new PIXI.Text(); 
        roundLabel.style = textStyle; 
        roundLabel.x = 5; 
        roundLabel.y = 45; 
        gameScene.addChild(roundLabel);
        increaseRoundby(0);

        // 3 - set up `gameOverScene`
        // 3A - make game over text
        let gameOverText = new PIXI.Text("Game Over Man!\n  Game Over!");
            textStyle = new PIXI.TextStyle(
            {
                fill: 0x0000FF,
                fontSize: 32,
                fontFamily: 'Press Start 2P',
                stroke: 0xFF0000,
                strokeThickness: 6
            });
        gameOverText.style = textStyle;
        gameOverText.x = 60;
        gameOverText.y = sceneHeight/2 - 160;
        gameOverScene.addChild(gameOverText);

        gameOverScoreLabel = new PIXI.Text();
        gameOverScoreLabel.style = new PIXI.TextStyle({
            fill: 0x0000FF,
            fontSize: 16,
            fontFamily: 'Press Start 2P',
            stroke: 0xFF0000,
            strokeThickness: 6
        });
        gameOverScoreLabel.x = 140;
        gameOverScoreLabel.y = sceneHeight/2 + 25;
        gameOverScene.addChild(gameOverScoreLabel);

        gameOverHighScoreLabel = new PIXI.Text();
        gameOverHighScoreLabel.style = new PIXI.TextStyle({
            fill: 0x0000FF,
            fontSize: 16,
            fontFamily: 'Press Start 2P',
            stroke: 0xFF0000,
            strokeThickness: 6
        });
        gameOverHighScoreLabel.x = 180;
        gameOverHighScoreLabel.y = sceneHeight/2 + 90;
        gameOverScene.addChild(gameOverHighScoreLabel);

        // 3B - make "play again?" button
        let playAgainButton = new PIXI.Text("Try Again?");
        playAgainButton.style = buttonStyle;
        playAgainButton.x = 130;
        playAgainButton.y = sceneHeight - 100;
        playAgainButton.interactive = true;
        playAgainButton.buttonMode = true;
        playAgainButton.on("pointerup", titleScreen); // startGame is a function reference
        playAgainButton.on('pointerover',e=>e.target.alpha = 0.7); // concise arrow function with no brackets
        playAgainButton.on('pointerout',e=>e.currentTarget.alpha = 1.0); // ditto
        gameOverScene.addChild(playAgainButton);
}