#include "RecordsFunction.h"

//adds an item to the list
void AddItem(fstream* fileHandler)
{
    Inventory temp;

    if(fileHandler)
    {
        cout << "Enter Item Name: ";
        cin.ignore();
        cin.getline(temp.item,29);
        cout << "Enter Item Quantity: ";
        cin >> temp.quantity;
        cout << "Enter Wholesale Price: ";
        cin >> temp.wholeSale;
        cin.ignore();
        cout << "Enter Retail Price: ";
        cin >> temp.retail;
        cout << "\n" << endl;

        fileHandler->write((char*)(&temp),sizeof(temp));
    }
    else
    {
        cout << "File not opened" << endl;
    }
}
//displays an item form the list
void DisplayItem(fstream* fileHandler, int numberInventory)
{
    Inventory*temp = new Inventory;
    int recNum;

    if(fileHandler)
    {
        cout << "Which item would you like to display?: ";
        cin >> recNum;
        cout << "\n" << endl;

        while(recNum < 1 || recNum > numberInventory)
        {
            cout << "Wrong record number" << endl;
            cout << "Which item would you like to display?: ";
            cin >> recNum;
        }

        fileHandler->seekg((recNum-1)*sizeof(Inventory), ios::beg);
        fileHandler->read((char*)(temp),sizeof(*temp));

        cout << fixed << showpoint << setprecision(2);

        if(temp)
        {
            cout << "Item: " << temp->item << endl;
            cout << "Quantity: " << temp->quantity << endl;
            cout << "Wholesale Cost: $" << temp->wholeSale << endl;
            cout << "Retail Cost: $" << temp->retail << endl;
            cout << "\n" << endl;
        }
        else
        {
            cout << "No Record Found" << endl;
        }

    }
    else
    {
        cout << "File not opened" << endl;
    }
}
//modifies an item form the list
void EditItem(fstream* fileHandler, int numberInventory)
{
    int recNum;
    Inventory*temp = new Inventory;
    Inventory modify;

    if(fileHandler)
    {
        cout << "Which item would you like to modify?: ";
        cin >> recNum;
        cout << "\n" << endl;

        while(recNum < 1 || recNum > numberInventory)
        {
            cout << "Wrong record number" << endl;
            cout << "Which item would you like to modify?: ";
            cin >> recNum;
        }

        fileHandler->seekg((recNum-1)*sizeof(Inventory), ios::beg);
        fileHandler->read((char*)(temp),sizeof(*temp));

        cout << "Enter Item Name: ";
        cin.ignore();
        cin.getline(modify.item,29);
        cout << "Enter Item Quantity: ";
        cin >> modify.quantity;
        cout << "Enter Wholesale Price: ";
        cin >> modify.wholeSale;
        cout << "Enter Retail Price: ";
        cin >> modify.retail;
        cout << "\n" << endl;

        fileHandler->seekp((recNum-1)*sizeof(Inventory), ios::beg);
        fileHandler->write((char*)(&modify),sizeof(modify));
    }
    else
    {
        cout << "File not opened" << endl;
    }
}
