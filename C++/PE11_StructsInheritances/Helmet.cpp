#include "Helmet.h"

Helmet::Helmet() : Item()
{
	name = "Helmet";
	damage = 0;
	weight = 9;
}

void Helmet::print()
{
	Item::print();
}
