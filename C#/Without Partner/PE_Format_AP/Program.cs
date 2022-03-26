
/*
 * String Formatting
 * Alex Petty
 * 09/15/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace PE_Format_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //constant
            const string StatsUpdateTemplate = "{0}, you now have {1} health and {2:C} remaining.";

            //variables for program
            //Strings
            string name;
            string title;
            string nameWithTitle;
            string item;
            string action;

            //Float variables
            int health = 100;
            double wallet;
            int actionHealthReq;
            double itemCost;

            //Start the program
            //Character Creation
            Console.Write("What is your name brave adventurer? ");
            Console.ForegroundColor = ConsoleColor.Green;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("What is your title? ");
            Console.ForegroundColor = ConsoleColor.Green;
            title = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("How much money are you carrying? $");
            Console.ForegroundColor = ConsoleColor.Green;
            wallet = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            //Combines name and title
            nameWithTitle = String.Format("{0} the {1}", name, title);
            Console.WriteLine("Welcome {0}!\n", nameWithTitle);

            //Character Action
            Console.Write("What do you want to do next? ");
            Console.ForegroundColor = ConsoleColor.Green;
            action = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("How much health does it take to do this? ");
            Console.ForegroundColor = ConsoleColor.Green;
            actionHealthReq = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            //Decreases amount of health after action
            health -= actionHealthReq;
            Console.WriteLine("\nOkay, lets see you {0}!", action);
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);

            //Purchase Item
            Console.Write("\nWhat do you want to buy? ");
            Console.ForegroundColor = ConsoleColor.Green;
            item = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("How much does it normally cost? ");
            Console.ForegroundColor = ConsoleColor.Green;
            itemCost = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            //Calculates total price with tax
            itemCost *= 1.1;
            Console.WriteLine("\nYou bought {0} for {1}!", item, itemCost);
            //Decreases amont of money in wallet after purchase
            wallet -= itemCost;
            Console.WriteLine(StatsUpdateTemplate, nameWithTitle, health, wallet);
        }
    }
}
