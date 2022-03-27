#include <iostream>
#include <string>
#include <fstream>

using namespace std;

string GetFilename();
void DisplayFileContent(string fileName);

int main()
{
    string fName;

    fName = GetFilename();
    DisplayFileContent(fName);
    return 0;
}

