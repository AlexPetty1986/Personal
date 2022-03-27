#ifndef PERSONDATA_H
#define PERSONDATA_H
#include <string>

using namespace std;

//Has the personal information of the customer
class PersonData
{
    private:
        string lastName;    //Last name of person
        string firstName;   //First name of person
        string address;     //Address of person
        string city;        //City that the person live in
        string state;       //State the person live in
        string zipCode;     //Zip code of person
        string phoneNumber; //Phone number of person

    public:
        //Constructors
        PersonData();
        PersonData(string ln, string fn, string adr, string cty, string ste, string zip, string num);

        //Deconstructor
        virtual ~PersonData();

        //Mutator Functions
        void setLastName(string ln);
        void setFirstName(string fn);
        void setAddress(string adr);
        void setCity(string cty);
        void setState(string ste);
        void setZipCode(string zip);
        void setPhoneNumber(string num);

        //Accessor Functions
        string getLastName();
        string getFirstName();
        string getAddress();
        string getCity();
        string getState();
        string getZipCode();
        string getPhoneNumber();
};
#endif // PERSONDATA_H
