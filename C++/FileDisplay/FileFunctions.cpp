#include "FileFunctions.h"

string GetFilename()
{
    string fileName = "";

    cout << "Enter file name ";
    getline(cin, fileName);

    return fileName;
}
void DisplayFileContent(string fileName)
{
    ifstream inFile(fileName);
    string data;
    int counter = 0;

    if(inFile)
    {
        getline(inFile, data);
        while(inFile)
        {
            cout << data << endl;
            counter ++;
            if(counter == 24)
            {
                cout << "Press Enter to Continue" << endl;
                getchar();
                counter = 0;
            }

            getline(inFile, data);
        }
    }
    else
    {
        cout << "Invalid" << endl;
    }

    inFile.close();
}

