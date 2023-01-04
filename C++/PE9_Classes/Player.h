#pragma once
#include <iostream>
#include <cstring>
#include <string>
using namespace std;

//classes
class Player
{
private: 
	char* name;
	int strength;
	int dexterity;
	int charisma;

public:
	//constructors
	Player();
	Player(char* n, int s, int d, int c);

	//methods
	void printPlayer();
};

