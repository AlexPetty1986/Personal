#include <iostream>

using namespace std;

template <class T>
void swapValues(T& val1, T& val2)
{
    T temp;
    temp = val1;
    val1 = val2;
    val2 = temp;
}

int main()
{
    int int1, int2;
    double double1, double2;
    char char1, char2;

    int1 = 22;
    int2 = -885;

    double1 = 52.36;
    double2 = 85.12;

    char1 = 'A';
    char2 = 'Z';

    cout << int1 << " " << int2 << endl;
    swapValues(int1, int2);
    cout << int1 << " " << int2 << endl;

    cout << double1 << " " << double2 << endl;
    swapValues(double1, double2);
    cout << double1 << " " << double2 << endl;

    cout << char1 << " " << char2 << endl;
    swapValues(char1, char2);
    cout << char1 << " " << char2 << endl;

    return 0;
}
