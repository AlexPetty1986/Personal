#include <iostream>
#include <iomanip>
#include <string>
#include "RecordsFunctions.h"

using namespace std;

double GetTotal(double values[][COLS])
{
    for(int power = 0; power < (ROWS - 1); power++)
    {
        for (int geyser = 0; geyser < (COLS - 1); geyser++)
        {
            total += values[power][geyser];
        }
    }
    return total;
}

double GetAverage(double values[][COLS])
{
    double index = 0;
    double averageTotal = 0;

    for(int power = 0; power < (ROWS - 1); power++)
    {
        for(int geyser = 0; geyser < (COLS - 1); geyser++)
        {
            averageTotal += values[power][geyser];
        }
    }

    average = average / index;

    return average;
}

double GetRowTotal(double values[][COLS], int)
{
    double totalRows = 0;

    for(int rows = 0; rows < (ROWS - 1); rows++)
    {
        totalRows += values[rows][cols];
    }
    return total;
}

double GetColumnTotal(double values[][COLS], int)
{
    double columnTotal = 0;

    for(int cols = 0; cols < (COLS - 1); cols++)
    {
        columnTotal += values[rows][cols];
    }

    return columnTotal;

}

double GetHighest(double values[][COLS], int&, int&)
{
    double highest = 0;

    for(int power = 0; power < (ROWS - 1); power ++)
    {
        for(int geyser = 0; geyser < (COLS - 1); geyser++)
        {
            if((values[power][geyser]) > highest)
            {
                rows = power;
                cols = geyser;
                highest = values[rows][cols];
            }
        }
    }

    return highest;
}

double GetLowest(double values[][COLS], int&, int&)
{
    double lowest = values[0][0];

    for(int power = 0; power < (ROWS - 1); power ++)
    {
        for(int geyser = 0; geyser < (COLS - 1); lowest++)
        {
            if((values[power][geyser]) <= lowest)
            {
                rows = power;
                cols = geyser;
                lowest = values[rows][cols];
            }
        }
    }

    return lowest;
}
