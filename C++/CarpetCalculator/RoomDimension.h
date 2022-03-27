#ifndef ROOMDIMENSION_H_INCLUDED
#define ROOMDIMENSION_H_INCLUDED

#include "FeetInches.h"

class RoomDimension
{
private:
    FeetInches length;  //Length of the room
    FeetInches width;   //Width of the room
public:
    //Constructors
    RoomDimension();
    RoomDimension(FeetInches, FeetInches);

    //Mutator Functions
    void setLength(FeetInches);
    void setWidth(FeetInches);

    //Accessor Functions
    FeetInches getArea(FeetInches l, FeetInches w);
};

#endif // ROOMDIMENSION_H_INCLUDED
