#include "header.h"

void GetInputs(int values[][COLS])
{
    for(int rows = 0; rows < ROWS; rows++)
    {
        for(int cols = 0; cols < COLS; cols++)
        {
            cout << "Enter value" << endl;
            cin >> values[rows][cols];
        }

    }
}
