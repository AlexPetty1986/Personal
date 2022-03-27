#include <iostream>
#include "CustomerData.h"

using namespace std;

//Function Prototype
void DisplayCustomer(CustomerData* cd);

//Main function of the program
int main()
{
    //Information of customer Joan Smith
    CustomerData* smith = new CustomerData("Smith", "Joan", "123 Main Street", "Smithville", "NC",
                                           "99999", "671-260-0054", 12345, true);
    //Information of customer Jenny Jones
    CustomerData* jones = new CustomerData;
    jones->setLastName("Jones");
    jones->setFirstName("Jenny");
    jones->setAddress("555 East Street");
    jones->setCity("Jonesville");
    jones->setState("VA");
    jones->setZipCode("88888");
    jones->setPhoneNumber("319-218-3176");
    jones->setCustomerNumber(77777);
    jones->setMailingList(false);

    //Display information of customers
    cout << "Customer #1" << endl;
    DisplayCustomer(smith);
    cout << endl << "Customer #2" << endl;
    DisplayCustomer(jones);

    return 0;
}

//Displays the information on the customer
void DisplayCustomer(CustomerData* cd)
{
    string option; //Whether the customer is part of the mailing list

    //Display the information of the customer
    cout << "----------" << endl;
    cout << "Last Name: " << cd->getLastName() << endl;
    cout << "First Name: " << cd->getFirstName() << endl;
    cout << "Address: " << cd->getAddress() << endl;
    cout << "City: " << cd->getCity() << endl;
    cout << "State: " << cd->getState() << endl;
    cout << "ZIP: " << cd->getZipCode() << endl;
    cout << "Phone Number: " << cd->getPhoneNumber() << endl;
    cout << "Customer Number: " << cd->getCustomerNumber() << endl;
    //Determines whether the customer is on the mailing list or not
    if(cd->getMailingList() == 1)
    {
        option = "Yes";
    }
    else if(cd->getMailingList() == 0)
    {
        option = "No";
    }
    cout << "Mailing List?: " << option << endl;
}
