#ifndef NEGATIVESCORE_H
#define NEGATIVESCORE_H
#include <string>

using namespace std;

//Exception class that detects if there is a
//Score that is less than 0
class NegativeScore
{
    private:
        string message;     //The message that explains the exception
        double negative;    //The grade that is less than 0

    public:
        //Constructor
        NegativeScore(string msg, double grade);

        //Deconstructor
        virtual ~NegativeScore();

        //Getters
        //Gets the message that explains the exception
        string getMessage();
        //Gets the score that caused the exception
        double getScore();
};

#endif // NEGATIVESCORE_H
