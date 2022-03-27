#include "TestFunctions.h"

using namespace std;

int main()
{
    double* scores = nullptr;   //Array for the test scores
    int size;   //Size of the array
    double avg; //Average of the test scores

    //Input total tests being graded
    cout << "How many tests are being graded?: ";
    cin >> size;

    scores = new double[size];

    //While score isn't a nullptr
    while(scores != nullptr)
    {
        //Size is greater than or equal to 0
        if(size >= 0)
        {
            //Puts the grades into the array
            GetGrades(scores, size);

            //If no test scores are being inputted
            if(size == 0)
                avg = 0;
            //If the size is greater than 0
            else
                avg = Average(scores, size);

            //Display the test scores and the average
            cout << "Scores" << endl;
            DisplayGrades(scores, size);
            cout << "Average Score: " << avg << endl;;

            //Makes scores a nullptr to end the while loop
            delete [] scores;
            scores = nullptr;
        }
        //Size is less than 0
        else
        {
            cout << "INVALID INPUT DETECTED!!!" << endl;

            cout << "What size array to use?: ";
            cin >> size;
        }
    }

    return 0;
}
