#include "Shield.h"

Shield::Shield() : Item()
{
	name = "Shield";
	damage = 3;
	weight = 20;
}

void Shield::print()
{
	Item::print();
}
