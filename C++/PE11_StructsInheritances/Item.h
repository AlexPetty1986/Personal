#pragma once

#include <iostream>
#include <cstring>
#include <string>
#include <vector>
using namespace std;

struct Item
{
protected:
	string name;
	int damage;
	int weight;

public:
	Item();
	void print();
};

