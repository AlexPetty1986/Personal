#include "snake.h"

//new gameplay mechanic
//I added in a high score that changes if the user gets a lower score (golf rules)
//I also gave the player an option to start at the beginning of the gameplay loop
//at the results screen by pressing enter or quitting by pressing escape
int main()
{
    //variables
    //game window size
    const int windowWidth = 1200;
    const int windowHeight = 900;
    //player input
    Keyboard playerInput;
    //game font
    Font gameFont;
    gameFont.loadFromFile("PAPYRUS.ttf");
    string gameStart = "title";
    int score = 0;
    int highScore = 0;
    int endScore = 0;
    int keyPresses = 0;
    //Create world
    b2Vec2 gravity(0.0f, 9.8f);
    b2World world(gravity);
    Clock deltaClock;

    //Create ground floor
    b2BodyDef groundBodyDef;
    groundBodyDef.position.Set(0.0f, (-windowHeight / 2));
    b2Body* groundBody = world.CreateBody(&groundBodyDef);
    b2PolygonShape groundBox;
    groundBox.SetAsBox(windowWidth / 2, 10.0f);
    groundBody->CreateFixture(&groundBox, 0.0f);
    RectangleShape solidFloor(Vector2f(windowWidth, 10));
    solidFloor.setFillColor(Color(0, 0, 255));
    solidFloor.setPosition(0, 0);

    //create ceiling
    b2BodyDef ceilingBodyDef;
    ceilingBodyDef.position.Set(0.0f, (windowHeight / 2) - 20);
    b2Body* ceilingBody = world.CreateBody(&ceilingBodyDef);
    b2PolygonShape ceilingBox;
    ceilingBox.SetAsBox(windowWidth / 2, 10.0f);
    ceilingBody->CreateFixture(&ceilingBox, 0.0f);
    RectangleShape solidCeiling(Vector2f(windowWidth, 10));
    solidCeiling.setFillColor(Color(0, 0, 255));
    solidCeiling.setPosition(0, windowHeight - 10);

    //create some walls
    //left
    b2BodyDef leftBodyDef;
    leftBodyDef.position.Set(-windowWidth / 2, 0.0f);
    b2Body* leftBody = world.CreateBody(&leftBodyDef);
    b2PolygonShape leftBox;
    leftBox.SetAsBox(10.0f, windowHeight / 2);
    leftBody->CreateFixture(&leftBox, 0.0f);
    RectangleShape solidLeft(Vector2f(10, windowHeight));
    solidLeft.setFillColor(Color(0, 0, 255));
    solidLeft.setPosition(0, 0);
    //right
    b2BodyDef rightBodyDef;
    rightBodyDef.position.Set((windowWidth / 2) - 20, 0.0f);
    b2Body* rightBody = world.CreateBody(&rightBodyDef);
    b2PolygonShape rightBox;
    rightBox.SetAsBox(10.0f, windowHeight / 2);
    rightBody->CreateFixture(&rightBox, 0.0f);
    RectangleShape solidRight(Vector2f(10, windowHeight));
    solidRight.setFillColor(Color(0, 0, 255));
    solidRight.setPosition(windowWidth - 10, 0);

    //Create the snake
    b2BodyDef snakeDef;
    snakeDef.type = b2_dynamicBody;
    snakeDef.position.Set(0.0f, 0.0f);
    b2Body* snake = world.CreateBody(&snakeDef);

    b2PolygonShape dynamicBox;
    dynamicBox.SetAsBox(1.0f, 1.0f);

    b2FixtureDef fixtureDef;
    fixtureDef.shape = &dynamicBox;
    fixtureDef.density = 1.0f;
    fixtureDef.friction = 0.3f;
    snake->CreateFixture(&fixtureDef);
    RectangleShape solidSnake(Vector2f(20, 20));
    solidSnake.setFillColor(Color(255, 0, 0));
    solidSnake.setPosition(0, 0);

    //target
    b2Vec2 target(0.0f, 0.0f);
    moveTarget(&target);
    CircleShape solidTarget(20);
    solidTarget.setFillColor(Color(0, 255, 0));
    solidTarget.setPosition(Vector2f(target.x + windowWidth / 2, target.y + windowHeight / 2));

    //text
    //game title
    Text gameTitle;
    gameTitle.setFont(gameFont);
    gameTitle.setString("Gravity Snake Sprited");
    gameTitle.setCharacterSize(60);
    gameTitle.setFillColor(Color(255, 0, 0));
    gameTitle.setPosition(windowWidth / 2 - gameTitle.getLocalBounds().width / 2, (windowHeight * 2) / 10);

    //game controls
    Text gameControls;
    gameControls.setFont(gameFont);
    gameControls.setString("Use the ASWD or Arrow Keys to move and hit 5 targets!");
    gameControls.setCharacterSize(40);
    gameControls.setFillColor(Color(255, 0, 0));
    gameControls.setPosition(windowWidth / 2 - gameControls.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 80);

    //timer
    Text timeLeft;
    timeLeft.setFont(gameFont);
    timeLeft.setCharacterSize(40);
    timeLeft.setFillColor(Color(255, 0, 0));

    //end game
    Text endGame;
    endGame.setFont(gameFont);
    endGame.setString("YOU WON!!!");
    endGame.setCharacterSize(60);
    endGame.setFillColor(Color(255, 0, 0));
    endGame.setPosition(windowWidth / 2 - endGame.getLocalBounds().width / 2, (windowHeight * 2) / 10);

    //target total
    Text targetTotal;
    targetTotal.setFont(gameFont);
    targetTotal.setCharacterSize(40);
    targetTotal.setFillColor(Color(255, 0, 0));

    //key presses
    Text keyTotal;
    keyTotal.setFont(gameFont);
    keyTotal.setCharacterSize(40);
    keyTotal.setFillColor(Color(255, 0, 0));

    //final score
    Text finalScore;
    finalScore.setFont(gameFont);
    finalScore.setCharacterSize(40);
    finalScore.setFillColor(Color(255, 0, 0));

    //player high score
    Text bestScore;
    bestScore.setFont(gameFont);
    bestScore.setCharacterSize(40);
    bestScore.setFillColor(Color(255, 0, 0));

    //prompt user to play again
    Text playAgain;
    playAgain.setFont(gameFont);
    playAgain.setCharacterSize(40);
    playAgain.setFillColor(Color(255, 0, 0));

    //or quit
    Text gameOver;
    gameOver.setFont(gameFont);
    gameOver.setCharacterSize(40);
    gameOver.setFillColor(Color(255, 0, 0));

    //create the game window
    RenderWindow window(VideoMode(windowWidth, windowHeight), "Gravity Snake Sprited");

    //while the game is still running and the player has not hit 3 targets
    while (window.isOpen())
    {
        window.clear(Color::Black);
        window.draw(solidFloor);
        window.draw(solidCeiling);
        window.draw(solidLeft);
        window.draw(solidRight);

        Event event;

        while (window.pollEvent(event))
        {
            if (event.type == Event::Closed)
            {
                window.close();
            }
        }

        //if the player is at the title screen
        if (gameStart == "title")
        {
            window.draw(gameTitle);
            window.draw(gameControls);
            if (playerInput.isKeyPressed(Keyboard::Enter))
            {
                gameStart = "gameTime";
            }
        }

        //if the player is playing the game
        else if (gameStart == "gameTime")
        {
            //gets the coordinates of the snake
            b2Vec2 position = snake->GetPosition();
            window.draw(solidSnake);
            window.draw(solidTarget);

            //update the world
            update(world, deltaClock);

            //apply force to snake
            applyForces(playerInput, *snake);

            //if a movement key is pressed
            if (playerInput.isKeyPressed(Keyboard::A) || playerInput.isKeyPressed(Keyboard::Left) ||
                playerInput.isKeyPressed(Keyboard::S) || playerInput.isKeyPressed(Keyboard::Down) ||
                playerInput.isKeyPressed(Keyboard::W) || playerInput.isKeyPressed(Keyboard::Up) ||
                playerInput.isKeyPressed(Keyboard::D) || playerInput.isKeyPressed(Keyboard::Right))
            {
                keyPresses++;
            }

            solidSnake.setPosition(Vector2f(position.x + windowWidth / 2, position.y + windowHeight / 2));
            solidTarget.setPosition(Vector2f(target.x + windowWidth / 2, target.y + windowHeight / 2));

            //if the snake gets in range of the target
            if (position.x >= target.x - 35 && position.x <= target.x + 35 && position.y >= target.y - 35 && position.y <= target.y + 35)
            {
                score++;
                moveTarget(&target);
            }

            //if the target goal has been met
            if (score >= 5)
            {
                gameStart = "results";
            }
        }

        //if the player has beaten the game
        else if (gameStart == "results")
        {
            //calculate end score
            endScore = keyPresses / score;

            //if the end score is better than the high score or the high score is 0
            if (highScore > endScore || highScore == 0)
            {
                highScore = endScore;
            }

            //draw results
            window.draw(endGame);

            targetTotal.setString("Targets Hit: " + to_string(score));
            targetTotal.setPosition(windowWidth / 2 - targetTotal.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 80);
            window.draw(targetTotal);

            keyTotal.setString("Key Presses: " + to_string(keyPresses));
            keyTotal.setPosition(windowWidth / 2 - keyTotal.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 140);
            window.draw(keyTotal);

            finalScore.setString("Final Score: " + to_string(endScore));
            finalScore.setPosition(windowWidth / 2 - finalScore.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 200);
            window.draw(finalScore);

            //If the high score has changed
            if (highScore == endScore)
            {
                bestScore.setString("NEW High Score: " + to_string(highScore));
            }

            //If it hasn't
            else
            {
                bestScore.setString("High Score: " + to_string(highScore));
            }

            bestScore.setPosition(windowWidth / 2 - bestScore.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 260);
            window.draw(bestScore);

            playAgain.setString("Wanna Play Again? Press the Enter Key!");
            playAgain.setPosition(windowWidth / 2 - playAgain.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 320);
            window.draw(playAgain);

            gameOver.setString("Or Press Escape to Quit");
            gameOver.setPosition(windowWidth / 2 - gameOver.getLocalBounds().width / 2, ((windowHeight * 2) / 10) + 380);
            window.draw(gameOver);

            //if the player wants to play again
            if (playerInput.isKeyPressed(Keyboard::Enter))
            {
                score = 0;
                keyPresses = 0;
                solidSnake.setPosition(Vector2f(windowWidth / 2, windowHeight / 2));
                moveTarget(&target);
                gameStart = "gameTime";
            }

            //if the player wants to quit
            if (playerInput.isKeyPressed(Keyboard::Escape))
            {
                window.close();
            }
        }

        window.display();
    }

    _CrtDumpMemoryLeaks();
    return 0;
}
