/*
 * Parsing
 * Alex Petty
 * 09/15/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace PE_Parse_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {

            //Variables that provide info about the player
            //The name of the character
            string character;
            //Total hours played
            int playtime;
            //Point One
            int x1;
            int y1;
            //Point Two
            int x2;
            int y2;
            //A & B
            float a;
            float b;
            //Degrees
            float deg;
            float rad;

            //The stuff that gets printed to the screen
            //Addition
            Console.WriteLine("--- ADDITION ---");
            Console.Write("What is the first number? ");
            a = float.Parse(Console.ReadLine());
            Console.Write("What is the second number? ");
            b = float.Parse(Console.ReadLine());
            Console.WriteLine("Number A: " + a + "\nNumber B: " + 
                b + "\n" + a + " + " + b + " = " + (a + b) +
                "\nNow I'll add just the whole number parts.\n" +
                (int)a + " + " + (int)b + " = " + ((int)(a) + (int)(b)) + "\n");

            //Division with remainder
            Console.WriteLine("--- DIVISION and MODULUS ---");
            Console.Write("What is that player's name? ");
            character = Console.ReadLine();
            Console.Write("How many hours have they logged? ");
            playtime = int.Parse(Console.ReadLine());
            Console.WriteLine(character + " has played a game for " + playtime + 
                " hours.\n" + "They have played for " + (playtime / 24) + " days and " +
                (playtime % 24) + " hours.\n");

            //Sine and cosine
            Console.WriteLine("--- SINE and COSINE ---");
            Console.Write("Enter an angle in degrees: ");
            deg = float.Parse(Console.ReadLine());
            //You like radians?
            rad = (float)(deg * Math.PI / 180);
            Console.WriteLine(deg + " degrees is " + rad + 
                " radians.\n" + "The sine is " + Math.Sin(rad) +
                "\nThe cosine is " + Math.Cos(rad) + "\n");

            //Total distance
            Console.WriteLine("--- DISTANCE ---");
            Console.Write("Enter Point 1 X: ");
            x1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Point 1 Y: ");
            y1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Point 2 X: ");
            x2 = int.Parse(Console.ReadLine());
            Console.Write("Enter Point 2 Y: ");
            y2 = int.Parse(Console.ReadLine());
            //Calculation of square root
            float sqr = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("Point One: (" + x1 + "," + y1 + ")" +
                "\nPoint Two: (" + x2 + "," + y2 + ")" +
                "\nThe distance between these points is " + sqr + ".");
            //Rounds some stuff(maybe the square root)
            Console.WriteLine("The distance is " + sqr +
                ", which is approximately " + Math.Round(sqr) +
                " units, or " + Math.Round(sqr, 3) + " to be more precise.");
        }
    }
    }