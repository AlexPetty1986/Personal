#include "Dagger.h"

Dagger::Dagger() : Item()
{
	name = "Dagger";
	damage = 9;
	weight = 2;
}

void Dagger::print()
{
	Item::print();
}
