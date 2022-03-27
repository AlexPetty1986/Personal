#include "RoomCarpet.h"

//Constructor
RoomDimension::RoomDimension()
{

}

//Initializes the room dimensions of length and width
RoomDimension::RoomDimension(FeetInches l, FeetInches w)
{
    length = l;
    width = w;
}

//Sets the length of the room
void RoomDimension::setLength(FeetInches l)
{
    length = l;
}

//Sets the width of the room
void RoomDimension::setWidth(FeetInches w)
{
    width = w;
}

//Finds the area of the room using the provided parameters
FeetInches RoomDimension::getArea(FeetInches l, FeetInches w)
{
    FeetInches area = w.multiply(l);

    return area;
}
