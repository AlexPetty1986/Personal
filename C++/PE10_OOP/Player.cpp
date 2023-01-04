#include "Player.h"

//default constructor
Player::Player()
{
	name = new char[10]{ "Unknown" };
	strength = 10;
	dexterity = 10;
	charisma = 10;
}

//parameterized constructor
Player::Player(char* n, int s, int d, int c)
{
	this->name = n;
	this->strength = s;
	this->dexterity = d;
	this->charisma = c;
}

//Prints out player info
void Player::printPlayer()
{
	cout << "\nName: " << name << "\nStrength: " << strength
		<< "\nDexterity: " << dexterity << "\nCharisma: " << charisma << endl;
}

