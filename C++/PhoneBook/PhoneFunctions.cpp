#include "PhoneFunctions.h"

//Locates the specific contact based on user input
void LocateContacts(const string data[], int size)
{
    string locate;

    cout << "Enter the full name or part of it to locate contact: ";
    cin >> locate;

    cout << endl;
    for(int count = 0; count < size; count++)
    {
        if(data[count].find(locate) < data[count].size());
        {
            cout << "Person Found: ";
            cout << data[count]<< endl;
        }
    }
}
