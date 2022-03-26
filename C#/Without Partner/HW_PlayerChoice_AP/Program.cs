/*
 * Player Choice
 * Alex Petty
 * 09/15/2021
 */

/*
Main method // Notice how the code for each scene is “finished up” before the next starts
{
	Declare and initialize all “player” variables here

	// Scene 1
    Print scene 1’s initial story and choices
    Create a variable to hold the user’s first choice

    Get the input from the user and save in the choice variable
    Sanitize the user input

    Use a switch to determine which choice was made
    For each valid choice:
    If the choice should change a variable:
	    Change a variable if needed
	    Print out some kind of message
    If the choice was invalid
    Print an error message and exit console

    // Scene 2
    Print scene 2’s initial story and choices
    If you need to print any extra choices (based on a variable changed in scene 1)
	    Print the extra choice

    Get the input from the user and save in the choice variable
    Sanitize the user input

    Use a switch to determine which choice was made
    For each valid choice:
    If the choice should change a variable:
	    Change a variable if needed
	    Print out some kind of message
    If the choice was invalid
    Print an error message and exit console

    // Scene 3
    Print scene 3’s initial story

    Use a series of compound if/else if blocks to determine which of at least 4 different endings is printed.
} 
*/

//Tell the compiler where get other functionality from
using System;

namespace HW_PlayerChoice_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //variables that will affect your quest
            bool isPoisoned = false;
            bool trueGrail = false;
            bool falseGrail = false;
            bool readRiddle = false;
            //The choice of the player
            string choice;

            //Scene 1
            //Only two choices available
            Console.Write("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                "\nScene 1 - Two Paths" +
                "\n\nYou enter a cave, hoping to find the Holy Grail, said to give the one who holds it " +
                "eternal \nyouth once they drink from the fountain in the deepest part of the cave using the grail. " +
                "\nAfter walking for about ten minutes you come across two paths, one going left " +
                "and one going right. \nYou try peaking down each to see which one is safer but both path are too dark." +
                "\n\nWill you LEFT or RIGHT? \n > ");
            choice = Console.ReadLine().ToLower().Trim();

            switch(choice)
            {
                //If you chose left
                case "left":
                    readRiddle = true;
                    Console.WriteLine("You decide to go left, which ended up being the right decision." +
                        "\nWhile walking you find a riddle written on the wall." +
                        "\nYou decide to read it hoping it will help you on your quest." +
                        "\n\"The Holy Grail, though powerful, does not look like a something a king would use.\"");
                    break;

                //If you chose right
                case "right":
                    isPoisoned = true;
                    Console.WriteLine("You decide to go right, but it was a foolish mistake." +
                        "\nYou get hit with a poison dart, making your quest for the grail important to survive!!");
                    break;

                //Incorrect answer
                default:
                    Console.WriteLine("You could not make up your mind." +
                        "\nWhile thinking you get bitten by snake, known to have a powerful venom." +
                        "\nSadly, you end up dying on the spot, becoming a permanent resident of the cave." +
                        "\nGAME OVER");
                    return;
            }

            //Scene 2
            //Could potentially be given a third option
            Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                "\nScene 2 - Two Grails" +
                "\n\nYou walk farther into the cave and find a peculiar sight." +
                "\nIn front of you are two grails, each sitting on their own pedestal." +
                "\nOne of them is lined with gold and covered in jewels." +
                "\nThe other one, had nothing on it, just a simple clay grail." +
                "\n\nWill you take the one made of GOLD, or the one made of CLAY?");

            //If you had seen the riddle
            if(readRiddle == true)
            {
                Console.WriteLine("OR do you want to remember the RIDDLE?");
            }
            Console.Write(" > ");
            choice = Console.ReadLine().ToLower().Trim();

            //If you end up reading the riddle
            if(readRiddle == true)
            {
                switch (choice)
                {
                    //If you chose the gold grail
                    case "gold":
                        falseGrail = true;
                        Console.WriteLine("You decide to pick up the grail made of gold." +
                            "\nThe one you didn't choose falls into the abyss, never to be seen again" +
                            "\nThen you press on towards the fountain.");
                        break;

                    //If you chose the clay grail
                    case "clay":
                        trueGrail = true;
                        Console.WriteLine("You decide to pick up the grail made of clay." +
                            "\nThe one you didn't choose falls into the abyss, never to be seen again" +
                            "\nThen you press on towards the fountain.");
                        break;

                    case "riddle":
                        trueGrail = true;
                        Console.WriteLine("You remember the riddle that you had read before getting here." +
                            "\nAfter thinking it over, you realize what the riddle was saying and pick up the grail made of clay.");
                        break;

                        //Incorrect answer
                    default:
                        Console.WriteLine("You could not make up your mind." +
                            "\nWhile thinking you get bitten by snake, known to have a powerful venom." +
                            "\nSadly, you end up dying from the poison, becoming a permanent resident of the cave." +
                            "\nGAME OVER");
                        return;
                }
            }

            //If you didn't read the riddle and instead were poisoned
            else
            {
                switch(choice)
                {
                    //If you chose the gold grail
                    case "gold":
                        falseGrail = true;
                        Console.WriteLine("You decide to pick up the grail made of gold." +
                        "\nThe one you didn't choose falls into the abyss, never to be seen again" +
                        "\nThen you press on towards the fountain.");
                        break;

                    //If you chose the clay grail
                    case "clay":
                        trueGrail = true;
                        Console.WriteLine("You decide to pick up the grail made of clay." +
                            "\nThe one you didn't choose falls into the abyss, never to be seen again" +
                            "\nThen you press on towards the fountain.");
                        break;

                    //Incorrect answer
                    default:
                        Console.WriteLine("You could not make up your mind." +
                            "\nWhile thinking you get bitten by snake, known to have a powerful venom." +
                            "\nSadly, you end up dying from the poison, becoming a permanent resident of the cave." +
                            "\nGAME OVER");
                        return;
                }

            }
            //Scene 3
            //Your actions have consequences
            Console.WriteLine("\n\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~" +
                "\nScene 3 - The Fountain" +
                "\n\nYou keep walking after grabbing one of the grails until you get a large room." +
                "\nInside that room is a fountain, the one that you have been looking for.");
            //If you had been poisoned earlier
            if(isPoisoned == true) 
            {
                Console.WriteLine("You run over to the fountain, with the grail in your hand." +
                    "\nYou then drink from the fountain, hoping it will cure you of the poison.");
            }

            else
            {
                Console.WriteLine("You slowly walk to the fountain so no traps are activated." +
                    "\nAs you walk over you start hoping that the legends were true.");
            }

            if (isPoisoned == true && falseGrail == true)
            {
                Console.WriteLine("\nSadly, the grail you had picked up was a fake." +
                    "\nSoon after realizing it you die from the poison." +
                    "\nGAME OVER");
            }

            else if (isPoisoned == true && trueGrail == true)
            {
                Console.WriteLine("\nYou had made the correct choice." +
                    "\nThe grail has cured you of your poison and has given you eternal youth." +
                    "\nCONGRATULATIONS");
            }

            else if (readRiddle == true && falseGrail == true)
            {
                Console.WriteLine("\nWhile you didn't die, you sadly picked the incorrect grail." +
                    "\nDisappointed, you head back home, hoping to get some good coin from the false grail." +
                    "\nGAME OVER");
            }

            else if(readRiddle == true && trueGrail == true)
            {
                Console.WriteLine("\nYou chose correctly, you look in a mirror and notice you have turned younger." +
                    "\nYou have obtained the power of the grail!!" +
                    "\nCONGRATULATIONS");
            }
        }
    }
}
