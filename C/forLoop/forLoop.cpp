#include <stdio.h>
#include <conio.h>
#include <stdlib.h>

int w, h;

int main()
{
    printf("Input the width of the square: ");
    scanf_s("%d", &w);
    printf("Input the height of the square: ");
    scanf_s("%d", &h);

    for (int i = 0; i < h; i++)
    {
        for (int j = 0; j < w; j++)
        {
            printf("@");
        }
        printf("\n");
    }
}

