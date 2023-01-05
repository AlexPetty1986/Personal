#include "stack.h"

void wrapper()
{
    //Create the array stacks
    Stack<int> intStack = Stack<int>();
    Stack<double> duoStack = Stack<double>();
    Stack<char> charStack = Stack<char>();

    //add some values into the array stacks
    for (int i = 0; i < 10; i++)
    {
        if (i == 0 || i == 9)
        {
            cout << "Is int stack empty?: " << intStack.IsEmpty() << endl;
            cout << "Is double stack empty?: " << duoStack.IsEmpty() << endl;
            cout << "Is char stack empty?: " << charStack.IsEmpty() << endl << endl;
        }

        intStack.Push(i + 1);
        duoStack.Push((i + 1) * 0.33f);
        charStack.Push(i + 97);
    }

    //print out info about int stack
    //print out current size of stack
    cout << "There is a total of " << intStack.GetSize() << " items in the stack." << endl;
    intStack.Print();
    cout << endl;

    //pop stuff out of the stack
    for (int i = 0; i < 3; i++)
    {
        cout << "Item removed from top of stack: " << intStack.Pop() << endl;
    }

    //print out new size of stack
    cout << "\nThere is a total of " << intStack.GetSize() << " items in the stack." << endl;

    //print out what is currently in stack
    cout << "Here are the current items in the stack:" << endl;
    intStack.Print();

    //print out info about int stack
    //print out current size of stack
    cout << "\nThere is a total of " << duoStack.GetSize() << " items in the stack." << endl;
    duoStack.Print();
    cout << endl;

    //pop stuff out of the stack
    for (int i = 0; i < 3; i++)
    {
        cout << "Item removed from top of stack: " << duoStack.Pop() << endl;
    }

    //print out new size of stack
    cout << "\nThere is a total of " << duoStack.GetSize() << " items in the stack." << endl;

    //print out what is currently in stack
    cout << "Here are the current items in the stack:" << endl;
    duoStack.Print();

    //print out info about char stack
    //print out current size of stack
    cout << "\nThere is a total of " << charStack.GetSize() << " items in the stack." << endl;
    charStack.Print();
    cout << endl;

    //pop stuff out of the stack
    for (int i = 0; i < 3; i++)
    {
        cout << "Item removed from top of stack: " << charStack.Pop() << endl;
    }

    //print out new size of stack
    cout << "\nThere is a total of " << charStack.GetSize() << " items in the stack." << endl;

    //print out what is currently in stack
    cout << "Here are the current items in the stack:" << endl;
    charStack.Print();

    //create a new array stack using the copy constructor
    Stack<int> newIntStack = intStack;
    cout << endl;

    //print out info about copied int stack
    //print out current size of stack
    cout << "There is a total of " << newIntStack.GetSize() << " items in the stack." << endl;
    cout << "Here are the current items in the stack:" << endl;
    newIntStack.Print();
    cout << endl;

    //pop stuff out of the stack
    for (int j = 0; j < 3; j++)
    {
        cout << "Item removed from top of stack: " << newIntStack.Pop() << endl;
    }

    //print out new size of stack
    cout << "\nThere is a total of " << newIntStack.GetSize() << " items in the stack." << endl;

    //print out what is currently in stack
    cout << "Here are the current items in the stack:" << endl;
    newIntStack.Print();

    //use the copy assignment operator to make the 
    //new array stack equal to the array stack it copied from
    newIntStack = intStack;

    //print out new size of stack
    cout << "\nThere is a total of " << newIntStack.GetSize() << " items in the stack." << endl;

    //print out what is currently in stack
    cout << "Here are the current items in the stack:" << endl;
    newIntStack.Print();
}

int main()
{
    wrapper();
    _CrtDumpMemoryLeaks();
    return 0;
}
