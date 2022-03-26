/*
 * Guessing Game
 * Alex Petty
 * 10/24/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace PE_Guessing_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //constants
            const int MaxTurns = 9;
            //variables
            Random num = new Random();
            //Will print out a number between 0 & 100
            int numAnswer = num.Next(100);
            int turns = 1;
            int result;
            bool success;

            //start program
            Console.WriteLine(numAnswer);
            Console.WriteLine("\nWelcome to Number Guess!!\n");
            while(turns < MaxTurns)
            {
                //Prompts user for a variable that is within range
                Console.Write("Turn #{0}: Guess a number between 0 & 100 (inclusive): ", turns);
                success = int.TryParse(Console.ReadLine().Trim(), out result);

                //If user choice is not in range or input an incorrect variable
                while(result < 0 || result > 100 || !success)
                {
                    Console.WriteLine("Invalid Guess - Try Again\n");

                    //Prompts user for a variable that is within range
                    Console.Write("Turn #{0}: Guess a number between 0 & 100 (inclusive): ", turns);
                    success = int.TryParse(Console.ReadLine().Trim(), out result);
                }

                //If they guess correctly
                if(result == numAnswer)
                {
                    Console.WriteLine("\nCorrect! You won in {0} turns.", turns);
                    break;
                }

                //If they guess incorrectly
                else
                {
                    //If the user choice is less than the random number
                    if(result < numAnswer)
                        Console.WriteLine("Too Low\n");
                    //If the user choice is greater than the random number
                    else if (result > numAnswer)
                        Console.WriteLine("Too High\n");
                    //Increases the amount of turns
                    turns++;
                    //If they run out of turns
                    if (turns == MaxTurns)
                    {
                        Console.WriteLine("\nYou ran out of turns. The number was {0}.", numAnswer);
                    }
                }
            }
        }
    }
}
