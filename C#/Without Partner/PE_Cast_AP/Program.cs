/*
 * Casting
 * Alex Petty
 * 09/10/2021
 */

//Tell the compiler where get other functionality from
using System;

//Idenitifier for everything we'll define in this project
namespace PE_Cast_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //PI constant
            const double PI = 3.1415926535897931;

            //Variables that prvoide info about the player
            //The name of the character
            string character = "Terry Bogard";
            //Total hours played
            int playtime = 274;
            //Point One
            int x1 = -13;
            int y1 = 51;
            //Point Two
            int x2 = 17;
            int y2 = 28;
            //A & B
            float a = 7.9f;
            float b = 2.25f;
            //Degrees
            float deg = 60f;
            float rad = (float)(deg * PI / 180);

            //The stuff that gets printed to the screen
            //Addition
            Console.WriteLine("--- ADDITION ---\n" +
                "Number A: " + a + "\nNumber B: " + b + "\n" +
                a + " + " + b + " = " + (a + b) + 
                "\nNow I'll add just the whole number parts.\n" +
                (int)a + " + " + (int)b + " = " + ((int)(a) + (int)(b)) + "\n");

            //Division with remainder
            Console.WriteLine("--- DIVISION and MODULUS ---\n" +
                character + " has played a game for " + playtime + " hours.\n" +
                "They have played for " + (playtime / 24) + " days and " +
                (playtime % 24) + " hours.\n");

            //Sine and cosine
            Console.WriteLine("--- SINE and COSINE ---\n" + deg +
                " degrees is " + rad + " radians.\n" +
                "The sine is " + Math.Sin(rad) +
                "\nThe cosine is " + Math.Cos(rad) + "\n");

            //Total distance
            //Calculation of square root
            float sqr = (float)Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            Console.WriteLine("--- DISTANCE ---\n" +
                "Point One: (" + x1 + "," + y1 + ")" +
                "\nPoint Two: (" + x2 + "," + y2 + ")" +
                "\nThe distance between these points is " + sqr + ".\n");

            //Rounding
            Console.WriteLine("--- ROUNDING ---\n" + 
                "The distance is " + sqr + 
                ", which is approximately " + Math.Round(sqr) + 
                " units, or " + Math.Round(sqr, 3) + " to be more precise.");
        }
    }
}
