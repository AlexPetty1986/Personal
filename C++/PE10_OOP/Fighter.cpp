#include "Fighter.h"

//constructor
Fighter::Fighter() : Player()
{
	wepSkill = new char[99]{ "Quick Slash" };
}

//parameterized constructor
Fighter::Fighter(char* n, int s, int d, int c, char* w) : Player(n, s, d, c)
{
	this->wepSkill = w;
}

//Prints out fighter info
void Fighter::printFighter()
{
	Player::printPlayer();
	cout << "Weapon Skill: " << wepSkill << endl;
}