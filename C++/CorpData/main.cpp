#include "CorpFunctions.h"

using namespace std;

int main()
{
    Division div1, div2, div3, div4;

    div1.divName = "North";
    div2.divName = "South";
    div3.divName = "East";
    div4.divName = "West";

    GetDivisionSales(div3);
    GetDivisionSales(div2);
    GetDivisionSales(div1);
    GetDivisionSales(div4);

    FindTotalAndAverageSales(div1);
    FindTotalAndAverageSales(div2);
    FindTotalAndAverageSales(div3);
    FindTotalAndAverageSales(div4);

    DisplayCorpInformation(div3, div4, div1, div2);

    return 0;
}
