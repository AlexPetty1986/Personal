#include "Level.h"

Level::Level(int level, string treasureList[], int enemyCount)
{
	levelNum = level;
	
	for (int i = 0; i < sizeof(treasureList) - 2; i++)
	{
		treasures[i] = treasureList[i];
	}

	enemyTotal = enemyCount;

	printf("Level info created\n");
}

Level::~Level()
{
	printf("Level info deleted\n\n");
}

/*void Level::printLevel()
{
	printf("Current Level: %d", levelNum);
	printf("\nTreasures in Dungeon: \n");
	for (int i = 0; i < 6; i++)
	{
		printf("%s\n", treasures[i].data());
	}
	printf("Total Enemies: %d\n", enemyTotal);
}*/
