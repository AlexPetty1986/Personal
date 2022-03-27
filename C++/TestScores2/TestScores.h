#ifndef TESTSCORES_H
#define TESTSCORES_H
#include "NegativeScore.h"
#include "TooLargeScore.h"
#include <iomanip>
#include <iostream>

using namespace std;

//This class takes the array and then finds the average of the grades that are in it
template <class T>
class TestScores
{
    private:
        T* GradeArray; //The array the has all of the grades in it
        T average;     //The average of all of the grades
        int SIZE = 5;  //The size of the array

    public:

        //Constructor
        TestScores(T val[]);

        virtual ~TestScores();

        //Getters
        //Gets the average of all the test scores in the array
        T getAverage();

};

#endif // TESTSCORES_H
