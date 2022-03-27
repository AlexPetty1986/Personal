#ifndef ROOMCARPET_H_INCLUDED
#define ROOMCARPET_H_INCLUDED
#include <iomanip>

#include "RoomDimension.h"

class RoomCarpet
{
private:
    double price;       //Price of the carpet per square foot
    RoomDimension room; //The room that the user wants a carpet in

public:
    RoomDimension roomSize; //The length and width of the room
    FeetInches length;      //The length of the room
    FeetInches width;       //The width of the room
    //Constructors
    RoomCarpet();
    RoomCarpet(RoomDimension, double);

    //Mutator Functions
    void setRoom(RoomDimension);
    void setCost(double);
    void createWidth(int f, int i);
    void createLength(int f, int i);

    //Accessor Functions
    double totalCost();
};

#endif // ROOMCARPET_H_INCLUDED
