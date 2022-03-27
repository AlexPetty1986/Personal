#ifndef CORPFUNCTIONS_H_INCLUDED
#define CORPFUNCTIONS_H_INCLUDED
#include <string>
#include <iostream>
#include <iomanip>

using namespace std;

struct Division
{
    string divName;
    double salesDiv1, salesDiv2, salesDiv3, salesDiv4;
    double yearlySales, average;
};

void DisplayCorpInformation(const Division& east,
                            const Division& west,
                            const Division& north,
                            const Division& south);

void FindTotalAndAverageSales(Division& div);

void GetDivisionSales(Division& div);

#endif // CORPFUNCTIONS_H_INCLUDED
