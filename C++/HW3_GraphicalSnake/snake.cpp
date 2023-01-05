#include "snake.h"

//constantly updates the world
void update(b2World &world, Clock &deltaClock)
{
	Time deltaTime;

	deltaTime = deltaClock.getElapsedTime();
	deltaClock.restart();

	world.Step(deltaTime.asSeconds(), 6, 2);
	
	//cout << deltaTime.asSeconds() << endl;
}

//displays the current positions of the target and the snake
/*void display(b2Body& snake, b2Vec2& target)
{
	b2Vec2 position = snake.GetPosition();
	printf("Target: (%.2f, %.2f), Snake: (%.2f, %.2f)\n", target.x, target.y, position.x, position.y);
}*/

//checks the direction the player is going
void applyForces(Keyboard Key, b2Body &snake)
{
	//force pointer
	b2Vec2* force;

	//left
	if (Key.isKeyPressed(Keyboard::A) || Key.isKeyPressed(Keyboard::Left))
	{
		force = new b2Vec2(-20000.0f, 0.0f);
	}
	//down
	else if (Key.isKeyPressed(Keyboard::S) || Key.isKeyPressed(Keyboard::Down))
	{
		force = new b2Vec2(0.0f, 20000.0f);
	}
	//up
	else if (Key.isKeyPressed(Keyboard::W) || Key.isKeyPressed(Keyboard::Up))
	{
		force = new b2Vec2(0.0f, -20000.0f);
	}
	//right
	else if (Key.isKeyPressed(Keyboard::D) || Key.isKeyPressed(Keyboard::Right))
	{
		force = new b2Vec2(20000.0f, 0.0f);
	}
	else
	{
		force = new b2Vec2(0.0f, 0.0f);
	}

	snake.ApplyForceToCenter(*force, true);

	delete force;
}

//moves the target whenever the snake is in range
void moveTarget(b2Vec2 *target)
{
	srand(time(0));
	target->x = (((rand() % 101) / 10.0f) - 5.0f) * 90.0f;
	target->y = (((rand() % 101) / 10.0f) - 5.0f) * 80.0f;
}