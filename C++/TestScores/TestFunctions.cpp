#include "TestFunctions.h"

//Gets the test scores for the array
void GetGrades (double* scores, int size)
{
    for(int count = 0; count < size; count++)
    {
        cout << "Test Grade #" << (count + 1) << ": ";
        cin >> *(scores + count);

        while (*(scores + count) < 0)
        {
            cout << "INVALID SCORE DETECTED!!!" << endl;
            cout << "Test Grade #" << (count + 1) << ": ";
            cin >> *(scores + count);
        }
    }
}

//Gets the average of the test scores in the array
double Average(double* scores, int size)
{
    double sum = 0;
    double average = 0;

    for(int count = 0; count < size; count++)
    {
        sum += *(scores + count);
    }

    return average = sum / size;
}

//Displays the test scores on the screen
void DisplayGrades(double* scores, int size)
{
    cout << fixed << showpoint << setprecision(2);

    for(int count = 0; count < size; count++)
    {
        cout << *(scores + count) << endl;
    }

}
