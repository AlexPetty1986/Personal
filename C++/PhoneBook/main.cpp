#include "PhoneFunctions.h"

//Main function of the program
int main()
{
    const string Contact_List[] = {"Renee Javens, 678-1223", "Joe Looney, 586-0097",
                            "Geri Palmer, 223-8787", "Lynn Presnell, 887-1212",
                            "Bill Wolfe, 223-8878", "Sam Wiggins, 486-0998",
                            "Bob Kain, 586-8712", "Tim Haynes, 586-7676",
                            "John Johnson, 223-9037", "Ron Palmer, 486-2783"};

    LocateContacts(Contact_List, SIZE);

    return 0;
}
