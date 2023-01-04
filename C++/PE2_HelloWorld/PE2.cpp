using namespace std;
#include <iostream>
#include <stdio.h>


int main()
{

    printf("Hello World!\n\n");

    int decSec = 60 * 60 * 24 * 31;

    float areaCir = 3.14159f * pow(6.2f, 2);

    int divideInt = 6 / 9;

    int divideIntAgain = 9 / 6;

    printf("Total amount of seconds in December: %i\n\n", decSec);

    printf("Area of a circle with an area of 6.2: %f\n\n", areaCir);

    //if you divide using integers and the number ends up with a remainder the answer will end up being 0
    //if the the number is able to divide but still remains with a remainder you will end up with what you ended up with
    printf("6 / 9 = %i\n", divideInt);
    printf("9 / 6 = %i\n", divideIntAgain);
}