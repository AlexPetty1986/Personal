#include "CashRegister.h"
#include <iomanip>
#include <iostream>

using namespace std;

//Puts the information of the items in an array
CashRegister::CashRegister(InventoryItem* item, int size)
{
    inventory = new InventoryItem[size];

    for (int i = 0; i < size; i++)
    {
        inventory[i] = item[i];
    }
}

//Displays the options that the user has and asks them if they want to make a purchase
void CashRegister::itemOptions()
{
    cout << "#" << setw(10) << "Item" << setw(25) << "# in Stock\n";

    for(int i = 0; i < 5; i++)
    {
        cout << (i + 1) << setw(20) << inventory[i].getDescription() <<
        setw(10) << inventory[i].getUnits() << endl;
    }

    cout << "What would you like to purchase?: ";
    cin >> option;
    while(option <= 0 || option > 5)
    {
        cout << "Incorrect option!!" << endl;
        cout << "What would you like to purchase?: ";
        cin >> option;
    }
    option --;
}

//Determines the price of the purchase before tax
void CashRegister::findPrice()
{
    itemPrice = inventory[option].getCost() * 1.3;
}

//Finds the tax for the purchase
void CashRegister::findTax()
{
    tax = itemTotal * 0.06;
}

//Finds the final total of the purchase after tax
void CashRegister::findTotal()
{
    totalTax = itemTotal + tax;
}

bool CashRegister::changeQuantity()
{
    int quantity = inventory[option].getUnits();
    if(quantity >= amount)
    {
        inventory[option].setUnits(quantity - amount);
        return true;
    }
    else
    {
        return false;
    }
}

//Asks the user how many items they want and then completes the transaction
void CashRegister::Purchase()
{
    itemOptions();

    cout << "How many items do you want?: ";
    cin >> amount;

    while(amount < 0)
    {
        cout << "Invalid amount!!" << endl;
        cout << "Enter a valid amount: ";
        cin >> amount;
    }

    findPrice();

    itemTotal = amount * itemPrice;

    findTax();

    findTotal();

    if(changeQuantity())
    {
        displayPurchase();
    }
    else
    {
        cout << "Not enough items in stock." << endl;
    }

}

//Displays the information of the purchase
void CashRegister::displayPurchase()
{
    cout << fixed << showpoint << setprecision(2);
    cout << "Total before tax: $" << itemTotal << endl;
    cout << "Tax: $" << tax << endl;
    cout << "Total after tax: $" << totalTax << endl;
}
