#include "RoomCarpet.h"

//Constructor
RoomCarpet::RoomCarpet()
{

}

//Initializes the room dimensions and the price
RoomCarpet::RoomCarpet(RoomDimension r, double p)
{
    room = r;
    price = p;
}

//Sets the dimensions of the room
void RoomCarpet::setRoom(RoomDimension r)
{
    room = r;
}

//Sets the price of the carpet per square foot
void RoomCarpet::setCost(double p)
{
    price = p;
}

//Creates the width of the room
void RoomCarpet::createWidth(int f, int i)
{
    RoomCarpet carpet;

    width.setFeet(f);
    width.setInches(i);

    roomSize.setWidth(width);
    carpet.setRoom(roomSize);
}

//Creates the length of the room
void RoomCarpet::createLength(int f, int i)
{
    RoomCarpet carpet;

    length.setFeet(f);
    length.setInches(i);

    roomSize.setLength(length);
    carpet.setRoom(roomSize);
}

//calculates the total cost of the carpet
double RoomCarpet::totalCost()
{
    double totalPrice;
    int roomArea;
    RoomDimension measure;
    measure = room;
    roomArea = measure.getArea(length, width);
    totalPrice = roomArea * price;
    return totalPrice;
}
