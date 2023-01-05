#pragma once
#include <string>

class GamePlay
{
private:
	string object;

public:
	GamePlay(string o)
	{
		object = o;
	}

	void Update()
	{
		for(int i = 1; i < 11; i++)
		{
			cout << object << ": " << i*10 << "% Complete" << endl;
		}
	}
};

