#include "CorpFunctions.h"

void DisplayDivision (const Division& div)
{
    cout << div.divName << endl;
    cout << setw(10) << div.salesDiv1
         << setw(10) << div.salesDiv2
         << setw(10) << div.salesDiv3
         << setw(10) << div.salesDiv4 << endl << endl
         << "Total Sales: " << div.yearlySales << endl
         << "Average Sales: " << div.average << endl << endl;
}
void DisplayCorpInformation(const Division& east, const Division& west, const Division& north, const Division& south)
{
    cout << fixed << showpoint << setprecision(2);

    DisplayDivision(north);
    DisplayDivision(south);
    DisplayDivision(east);
    DisplayDivision(west);
}

void GetDivisionSales(Division& div)
{
    cout << "Enter the data for " << div.divName << " division." << endl;
    cout << "For quarter 1: ";
    cin >> div.salesDiv1;
    cout << "For quarter 2: ";
    cin >> div.salesDiv2;
    cout << "For quarter 3: ";
    cin >> div.salesDiv3;
    cout << "For quarter 4: ";
    cin >> div.salesDiv4;
}

void FindTotalAndAverageSales(Division& div)
{
    div.yearlySales = div.salesDiv1 + div.salesDiv2 + div.salesDiv3 + div.salesDiv4;

    div.average = div.yearlySales / 4;
}

