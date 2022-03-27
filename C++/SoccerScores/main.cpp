#include "ScoreFunctions.h"

int main()
{
    int scoreTotal; //total score of team
    Player player; //player on the team
    Player team[TEAM_SIZE]; //array of team

    for(int i = 0; i < TEAM_SIZE; i++)
    {
        GetPlayerInfo(player);
        player = team[i];
    }
    for(int i = 0; i < TEAM_SIZE; i++)
    {
        ShowInfo(player);
    }
    scoreTotal = GetTotalPoints(team, TEAM_SIZE);
    cout <<  "Total points of team: " << scoreTotal << endl;
    ShowHighest(team, TEAM_SIZE);

    return 0;
}
