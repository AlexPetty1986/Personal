#include "PayrollFunction.h"

using namespace std;

int main()
{
    int empID[NUM_EMP];
    int empHours[NUM_EMP];
    double empPayRate[NUM_EMP];
    double empWages[NUM_EMP];

    GetEmployeeIDs(empID, NUM_EMP);

    GetPayInformation(empID, empHours, empPayRate, NUM_EMP);

    CalculateGrossPay(empWages, empID, empHours, empPayRate, NUM_EMP);

    DisplayInformation(empWages, empID, empHours, empPayRate, NUM_EMP);

    return 0;
}
