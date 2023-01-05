#pragma once
#include <iostream>
#include <memory>
#include <string>
using namespace std;

class Level
{
private:
	int levelNum;
	string treasures[6];
	int enemyTotal;

public:
	Level(int level, string treasureList[], int enemyCount);
	~Level();
	//void printLevel();
};

