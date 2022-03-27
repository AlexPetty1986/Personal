#include "PersonData.h"

//Constructors
PersonData::PersonData()
{
    lastName = "";
    firstName = "";
    address = "";
    city = "";
    state = "";
    zipCode = "";
    phoneNumber = "";
}

PersonData::PersonData(string ln, string fn, string adr, string cty, string ste, string zip, string num)
{
    lastName = ln;
    firstName = fn;
    address = adr;
    city = cty;
    state = ste;
    zipCode = zip;
    phoneNumber = num;
}

//Deconstructor
PersonData::~PersonData()
{
    //dtor
}

//Mutator Functions/Setters
void PersonData::setLastName(string ln)
{
    lastName = ln;
}

void PersonData::setFirstName(string fn)
{
    firstName = fn;
}

void PersonData::setAddress(string adr)
{
    address = adr;
}

void PersonData::setCity(string cty)
{
    city = cty;
}

void PersonData::setState(string ste)
{
    state = ste;
}

void PersonData::setZipCode(string zip)
{
    zipCode = zip;
}

void PersonData::setPhoneNumber(string num)
{
    phoneNumber = num;
}

//Accessor Functions/Getters
string PersonData::getLastName()
{
    return lastName;
}

string PersonData::getFirstName()
{
    return firstName;
}

string PersonData::getAddress()
{
    return address;
}

string PersonData::getCity()
{
    return city;
}

string PersonData::getState()
{
    return state;
}

string PersonData::getZipCode()
{
    return zipCode;
}

string PersonData::getPhoneNumber()
{
    return phoneNumber;
}
