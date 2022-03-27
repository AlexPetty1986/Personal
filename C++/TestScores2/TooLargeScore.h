#ifndef TOOLARGESCORE_H
#define TOOLARGESCORE_H
#include <string>

using namespace std;

//Exception class that detects if there is a
//Score that is greater than 100
class TooLargeScore
{
    private:
        string message;     //Message to explain the exception
        double large;       //The grade that is greater than 100

    public:
        //Constructor
        TooLargeScore(string msg, double grade);

        //Deconstructor
        virtual ~TooLargeScore();

        //Getters
        //Gets the message that explains the exception
        string getMessage();
        //Gets the score that caused the exception
        double getScore();
};

#endif // TOOLARGESCORE_H
