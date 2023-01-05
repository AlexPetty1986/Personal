#pragma once
#include <iostream>
using namespace std;

template <class T> class Stack
{
private:
	T* stack;
	int stackSize;

public:
	Stack();
	Stack(const Stack& copyStack);
	Stack& operator=(const Stack& copyStack);
	~Stack();
	void Push(T item);
	T Pop();
	void Print();
	int GetSize();
	bool IsEmpty();
};

//Constructor
template <typename T> Stack<T>::Stack()
{
	stack = new T[1];
	stackSize = 0;
	stack[0] = NULL;
}

//Copy Constructor
template <typename T> Stack<T>::Stack(const Stack& copyStack)
{
	stackSize = copyStack.stackSize;
	stack = new T[stackSize];

	//for each item in the stack
	for(int i = 0; i < stackSize; i++)
	{
		stack[i] = copyStack.stack[i];
	}
}

//Copy Assignment Operator
template <typename T> Stack<T>&Stack<T>::operator=(const Stack& copyStack)
{
	if (this == &copyStack)
	{
		return *this;
	}

	if (stack != nullptr)
	{
		delete stack;
		stack = nullptr;
	}

	stackSize = copyStack.stackSize;
	stack = new T[stackSize];

	copy(copyStack.stack, copyStack.stack + copyStack.stackSize, stack);

	return *this;
}

//Destructor
template <typename T> Stack<T>::~Stack()
{
	delete stack;
	stack = nullptr;
};

//Pushes item to top of stack
template <typename T> void Stack<T>::Push(T item)
{
	//Double the size of the stack
	if (stack[stackSize] == 0)
	{
		T* replaceStack = stack;
		stack = new T[(stackSize + 1) * 2];
		stack[((stackSize) * 2) + 1] = 0;
		for (int i = 0; i < stackSize; i++)
		{
			stack[i] = replaceStack[i];
		}

		delete replaceStack;
	}
	stack[stackSize] = item;
	stackSize++;
}

//Removes item from top of stack
template <typename T> T Stack<T>::Pop()
{
	if (IsEmpty())
	{
		return NULL;
	}

	T item = stack[stackSize - 1];

	stack[stackSize - 1] = NULL;
	stackSize--;

	return item;
}

//Prints out what is currently in the stack
template <typename T> void Stack<T>::Print()
{
	for (int i = stackSize - 1; i > -1; i--)
	{
		cout << stack[i] << " ";
	}

	cout << endl;
}

//Prints out the current size of the stack
template <typename T> int Stack<T>::GetSize()
{
	return stackSize;
}

//Checks to see if the stack is empty
template <typename T> bool Stack<T>::IsEmpty()
{
	//if there is nothing currently in the stack
	if (stackSize <= 0)
	{
		return true;
	}

	//if something exists in the stack
	else
	{
		return false;
	}
}

