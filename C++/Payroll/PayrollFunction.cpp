#include "PayrollFunction.h"

void GetEmployeeIDs (int empID[], int size)
{
    for(int count = 0; count < size; count++)
    {
        cout << "Enter the employee ID: ";
        cin >> empID[count];
    }
}

void GetPayInformation(const int empID[], int hours[], double payRate[], int size)
{
    for(int count = 0; count < size; count++)
    {
        cout << "Enter the hours worked for employee " << empID[count] << ": ";
        cin >> hours[count];
        cout << "Enter the pay rate for employee: " << empID[count] << ": ";
        cin >> payRate[count];
    }

}

void CalculateGrossPay(double grossPay[ ], const int empID[],const int hours[], const double payRate[], int size)
{
    for(int count = 0; count < size; count ++)
    {
        grossPay[count] = hours[count] * payRate[count];
    }

}

void DisplayInformation(const double grossPay[ ], const int empID[ ], const int hours[ ], const double payRate[ ], int size)
{
    cout << setw(10) << "Emp ID" << setw(10) << "Hours"
         << setw(15) << "Pay Rate" << setw(10) << "Wages"
         << endl;

    cout << fixed << showpoint << setprecision(2);

    for(int count=0; count < size; count++)
    {
        cout << setw(10) << empID[count] << setw(10) << hours[count]
             << setw(15) << payRate[count] << setw(10) << grossPay[count];

        cout << endl;
    }

}
