#include "Cloak.h"

Cloak::Cloak() : Item()
{
	name = "Cloak";
	damage = 0;
	weight = 1;
}

void Cloak::print()
{
	Item::print();
}
