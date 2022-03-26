
/*
 * Golf
 * Alex Petty
 * 10/13/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace HW3_Golf_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //Constant Variables
            const double length = 2.0;
            const int maxTries = 11;
            const double target = 751;
            const double min = 750.5;
            const double max = 751.5;
            //Variables
            double velocity;
            double angle;
            double rad;
            double timeFlight;
            double distance;
            double distanceApart;
            int attempts = 1;
            
            //Welcome to game 1
            Console.WriteLine("Welcome to Artillery Golf!\n" +
                "Your goal is to hit a target 751 meters away.\n");
            //While the amount of attempts is less than 11 (10 attempts max)
            while(attempts < maxTries)
            {
                //Prompts user for angle of cannon
                Console.WriteLine("Attempt {0} -------------------------------------------", attempts);
                Console.Write("Enter the cannon's angle (between 0 and 90 degrees): ");
                angle = double.Parse(Console.ReadLine());
                //If not in the set range
                while(angle < 0 || angle > 90)
                {
                    Console.WriteLine("That is an invalid angle.");
                    Console.Write("Enter the cannon's angle (between 0 and 90 degrees): ");
                    angle = double.Parse(Console.ReadLine());

                }

                //Prompts user for intial velocity of cannonball
                Console.Write("\nEnter the cannonballs's initial velocity (a positive number): ");
                velocity = double.Parse(Console.ReadLine());
                //If not in the set range
                while (velocity < 0 )
                {
                    Console.WriteLine("That is an invalid velocity.");
                    Console.Write("\nEnter the cannonballs's initial velocity (a positive number): ");
                    velocity = double.Parse(Console.ReadLine());
                }

                //Converts the angle degree into a radian
                rad = (angle * Math.PI) / 180;
                //Calculates time of flight
                timeFlight = (velocity * Math.Sin(rad) + Math.Pow((Math.Pow(velocity,2) * Math.Pow(Math.Sin(rad),2) + 
                    20.0 * length * Math.Sin(rad)),.5)) / 10;
                //Calculates distance the cannonball traveled
                distance = velocity * Math.Cos(rad) * timeFlight;
                //Calculate how far the cannonball is from the target
                if(distance >= target)
                {
                    distanceApart = distance - target;
                }
                else
                {
                    distanceApart = target - distance;
                }
                Console.Write("\nThank You." +
                    "\nA cannonball was fired with an intitial velocity of {0:F} m/s, at an angle" +
                    "\nof {1:F} degrees from the ground, will strike the ground \n{2} meters away." +
                    "\nYou're {3} meters from the target.", velocity, angle, distance, distanceApart);
                if(distance >= min && distance <= max)
                {
                    Console.Write("  A successful hit!!\n\nThanks for playing.");
                    break;
                }

                else
                {
                    Console.Write("  Try again!!\n\n");
                    attempts++;
                }

                if(attempts >= maxTries)
                {
                    Console.Write("Ran out of attempts but thanks for playing!");
                }

            }
        }
    }
}
