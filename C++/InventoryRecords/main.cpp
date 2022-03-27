#include "RecordsFunction.h"

//main function of the program
int main()
{
    //the choice of the user
    int choice;
    //total amount of items in the inventory
    int numInventory;
    //the list itself
    fstream* invenRecord;

    cout << "Would you like to make a list of the inventory?" << endl;
    cout << "Yes(1) or No(2)?: ";
    cin >> choice;
    //if the person chooses to start an inventory list
    if(choice == 1)
    {
        fstream* invenRecord = new fstream("invenrecords.dat", ios::app | ios::binary);
        cout << "\n" << endl;
    }
    //if the person chooses not to make a list
    else if(choice == 2)
    {
        choice = 0;
    }
    while(choice != 0)
    {
        //The options that the user is being provided
        cout << "Inventory List" << endl;
        cout << "What would you like to do?" << endl;
        cout << "Add Inventory Item(1)?" << endl;
        cout << "Display Inventory Item(2)" << endl;
        cout << "Modify Inventory Item(3)" << endl;
        cout << "Quit(0)" << endl;
        cin >> choice;
        //if the person chooses to add an item
        if(choice == 1)
        {
            cout << "\n" << endl;
            invenRecord = new fstream("invenrecords.dat", ios::app | ios::binary);
            AddItem(invenRecord);
            numInventory++;

        }
        //if the person chooses to check an item on the list
        else if(choice == 2)
        {
            cout << "\n" << endl;
            invenRecord = new fstream("invenrecords.dat", ios::in | ios::binary);
            DisplayItem(invenRecord, numInventory);

        }
        //if the person chooses to modify an item on the list
        else if(choice == 3)
        {
            cout << "\n" << endl;
            invenRecord = new fstream("invenrecords.dat", ios::in | ios::out | ios::binary);
            EditItem(invenRecord, numInventory);

        }
        invenRecord->close();
        delete invenRecord;
        invenRecord = nullptr;
    }
    return 0;
}
