/*
 * Magic 8 Ball
 * Alex Petty
 * 10/27/2021
 */
/*Main()
    Ask user for owner data
    Create MagicEightBall object using that data
    while ( as long as user is not quitting)
    Prompt for a choice and sanitize

    Shake:

        Prompt for question, call ShakeBall()

        Print returned value

    Report:

        Call Report(), print returned value

    Quit:

        Say goodbye

    Anything else:
            Print invalid message
*/
using System;

namespace PE_Magic8Ball_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            string name;
            string choice = null;

            //Start program
            Console.Write("Welcome to Magic 8 Ball Simulator!\n > Who owns this ball? ");
            name = Console.ReadLine();

            //Initialize MagicEightBall class
            MagicEightBall question = new MagicEightBall(name);

            //While the user does not want to quit
            while(choice != "quit")
            {
                Console.Write("What would you like to do?" +
                    "\nYou can 'shake' the ball, get a 'report', or 'quit': ");
                choice = Console.ReadLine().ToLower().Trim();
                switch (choice)
                {
                    //Ask the ball a question
                    case "shake":
                        Console.Write(" > What is your question? ");
                        Console.ReadLine();
                        Console.WriteLine(" > The Magic 8 Ball says: " + question.ShakeBall() + "\n");
                        break;

                    //Ask how many times the ball has been shaken
                    case "report":
                        Console.WriteLine(question.Report() + "\n");
                        break;

                    //Quit shaking the ball
                    case "quit":
                        Console.WriteLine(" > Goodbye!");
                        break;

                    //Not a response
                    default:
                        Console.WriteLine(" > I do not recognize that response.\n");
                        break;
                }
            }
        }
    }
}
