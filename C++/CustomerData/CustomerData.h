#ifndef CUSTOMERDATA_H
#define CUSTOMERDATA_H
#include "PersonData.h"
#include <string>

using namespace std;

//Has the number and mailing list information of the customer
//Also pulls information of the person from PersonData class
class CustomerData : public PersonData
{
    private:
        int customerNumber; //Phone number of the customer
        bool mailingList;   //Is the customer on the mailing list?

    public:
        //Constructors
        CustomerData();
        CustomerData(string ln, string fn, string adr, string cty,
                     string ste, string zip, string num, int cn, bool ml);
        //Deconstructor
        virtual ~CustomerData();

        //Mutator Functions
        void setCustomerNumber(int cn);
        void setMailingList(bool ml);

        //Accessor Functions
        int getCustomerNumber();
        bool getMailingList();
};
#endif // CUSTOMERDATA_H
