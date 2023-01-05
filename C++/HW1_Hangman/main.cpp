//header file
#include "hangman.h"

//main method of the program
int main()
{
    //variables
    char answer[99] = "unlimited";
    char word[99] = "";
    int guessesRemaining = 7;
    int totalLetters = 0;
    int correctLetters = 0;
    char guesses[8] = "";
    char input;
    bool right = false;

    //checks how many letters are in the answer
    for(int k = 0; k < sizeof(answer); k++)
    {
        if (answer[k] != NULL)
        {
            totalLetters++;
        }
    }

    for (int w = 0; w < totalLetters; w++)
    {
        word[w] = '_';
    }

    //Time to start the game
    cout << "Let's Play Hangman!" << endl;
    cout << "Your word has " << totalLetters << " letters in it.\n" << endl;

    //while the player still has guesses or they guess the word
    while (guessesRemaining != 0 && strcmp(answer, word))
    {
        //prompt user for letter
        cout << "What letter do you guess next? ";
        cin >> input;
        cin.ignore(numeric_limits<streamsize>::max(), '\n');
        input = tolower(input);

        cout << "Guess: " << input << endl;
        //to check each letter in the answer
        if (!strchr(word, input))
        {
            for (int i = 0; i < sizeof(answer); i++)
            {
                //if the inputted letter is in the word
                if (input == answer[i])
                {
                    word[i] = answer[i];
                    right = true;
                    correctLetters++;
                }
            }
        }

        //if they inputted an incorrect letter
        if (!strchr(word, input))
        {
            if (right != true)
            {
                strncat_s(guesses, &input, 1);
                guessesRemaining--;
            }
        }

        //display current look of game
        right = false;
        showGallows(guessesRemaining);
        showSolveDisplay(word, guesses);
        cout << "\nYou have " << totalLetters - correctLetters << " letters left.\n";
    }

    //if they got the answer correct
    if (strcmp(answer, word) == 0)
    {
        cout << "You Win!!" << endl;
    }

    //if they failed to guess the word
    else if(guessesRemaining == 0)
    {
        cout << "You Lose!!" << endl;
    }
}


