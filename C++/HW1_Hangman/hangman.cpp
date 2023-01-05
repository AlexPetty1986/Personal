#include "hangman.h"

//displays the current hang man
void showGallows(int guessesRemaining)
{
    //The changes to the hang man
    if (guessesRemaining == 7)
    {
        cout << "_______\n|\n|\n|\n|\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 6)
    {
        cout << "_______\n|   |\n|\n|\n|\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 5)
    {
        cout << "_______\n|   |\n|   O\n|\n|\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 4)
    {
        cout << "_______\n|   |\n|   O\n|   |\n|\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 3)
    {
        cout << "_______\n|   |\n|   O\n|  /|\n|\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 2)
    {
        cout << "_______\n|   |\n|   O\n|  /|\\\n|\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 1)
    {
        cout << "_______\n|   |\n|   O\n|  /|\\ \n|  /\n|\n|\n" << endl;
    }
    else if (guessesRemaining == 0)
    {
        cout << "_______\n|   |\n|   O\n|  /|\\ \n|  / \\\n|\n|\n" << endl;
    }
}

//Shows the current progress of player as well as the incorrect letters used
void showSolveDisplay(char word[], char guesses[])
{
    cout << "Wrong Guesses: ";
    for (int j = 0; j < sizeof(guesses) + 4; j++)
    {
        cout << guesses[j];
    }
    cout << "\nWord to Solve: " << word << endl;
}