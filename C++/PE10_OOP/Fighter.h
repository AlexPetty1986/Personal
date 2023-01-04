#pragma once
#include "Player.h"

class Fighter : public Player
{
private:
	char* wepSkill;

public:
	//constructors
	Fighter();
	Fighter(char* n, int s, int d, int c, char* w);

	//methods
	void printFighter();
};

