#include <iostream>
using namespace std;

//variables
const int Neptunians = 4;
const int Omicronians = 3;

int Iteration(int seats)
{
    int totalHands = 0;
    int totalNeptunian = 0;
    int totalOmicronian = 0;

    for (int i = 0; i < seats; i++)
    {

        if ((i + 1) % 2 == 0)
        {
            totalHands += Neptunians;
            totalNeptunian++;
        }

        else
        {
            totalHands += Omicronians;
            totalOmicronian++;
        }
    }

    cout << "Total Number of Neptunians: " << totalNeptunian << endl;
    cout << "Total Number of Omicronians: " << totalOmicronian << endl;

    return totalHands;
}

int Recursion(int seats)
{
    if (seats <= 1)
    {
        return Omicronians;
    }

    if (seats % 2 == 0)
    {
        return Neptunians + Recursion(seats - 1);
    }

    else
    {
        return Omicronians + Recursion(seats - 1);
    }
}

int Formula(int seats)
{
    if (seats % 2 == 0)
    {
        return (((Neptunians + Omicronians) * seats) / 2);
    }

    else
    {
        return (((Neptunians + Omicronians) * (seats - 1)) / 2) + Omicronians;
    }
}

int main()
{
    srand(time(NULL));

    int seats = rand() % 25 + 1;
    cout << "Total seats in row: " << seats << endl;

    cout << "Total amount of hands through Iteration: " << Iteration(seats) << endl;
    cout << "Total amount of hands through Recursion: " << Recursion(seats) << endl;
    cout << "Total amount of hands through a Formula: " << Formula(seats) << endl;
}
