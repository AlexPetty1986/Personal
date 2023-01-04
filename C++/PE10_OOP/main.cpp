// PE10.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "Fighter.h"

int main()
{
    //variables
    //players
    Player myPlayer = Player();
    Player newPlayer = Player(new char[10]{ "Alex" }, 25, 10, 13);
    Player* heapPlayer = new Player();
    Player* mePlayer = new Player(new char[10]{ "Jim" }, 8, 25, 18);
    //fighters
    Fighter myFighter = Fighter();
    Fighter newFighter = Fighter(new char[10]{ "Marth" }, 5, 7, 7, new char[99]{"Dancing Blade"});
    Fighter* heapFighter = new Fighter();
    Fighter* meFighter = new Fighter(new char[10]{ "Ike" }, 24, 23, 21, new char[99]{ "Aether" });

    //print out player info
    myPlayer.printPlayer();
    newPlayer.printPlayer();
    heapPlayer->printPlayer();
    mePlayer->printPlayer();

    //print out fighter info
    myFighter.printFighter();
    newFighter.printFighter();
    heapFighter->printFighter();
    meFighter->printFighter();

    //delete any heap variables
    delete(heapPlayer);
    delete(mePlayer);
    delete(heapFighter);
    delete(meFighter);

    //set pointers to nullptr
    heapPlayer = nullptr;
    mePlayer = nullptr;
    heapFighter = nullptr;
    meFighter = nullptr;
}

