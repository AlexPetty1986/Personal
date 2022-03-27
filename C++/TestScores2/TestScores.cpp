#include "TestScores.h"

//Constructor that gets the array
template <class T>
TestScores<T>::TestScores(T val[])
{
    GradeArray = val;
}

//Deconstructor
template <class T>
TestScores<T>::~TestScores()
{

}

//Gets the average of the grades in the array
//If a score is invalid an exception will be thrown
template <class T>
T TestScores<T>::getAverage()
{
    //used to get item from the array
    T* ary = GradeArray;

    for(int i = 0; i < SIZE; i++)
    {
        //Save grade from array into variable grade
        T grade = ary[i];

        //If one of the grades ends up being less than 0
        if(grade < 0)
        {
            //Throws NegativeScore exception
            throw NegativeScore("There is a score that is less than 0: ", grade);
        }

        //If one of the grades ends up being greater than 100
        else if(grade > 100)
        {
            //Throws TooLargeScore exception
            throw TooLargeScore("There is a score that is greater than 100: ", grade);
        }

        //Adds the grade into the average
        average += grade;
    }

    //Determine the average of all of the grades if no exception was thrown
    average /= SIZE;

    //Return average to the main program
    return average;
}
