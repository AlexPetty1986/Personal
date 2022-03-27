#ifndef SCOREFUNCTIONS_H_INCLUDED
#define SCOREFUNCTIONS_H_INCLUDED
#include <string>
#include <iostream>
#include <iomanip>
#include <cmath>

using namespace std;

const int TEAM_SIZE = 3; //total size of the team

struct Player //information regarding player on the team
{
    string playerName; //name of the player
    int playerNumber;  //number of the player
    int playerScore;   //total points scored by player
};

void GetPlayerInfo(Player& person); //gets the name, number, and points scored by the player
void ShowInfo(const Player& person); //displays the info of the player
int GetTotalPoints(const Player team[], int size); //gets the total amount of pints scored by the team
void ShowHighest(const Player team[], int size); //locates and displays player with highest score

#endif // SCOREFUNCTIONS_H_INCLUDED
