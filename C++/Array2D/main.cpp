#include <iostream>
#include <iomanip>
#include "header.h"

using namespace std;

int main()
{
    int data[ROWS][COLS];
    bool result;
    bool isValid;

    //GetInputs(data);

    int* myPtr = nullptr;
    int x = 99;
    int y = 55;
    myPtr = &x;
    const int* const myPtr2 = &x;
    x = 200;
    //*myPtr2 = 400;
    int* myPtr3 = &x;
    *myPtr3 = 1000;

    cout << x << endl;
    cout << *myPtr << endl;
    cout << myPtr << endl;
    cout << &x << endl;

    myPtr = &y;
    cout << y << endl;
    cout << *myPtr << endl;
    cout << myPtr << endl;
    cout << &y << endl;

    while(result)
    {
        if(result == true)
        {
            isValid = true;
        }
        else
        {
            isValid = false;
        }
    }

    /*for(int rows = 0; rows < ROWS; rows++)
    {
        for(int cols = 0; cols < COLS; cols++)
        {
            cout << setw(10) << data[rows][cols];
        }
        cout << endl;
    }
    return 0;*/
}
