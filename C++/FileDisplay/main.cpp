#include "FileFunctions.h"

int main()
{
    string fName;

    fName = GetFilename();
    DisplayFileContent(fName);
    return 0;
}
