#include "TooLargeScore.h"

//Assigns values for the high score and the message that explains it
TooLargeScore::TooLargeScore(string msg, double grade)
{
    large = grade;
    message = msg;
}

//Deconstructor
TooLargeScore::~TooLargeScore()
{
    //dtor
}

//Getters
//Gets the grade that has caused the exception
double TooLargeScore::getScore()
{
    return large;
}

//Gets the message needed to specify why the exception was thrown
string TooLargeScore::getMessage()
{
    return message;
}
