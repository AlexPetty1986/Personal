#include <stdio.h>
#include <Windows.h>
#include <conio.h>
#include <stdlib.h>

//variables
bool run= true;
float a, b, total, userInput;

//basic calculator program that does 
//addition, subtraction, multiplication, division and exponents
int main()
{
    while (run)
    {
        printf("Please pick an option:\n1) Addition\n2) Subtraction\n3) Multiplication\n4) Division\n5) Exponent\n6) Quit");
        userInput=_getch() - '0';
        //addition
        if (userInput == 1)
        {
            system("cls");
            printf("Enter your first number: ");
            scanf_s("%g", &a);
            printf("\nEnter your second number: ");
            scanf_s("%g", &b);
            total = a + b;
            printf("\nThe sum of your two numbers is %g\nPress any key to reset", total);
            _getch();
            system("cls");
        }
        //subtraction
        else if(userInput == 2)
        {
            system("cls");
            printf("Enter your first number: ");
            scanf_s("%g", &a);
            printf("\nEnter your second number: ");
            scanf_s("%g", &b);
            total = a - b;
            printf("\nThe difference of your two numbers is %g\nPress any key to reset", total);
            _getch();
            system("cls");
        }
        //multiplication
        else if (userInput == 3)
        {
            system("cls");
            printf("Enter your first number: ");
            scanf_s("%g", &a);
            printf("\nEnter your second number: ");
            scanf_s("%g", &b);
            total = a * b;
            printf("\nThe product of your two numbers is %g\nPress any key to reset", total);
            _getch();
            system("cls");
        }
        //division
        else if (userInput == 4)
        {
            system("cls");
            printf("Enter your first number: ");
            scanf_s("%g", &a);
            printf("\nEnter your second number: ");
            scanf_s("%g", &b);
            if (b == 0)
            {
                printf("\nError! Unable to divide by 0!\nPress any key to reset");
            }
            else
            {
                total = a / (float)b;
                printf("\nThe quotient of your two numbers is %g\nPress any key to reset", total);
            }
            _getch();
            system("cls");
        }
        else if (userInput == 5)
        {
            system("cls");
            printf("Enter your base value: ");
            scanf_s("%g", &a);
            printf("\nEnter your exponent: ");
            scanf_s("%g", &b);
            total = 1;
            for(int i=0; i < b; i++)
            {
                total *= a;
            }
            printf("\nThe power of your two numbers is %g\nPress any key to reset", total);
            _getch();
            system("cls");
        }
        else if (userInput == 6)
        {
            run = false;
        }
        else
        {
            system("cls");
            printf("Incorrect input!\nPress any key to reset");
            _getch();
            system("cls");
        }
    }
}

