#include "CashRegister.h"
#include "InventoryItem.h"
#include <iostream>

using namespace std;

const int TOTAL_ITEMS = 5; //Amount of items on sale

//Main function of the program
int main()
{
    int decision = 1;   //Determines if the person wants to make another purchase

    //Items that are currently on sale
    InventoryItem inventory[TOTAL_ITEMS] = {InventoryItem("Adjustable Wrench", 7.99, 10),
        InventoryItem("ScrewDriver", 9.49, 20), InventoryItem("Pliers", 9.50, 35),
        InventoryItem("Ratchet", 10.75, 10), InventoryItem("Socket Wrench", 7.25, 7)};

    //While the person still wants to make a purchase
    while(decision == 1 && decision != 0)
    {
        CashRegister customer(inventory, TOTAL_ITEMS);

        customer.Purchase();

        cout << "Would you like to make another purchase? Yes(1) or No(0): ";
        cin >> decision;

        //If the option is invalid
        while(decision != 1 && decision != 0)
        {
            cout << "Incorrect choice!!" << endl;
            cout << "Would you like to make another purchase? Yes(1) or No(0): ";
            cin >> decision;
        }
    }

    cout << "Have a nice day!";

    return 0;
}
