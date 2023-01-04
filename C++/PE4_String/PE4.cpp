#include <iostream>
#include <cstring>
using namespace std;

int main()
{
    char first[38] = "supercalifragilistic";
    char second[16] = "expialidocious";
    int total = 0;

    cout << first << "\nSize of word: " << strlen(first) << endl;

    strcat_s(first, second);

    cout << first << "\n";

    for(int i = 0; i < sizeof(first); i++)
    {
        char search = first[i];
        if (search == 'i')
        {
            total++;
        }
    }

    cout << total << endl;
}
