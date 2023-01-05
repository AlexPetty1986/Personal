#pragma once
#include <iostream>
#define SFML_STATIC
#include <SFML/Window.hpp>
#include <SFML/Graphics.hpp>
#include <Box2D/Box2D.h>
#include <conio.h>
#include <cstring>
using namespace std;
using namespace sf;

void update(b2World &world, Clock &deltaClock);
//void display(b2Body &snake, b2Vec2 &target);
void applyForces(Keyboard Key, b2Body &snake);
void moveTarget(b2Vec2 *target);