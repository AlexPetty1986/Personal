#include "Item.h"

Item::Item()
{
	name = "Sword";
	damage = 15;
	weight = 6;
}

void Item::print()
{
	printf("Name: %s \nDamage: %d \nWeight: %d \n\n", name.c_str(), damage, weight);
}
