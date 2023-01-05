#pragma once
#include <iostream>
#include <thread>
#include <vector>
using namespace std;


class NumberPrinter
{
private:
	int number;
public:
	NumberPrinter(int n)
	{
		number = n;
	}

	void Print()
	{
		cout << number << " ";
	}
};

