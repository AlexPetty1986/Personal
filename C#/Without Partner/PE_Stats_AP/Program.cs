/*
 * Stats
 * Alex Petty
 * 09/08/2021
 */

//Tell the compiler where get other functionality from
using System;

//Idenitifier for everything we'll define in this project
namespace PE_Stats_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //Total number of stat points you are given in the beginning
            const int starting = 50;

            //The individual stats of the character
            //dexterity
            double dexterity = starting * .2;
            //vitality
            double vitality = dexterity * .5;
            //endurance
            double endurance = 7;
            //attunement
            double attunement = (vitality + endurance) - 2;
            //resistance
            double resistance = starting - (dexterity + vitality + endurance + attunement);
            //total points from all stats
            double total = dexterity + vitality + endurance + attunement + resistance;

            //Use WriteLine method from the Console give the name of the character
            Console.WriteLine("Slave Knight Gael\n");

            //Use WriteLine method from the Console to give the first stat
            Console.WriteLine(dexterity + " Dexterity");

            //Use WriteLine method from the Console to give the second stat
            Console.WriteLine(vitality + " Vitality");

            //Use WriteLine method from the Console to give the third stat
            Console.WriteLine(endurance + " Endurance");

            //Use WriteLine method from the Console to give the fourth stat
            Console.WriteLine(attunement + " Attunement");

            //Use WriteLine method from the Console to give the final stat
            Console.WriteLine(resistance + " Resistance\n");

            //Use WriteLine method from the Console to give the total stats
            Console.WriteLine("Total: " + total);

        }
    }
}
