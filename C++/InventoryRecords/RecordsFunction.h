#ifndef RECORDSFUNCTION_H_INCLUDED
#define RECORDSFUNCTION_H_INCLUDED
#include <iostream>
#include <fstream>
#include <string>
#include <iomanip>

using namespace std;

//the data for the inventory items
struct Inventory
{
    char item[30];
    int quantity;
    double wholeSale;
    double retail;
};

//adds an item to the list
void AddItem(fstream* fileHandler);
//displays an item form the list
void DisplayItem(fstream* fileHandler, int numberInventory);
//modifies an item form the list
void EditItem(fstream* fileHandler, int numberInventory);
#endif // RECORDSFUNCTION_H_INCLUDED
