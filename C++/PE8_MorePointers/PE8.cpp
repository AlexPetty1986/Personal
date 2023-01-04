#include <iostream>
#include <cstring>
#include "functions.h"

using namespace std;

int main()
{
    int value = 9;

    cout << value << endl;
    changeVariable(value);
    changePointer(&value);

    int numbers[99];
    numbers[98] = -1;
    int* final = numbers;

    cout << endl << getLengthArray(final);
    cout << endl << getLengthPointer(final) << endl;
    
    int newArray = 5;
    int* stack = createStackArray();
    int* heap = createHeapArray(newArray);

    cout << endl;

    //the stack ends up printing out a bunch of random numbers
    //it does this because it keeps pulling data from the top of the stack
    //it then ends up getting to the end of the array, which is -1
    for (int i = 0; i < sizeof(stack); i++)
    {
        cout << stack[i];
    }
    
    cout << endl;

    for (int i = 0; i < sizeof(stack); i++)
    {
        cout << heap[i];
    }

    cout << endl;
}

void changeVariable(int choice)
{
    choice = 99;

    cout << "Inside changeVariable() - variable's value is now: " << choice << endl;
}

void changePointer(int* choice)
{
    choice = new int(23);

    cout << "Inside changeVariable() - variable's value is now: " << *choice << endl;
}

int getLengthArray(int numbers[])
{
    int elements = 0;

    for (int i = 0; i < sizeof(numbers); i++)
    {
        if (numbers[i] != -1)
        {
            elements++;
        }
    }

    return elements;
}

int getLengthPointer(int* numberPoint)
{
    int elementPoint = 0;

    for (int i = 0; i < sizeof(numberPoint); i++)
    {
        if (numberPoint[i] != -1)
        {
            elementPoint++;
        }
    }

    return elementPoint;
}

int* createStackArray()
{
    int stackArray[5];

    for (int i = 0; i < 5; i++)
    {
        stackArray[i] = i;
    }

    int* numero = stackArray;

    return numero;
}

int* createHeapArray(int heapValue)
{
    int* heapArray = new int[heapValue];

    for (int i = 0; i < heapValue; i++)
    {
        heapArray[i] = i;
    }

    int* numero = heapArray;
    delete[] heapArray;

    return numero;
}