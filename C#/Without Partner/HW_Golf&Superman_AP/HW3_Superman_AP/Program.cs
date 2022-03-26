/*
 * Superman
 * Alex Petty
 * 10/13/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace HW3_Superman_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //constants
            const int buildHeight = 660;
            //variables
            double gravConst;
            double velocity;
            string choice = "Y";

            //Time to start the game
            //Explanation of the game
            Console.WriteLine("You target buidling height is {0} feet." +
                "\nPlease enter the gravitational constant for the planet on which Superman" +
                "\nis currently attempting this jump.  Remember that the units should be in" +
                "\nfeet/second².", buildHeight);

            //While the user choice is not N
            while (choice != "N")
            {

                //Prompt user for gravitational constant
                Console.Write("\nGravitational Constant: ");
                gravConst = double.Parse(Console.ReadLine());

                //While the gravitational constant is a negative number
                while(gravConst < 0)
                {
                    Console.WriteLine("That is an invalid value.  It must be a positive number.");
                    //Prompt user for gravitational constant
                    Console.Write("Gravitational Constant: ");
                    gravConst = double.Parse(Console.ReadLine());
                }

                //Calculates Superman's initial velocity
                velocity = 2 * gravConst * buildHeight;
                velocity = Math.Sqrt(velocity);

                //Prints out the result to the screen
                Console.WriteLine("\nSuperman must jump with an initial velocity of at least {0} feet/second.", velocity);

                //Asks the user if they want to play again
                Console.Write("Would you like to play again? (Y/N): ");
                choice = Console.ReadLine().ToUpper().Trim();

                //While the user choice is neither Y or N
                while(choice != "Y" && choice != "N")
                {
                    Console.WriteLine("Invalid choice. Try Again");
                    //Asks the user if they want to play again
                    Console.Write("Would you like to play again? (Y/N): ");
                    choice = Console.ReadLine().ToUpper().Trim();
                }
            }

            Console.WriteLine("\n\nThanks!");
        }
    }
}
