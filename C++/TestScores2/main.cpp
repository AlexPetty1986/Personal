#include <iostream>
#include "TestScores.cpp"

using namespace std;

//The main function of the program
int main()
{
    //Holds the values of the grades
    //Two of them show that the exception classes work
    //While one of them shows that getAverage actually gets the average
    double testGrades1[] = {67.12, 105.99, 87.29, 50.68, 12.00};
    double testGrades2[] = {79.87, 66.66, 43.33, 50.00, 99.99};
    double testGrades3[] = {81.00, 100, 63.65, 55.11, -9.45};

    //First set of grades
    //This set has a score higher than 100 to show that TooLargeScore works
    TestScores<double> grades1(testGrades1);

    //Tries to display the average of the grades
    try
    {
        cout << setprecision(2) << fixed << showpoint;
        cout << "Grade Average: " << grades1.getAverage() << endl;
    }

    //Catches if a grade in the array is greater than 100
    catch(TooLargeScore problem)
    {
        cout << problem.getMessage() << problem.getScore() << endl;
    }

    //Catches if a grade in the array is less than 0
    catch(NegativeScore problem)
    {
        cout << problem.getMessage() << problem.getScore() << endl;
    }

    //Second set of grades
    //This set has no score higher than 100 r greater than 0
    //Shows that GetAverage actually works
    TestScores<double> grades2(testGrades2);

    //Tries to display the average of the grades
    try
    {
        cout << setprecision(2) << fixed << showpoint;
        cout << "Grade Average: " << grades2.getAverage() << endl;
    }

    //Catches if a grade in the array is greater than 100
    catch(TooLargeScore problem)
    {
        cout << problem.getMessage() << problem.getScore() << endl;
    }

    //Catches if a grade in the array is less than 0
    catch(NegativeScore problem)
    {
        cout << problem.getMessage() << problem.getScore() << endl;
    }

    //Third set of grades
    //This set has a negative number to show that NegativeScore works
    TestScores<double> grades3(testGrades3);

    //Tries to display the average of the grades
    try
    {
        cout << setprecision(2) << fixed << showpoint;
        cout << "Grade Average: " << grades3.getAverage() << endl;
    }

    //Catches if a grade in the array is greater than 100
    catch(TooLargeScore problem)
    {
        cout << problem.getMessage() << problem.getScore() << endl;
    }

    //Catches if a grade in the array is less than 0
    catch(NegativeScore problem)
    {
        cout << problem.getMessage() << problem.getScore() << endl;
    }

    return 0;
}
