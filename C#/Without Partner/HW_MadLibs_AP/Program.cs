/*
 * Mad Libs
 * Alex Petty
 * 09/15/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace HW_MadLibs_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {

            //Part 1 (Welcome the Player)
            //initialize variables
            //orbital speed constant(gotta go fest)
            const int AvgOrbitalSpeedMPH = 66616;
            //first and last name
            string first;
            string last;
            //age
            double age;

            //Prompt user for personal info
            Console.Write("Enter your first name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            first = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your last name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            last = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Enter your age(decimals permitted): ");
            Console.ForegroundColor = ConsoleColor.Red;
            age = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Print out a message to the user
            Console.WriteLine("\nWelcome " + first + " " + last + "! " + "I think I'll call you " + 
                first.ToUpper()[0] + first.ToLower().Substring(1,2) + last.ToLower().Substring(0,3) + ".");

            //Cool Bug Fact's
            Console.WriteLine("First, some really cool stuff about you:" +
                "\n\t- Your first name is " + (first.Length - last.Length) + 
                " letter(s) longer than your last name." + "\n\t- In your " + 
                age + " trips around the sun, you've traveled " + 
                (age * 365.25 * 24 * AvgOrbitalSpeedMPH) + " miles.");
            //End Part 1

            //Part 2 (Play Mad Libs)
            //Let's intitialize more variables
            //This is the mad libs we are working with
            const string MAD_LIBS = "\nOn a cold winter day, {0} was going to their favorite " +
                "restaurant with their friend, {1}.  \n{0} and {1} were craving some {2}, so they " +
                "decided to go out since {1}'s siblings were being loud while \n\"watching\" {3}.  " +
                "After driving for {4} minutes, they make it to the restaurant.\n\n{1} drops {0} off in " +
                "front of the restaurant to get a table.  After a few minutes {1} walks in, \nbriefly " +
                "mentioning they walked past a man who looked very {5} before walking in.  About {6} minutes " +
                "pass \nand we get our {2}, costing us a total of {7:C}.  While eating, {1} looks down and " +
                "notices a \ngiant rat scurry across the ground!  They scream at the top of their lungs, breaking " +
                "every glass in the \nrestaurant due to their scream reaching {8} decibals.  After a few minutes the " +
                "rat ran out the back door.\n\nThe staff at the restaurant apologize to them, giving them a {9:P} discount " +
                "for the troubles!  They get in the car, \nand drive back to {1}'s house, not surprised that their " +
                "sibling's fell asleep with {3} still playing. \n\nOnce they sat down, {0} and {1} realized that " +
                "today was quite eventful, before dozing off on the couch.";

            //Strings
            string name;
            string food;
            string movie;
            string mood;
            string friend;
            //numbers
            int number;
            int numberAgain;
            double percent;

            //Start the prompts!!!
            Console.WriteLine("\nHey...you like Mad Libs?...No?...TOO BAD!!");
            //Give me some words and maybe a phrase for one of them
            Console.Write("\tEnter a name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            name = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEnter a food: ");
            Console.ForegroundColor = ConsoleColor.Red;
            food = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEnter a movie title: ");
            Console.ForegroundColor = ConsoleColor.Red;
            movie = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEnter a mood: ");
            Console.ForegroundColor = ConsoleColor.Red;
            mood = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEnter another name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            friend = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            //Give me some numbers
            Console.Write("\tEnter a number between 1-20: ");
            Console.ForegroundColor = ConsoleColor.Red;
            number = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEnter another number between 1-10: ");
            Console.ForegroundColor = ConsoleColor.Red;
            numberAgain = int.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\tEnter a percentage between 0.0-1.0: ");
            Console.ForegroundColor = ConsoleColor.Red;
            percent = double.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            //Calculations for the mad libs
            double totalCost = (number * percent) + number;
            int breakGlass = numberAgain + 100;

            //Storytime!!!
            Console.WriteLine(MAD_LIBS, name.ToUpper(), friend.ToUpper(), food.ToUpper(), 
                movie.ToUpper(), number, mood.ToUpper(), numberAgain, totalCost, breakGlass, percent);
            //End Part II

        }

    }
}
