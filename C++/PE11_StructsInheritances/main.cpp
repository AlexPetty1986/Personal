// PE11.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include "Item.h"
#include "Helmet.h"
#include "Dagger.h"
#include "Shield.h"
#include "Cloak.h"

int main()
{
    //variables
    Item* sword = new Item();
    Helmet* helmet = new Helmet();
    Dagger* dagger = new Dagger();
    Shield* shield = new Shield();
    Cloak* cloak = new Cloak();
    vector<Item*> inventory;

    //add items to vector
    inventory.push_back(sword);
    inventory.push_back(helmet);
    inventory.push_back(dagger);
    inventory.push_back(shield);
    inventory.push_back(cloak);

    //for each item in the inventory;
    for (unsigned int i = 0; i < inventory.size(); i++)
    {
        //print out item stats
        inventory[i]->print();
    }

    //delete pointers
    delete(sword);
    delete(helmet);
    delete(dagger);
    delete(shield);
    delete(cloak);

    sword = nullptr;
    helmet = nullptr;
    dagger = nullptr;
    shield = nullptr;
    cloak = nullptr;

}
