#include <iostream>
#include "ArrayFunctions.h"

using namespace std;

int main()
{
    int* values = nullptr;
    int size;
    int* revValues = nullptr;

    cout << "What size array to use? ";
    cin >> size;

    values = new int[size];
    srand(time(0));

    if(values != nullptr)
    {
        for(int count = 0; count < size; count++)
        {
            *(values + count) = rand() % (abs(10 - 1 + 1));
        }

        DisplayGrades(values, size);
        cout << endl;
        values = ArrayExpander(values, size);
        DisplayGrades(values, size * 2);
        cout << endl;
        revValues = ArrayReverse(values, size * 2);
        DisplayGrades(revValues, size * 2);
        cout << endl;

    }
    else
    {
        cout << "invalid pointer" << endl;
    }

    delete [] values;
    values = nullptr;
    delete [] revValues;
    revValues = nullptr;

    return 0;
}
