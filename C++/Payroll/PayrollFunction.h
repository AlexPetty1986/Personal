#ifndef PAYROLLFUNCTION_H_INCLUDED
#define PAYROLLFUNCTION_H_INCLUDED
#include <iostream>
#include <iomanip>

using namespace std;

const int NUM_EMP = 3;

void GetEmployeeIDs (int empID[ ], int size);

void GetPayInformation(const int empID[], int hours[ ], double payRate[ ], int size);

void CalculateGrossPay(double grossPay[ ], const int empID[ ], const int hours[ ], const double payRate[], int size);

void DisplayInformation(const double grossPay[ ], const int empID[], const int hours[], const double payRate[], int size);

#endif // PAYROLLFUNCTION_H_INCLUDED

