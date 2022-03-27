#include "NegativeScore.h"

//Assigns values for the negative score and the message that explains it
NegativeScore::NegativeScore(string msg, double grade)
{
    negative = grade;
    message = msg;
}

//Deconstructor
NegativeScore::~NegativeScore()
{
    //dtor
}

//Getters
//Gets the grade that has caused the exception
double NegativeScore::getScore()
{
    return negative;
}

//Gets the message needed to specify why the exception happened
string NegativeScore::getMessage()
{
    return message;
}

