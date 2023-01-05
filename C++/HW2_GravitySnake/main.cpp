#include "snake.h"

void wrapper()
{
    //variables
    //Create world
    b2Vec2 gravity(0.0f, 9.8f);
    b2World world(gravity);
    Keyboard playerInput;
    const int windowWidth = 800;
    const int windowHeight = 600;

    //Create ground floor
    b2BodyDef groundBodyDef;
    groundBodyDef.position.Set(0.0f, (-windowHeight / 2));
    b2Body* groundBody = world.CreateBody(&groundBodyDef);
    b2PolygonShape groundBox;
    groundBox.SetAsBox(windowWidth/2, 10.0f);
    groundBody->CreateFixture(&groundBox, 0.0f);
    RectangleShape solidFloor(Vector2f(windowWidth, 10));
    solidFloor.setFillColor(Color(0, 0, 255));
    solidFloor.setPosition(0, 0);

    //create ceiling
    b2BodyDef ceilingBodyDef;
    ceilingBodyDef.position.Set(0.0f, (windowHeight / 2) - 20);
    b2Body* ceilingBody = world.CreateBody(&ceilingBodyDef);
    b2PolygonShape ceilingBox;
    ceilingBox.SetAsBox(windowWidth/2, 10.0f);
    ceilingBody->CreateFixture(&ceilingBox, 0.0f);
    RectangleShape solidCeiling(Vector2f(windowWidth, 10));
    solidCeiling.setFillColor(Color(0, 0, 255));
    solidCeiling.setPosition(0, windowHeight - 10);

    //create some walls
    //left
    b2BodyDef leftBodyDef;
    leftBodyDef.position.Set(-windowWidth/2, 0.0f);
    b2Body* leftBody = world.CreateBody(&leftBodyDef);
    b2PolygonShape leftBox;
    leftBox.SetAsBox(10.0f, windowHeight/2);
    leftBody->CreateFixture(&leftBox, 0.0f);
    RectangleShape solidLeft(Vector2f(10, windowHeight));
    solidLeft.setFillColor(Color(0, 0, 255));
    solidLeft.setPosition(0, 0);
    //right
    b2BodyDef rightBodyDef;
    rightBodyDef.position.Set((windowWidth/2) - 20, 0.0f);
    b2Body* rightBody = world.CreateBody(&rightBodyDef);
    b2PolygonShape rightBox;
    rightBox.SetAsBox(10.0f, windowHeight/2);
    rightBody->CreateFixture(&rightBox, 0.0f);
    RectangleShape solidRight(Vector2f(10, windowHeight));
    solidRight.setFillColor(Color(0, 0, 255));
    solidRight.setPosition(windowWidth-10, 0);

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
    solidTarget.setPosition(windowWidth / 2, windowHeight / 2);

    int score = 0;
    int keyPresses = 0;

    bool running = true;
    char input = ' ';
    Clock deltaClock;

    RenderWindow window(VideoMode(windowWidth, windowHeight), "Gravity Snake Sprited");

    //while the game is still running and the player has not hit 3 targets
    while (window.isOpen())
    {
        sf::Event event;
        while (window.pollEvent(event))
        {
            if (event.type == Event::Closed)
            {
                window.close();
            }
        }

        //gets the coordinates of the snake
        b2Vec2 position = snake->GetPosition();

        window.clear(Color::Black);
        window.draw(solidSnake);
        window.draw(solidFloor);
        window.draw(solidCeiling);
        window.draw(solidLeft);
        window.draw(solidRight);
        //window.draw(solidTarget);

        //update the world
        update(world, deltaClock);

        //display current positions of snake and target
        //display(*snake, target);

        applyForces(playerInput, *snake);
        solidSnake.setPosition(Vector2f(position.x + windowWidth / 2, position.y + windowHeight / 2));

        //if escape is pressed set running to false
        if (playerInput.isKeyPressed(Keyboard::Escape))
        {
            window.close();
        }

        //if the snake gets in range of the target
        if (position.x >= target.x - .25 && position.x <= target.x + .25 && position.y >= target.y - .25 && position.y <= target.y + .25)
        {
            moveTarget(&target);
            score++;
        }

        window.display();
    }

    //calculate final score (Going by golf rules)
    float finalScore = (float)keyPresses / (float)score;

    //print out results
    cout << "\nYou Win!\nTargets Hit: " << score << "\nTotal Key Presses: " << keyPresses << "\nFinal Score: " << finalScore << endl;
}

int main()
{
    wrapper();
    _CrtDumpMemoryLeaks();
    return 0;
}
