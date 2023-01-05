// PE12.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "Level.h"


void wrapper()
{
    string treasuresList[6] = { "Gold", "Ragnell", "Copy of Gex for the PS1", "Paul Allen's Card", "Power Star", "Triforce" };
    unique_ptr<Level> levelLayout(new Level(5, treasuresList, 8));
    //levelLayout->printLevel();
}

void pWrapper()
{
    string otherTreasures[6] = { "Falchion", "Mirror Shield", "Fore! by Huey Lewis & the News", "Patrick Bateman's New Card", "Fire Flower", "Kirby Statue" };
    Level* pointLevel = new Level(9, otherTreasures, 2);
    //pointLevel->printLevel();
}

int main()
{
    wrapper();
    pWrapper();
    _CrtDumpMemoryLeaks();
}
