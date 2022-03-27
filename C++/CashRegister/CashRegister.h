#ifndef CASHREGISTER_H_INCLUDED
#define CASHREGISTER_H_INCLUDED
#include "InventoryItem.h"
#include <iostream>
#include <iomanip>
#include <string>

using namespace std;

//
class CashRegister
{
private:

    InventoryItem *inventory;   //Information on items currently in stock
    int option;                 //User choice of item they want to purchase
    int amount;                 //Amount of items that are currently in stock
    double itemPrice;           //Price of the item being purchased
    double tax;                 //Tax of the item purchased
    double itemTotal;           //Total of purchase without tax
    double totalTax;            //Total of purchase with tax

    void findPrice();       //Finds the price of the item
    void findTax();         //Finds the tax of the item
    void findTotal();       //Finds the total amount of the item
    void itemOptions();     //Displays the items that are in stock
    bool changeQuantity();  //Determines whether the quantity of an item needs to be changed

public:

    CashRegister(InventoryItem*, int);
    void Purchase();
    void displayPurchase();
};

#endif // CASHREGISTER_H_INCLUDED
