// PE9.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include "Player.h"

int main()
{
    //variables
    Player myPlayer = Player();
    Player newPlayer = Player(new char[10]{ "Alex" }, 25, 10, 13);
    Player* heapPlayer = new Player();
    Player* mePlayer = new Player(new char[10]{ "Jim" }, 8, 25, 18);

    //print out player info
    myPlayer.printPlayer();
    newPlayer.printPlayer();
    heapPlayer->printPlayer();
    mePlayer->printPlayer();

    //delete any heap variables
    delete(heapPlayer);
    delete(mePlayer);
}
