#include "ArrayFunctions.h"

int*ArrayExpander(int* data, int size)
{
    int* temp = nullptr;

    temp = new int[size * 2];

    for(int count = 0; count < size * 2; count ++)
    {
        if(count < size)
            *(temp + count) = *(data + count);
        else
            *(temp + count) = 0;
    }

    delete [] data;

    return temp;
}
int*ArrayReverse(int* data, int size)
{
    int* temp = nullptr;
    temp = new int[size];
    temp = temp + size;

    for(int count = 0; count < size; count++)
    {
        temp--;
        *temp = data[count];
    }

    return temp;
}
void DisplayGrades(int* data, int size)
{
    for(int count = 0; count < size; count++)
    {
        cout << *(data + count) << endl;
    }
}
