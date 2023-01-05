// PE16.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include <string>
#include <fstream>
using namespace std;

int main()
{
    //Write to text file
    string question = "You like Huey Lewis & the News?\n-Patrick Bateman\n";
    string secret = "It's dangerous to go alone! Take this.\n-Old Man\n";
    string rage = "The Hands of Death could not defeat me, the Sisters of Fate could not hold me, and you will not see the end of this day.\nI will have my revenge!\n-Kratos\n";
    string truth = "Boss...you say there's only room for one Snake...no...the world is better off...without Snakes...\n-Big Boss\n";
    string critical = "Pick a god and pray\n-Frederick\n";
    string lucille = "Lucille, give me strength. Punishment! Look at that. Taking it like a champ! Oh, my goodness!\n-Negan\n";

    for (int i = 0; i < question.length(); i++)
    {
        question[i] ^= 1;
    }

    for (int i = 0; i < secret.length(); i++)
    {
        secret[i] ^= 1;
    }

    for (int i = 0; i < rage.length(); i++)
    {
        rage[i] ^= 1;
    }

    for (int i = 0; i < truth.length(); i++)
    {
        truth[i] ^= 1;
    }

    for (int i = 0; i < critical.length(); i++)
    {
        critical[i] ^= 1;
    }

    for (int i = 0; i < lucille.length(); i++)
    {
        lucille[i] ^= 1;
    }

    ofstream text;
    text.open("text.txt");
    text << question;
    text << rage;
    text << secret;
    text << truth;
    text << critical;
    text << lucille;
    text.close();

    //Read from text file
    string line;
    ifstream newText("text.txt", ios::binary);

    while (newText.good())
    {
        getline(newText, line);

        for (int i = 0; i < line.length(); i++)
        {
            line[i] ^= 1;
        }

        cout << line << endl;
    }
    newText.close();

    return 0;
}
