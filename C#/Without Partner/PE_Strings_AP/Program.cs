/*
 * Inputs & Strings
 * Alex Petty
 * 09/10/2021
 */

//Tell the compiler where get other functionality from
using System;

//Idenitifier for everything we'll define in this projectusing System;
namespace PE_Strings_AP
{
    //Group common definitions together in a class
    class Program
    {
        static void Main(string[] args)
        {
            //Variables used in the program
            string name;
            string pet;
            string food;
            string game;

            //Prompts the user for their first name
            Console.Write("What is your name? ");
            Console.ForegroundColor = ConsoleColor.Red;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Welcome " + name + "!");

            //Prompt the user for the name of their pet
            Console.Write("What is your pet's name? ");
            Console.ForegroundColor = ConsoleColor.Red;
            pet = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            //Prompt the user for their favorite food
            Console.Write("What is your favorite food? ");
            Console.ForegroundColor = ConsoleColor.Red;
            food = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            //Prompt the user for their favorite video game
            Console.Write("What is your video game? ");
            Console.ForegroundColor = ConsoleColor.Red;
            game = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            //Prints out the length of the name as well as the difference in letters between the user and their pet
            Console.WriteLine("\nYour name is " + name.Length + " letters long\nand " + 
                (name.Length - pet.Length) + " letters longer than " + pet + "'s name.\n");

            //Prints out a thought using the info provided
            Console.WriteLine("I wonder if " + pet.ToUpper() + 
                " also likes " + food.ToUpper() + " and " + game.ToUpper() + " as much as you do.\n");

            //Prints out a nickname using the first two letters of all things provided
            Console.WriteLine("Maybe I should just call you " + name.ToUpper()[0] + 
                pet.Substring(0, 2).ToLower() + food.Substring(0, 2).ToLower() + game.Substring(0, 2).ToLower() + "?");
        }
    }
}
