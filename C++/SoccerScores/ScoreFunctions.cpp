#include "ScoreFunctions.h"

//gets the name, number, and points scored by the player
void GetPlayerInfo(Player& person)
{
    int power = 0;
    bool legit = false;

    cout << "Enter name of Player " << (power + 1) << ": ";
    cin >> person.playerName;
    cout << "Enter number of Player "  << (power + 1) << ": ";
    cin >> person.playerNumber;
    while(legit == false)
    {
        if(person.playerNumber >= 0)
        {
            legit = true;
        }
        else
        {
            cout << "Invalid Number!!" << endl << "Enter positive number: ";
            cin >> person.playerNumber;
        }
    }
    cout << "Enter total points scored by Player " << (power + 1) << ": ";
    cin >> person.playerScore;
    while(legit == true)
    {
        if (person.playerScore >=0)
            legit = false;
        else
        {
            cout << "Invalid Score!!" << endl << "Enter positive score: ";
            cin >> person.playerScore;
        }
    }
}
//displays the info of the player
void ShowInfo(const Player& person)
{
    cout << "Name: " << person.playerName << setw(5) << "Player #:"
         << person.playerNumber << setw(5) << "Score: " << person.playerScore << endl;
}
//gets the total amount of pints scored by the team
int GetTotalPoints(const Player team[], int size)
{
    int total = 0;

    for(int buster = 0; buster < size; buster ++)
    {
        total = total + team[buster].playerScore;
    }

    return total;
}
//locates the player with the highest amount of points and displays that player's information
void ShowHighest(const Player team[], int size)
{
    int highest = team[0].playerScore;
    int number = team[0].playerNumber;
    string name = team[0].playerName;
    for(int wolf = 0; wolf < size; wolf++)
    {
        if(highest < team[wolf].playerScore)
        {
            highest = team[wolf].playerScore;
            number = team[wolf].playerNumber;
            name = team[wolf].playerName;
        }
    }
    cout << "Player " << number << " " << name << " with a score of " << highest;
}
