#include "CustomerData.h"

//Constructor
CustomerData::CustomerData()
{
    customerNumber = 0;
    mailingList = false;
}

CustomerData::CustomerData(string ln, string fn, string adr, string cty, string ste, string zip, string num, int cn, bool ml)
{
    //Information from PersonData
    setLastName(ln);
    setFirstName(fn);
    setAddress(adr);
    setCity(cty);
    setState(ste);
    setZipCode(zip);
    setPhoneNumber(num);

    //Information form CustomerData
    customerNumber = cn;
    mailingList = ml;
}

//Deconstructor
CustomerData::~CustomerData()
{
    //dtor
}

//Mutator Functions/Setters
void CustomerData::setCustomerNumber(int cn)
{
    customerNumber = cn;
}
void CustomerData::setMailingList(bool ml)
{
    mailingList = ml;
}

//Accessor Functions/Getters
int CustomerData::getCustomerNumber()
{
    return customerNumber;
}

bool CustomerData::getMailingList()
{
    return mailingList;
}

