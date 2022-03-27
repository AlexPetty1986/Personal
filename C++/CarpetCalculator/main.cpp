#include <iostream>
#include "RoomCarpet.h"

using namespace std;

int main()
{
    RoomCarpet room;        //The room that the user wants a carpet in
    int feet;               //Amount of feet in length and width
    int inch;               //The amount of inches in length and width
    double price;           //The price of the carpet per square foot
    int option = 1;         //Choice of whether the user wants to buy another carpet

    while(option == 1 && option != 0)
    {
        //Prompt for the width of the room
        cout << "What is the width of the room in feet and inches?" << endl;
        cout << "Feet: ";
        cin >> feet;
        cout << "Inches: ";
        cin >> inch;

        room.createWidth(feet, inch);

        //Prompt for the length of the room
        cout << "What is the length of the room in feet and inches?" << endl;
        cout << "Feet: ";
        cin >> feet;
        cout << "Inches: ";
        cin >> inch;

        room.createLength(feet, inch);

        //Prompt for price of carpet per square foot
        cout << "What is the price of carpet per square foot?: ";
        cin >> price;
        room.setCost(price);

        //Display total cost of the carpet
        cout << setprecision(2) << fixed << showpoint;
        cout << "Total Cost of carpet purchase: $" << room.totalCost() << endl;

        //Prompt user if they want to go again
        cout << "Would you like to purchase another carpet?" << endl;
        cout << "Yes(1) or No(0): ";
        cin >> option;
    }

    cout << "Have a wonderful day!!" << endl;

    return 0;
}
