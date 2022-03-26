using System;

namespace HW_Monopoly_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Constants
            const int MAX_ROLLS = 100;
            const int TOTAL_DICE = 2;
            const int MAX_PLAYERS = 100000;
            const int MAX_ROTATIONS = 25;
            //Variables
            Dice die = new Dice();
            Monopoly monopoly = new Monopoly(MAX_PLAYERS, MAX_ROTATIONS);
            double[] results = new double[40];
            double average = 0;
            int roll;

            //Rolls a single dice 100 times
            for (int i = 0; i < MAX_ROLLS; i++)
            {
                roll = die.RollDie();
                Console.Write( roll + " ");
                if (i == 36 || i == 73)
                {
                    Console.WriteLine();
                }
                average += roll;
            }
            average = average / MAX_ROLLS;
            Console.WriteLine("\nAverage roll for a single dice: {0:F}\n", average);

            //Reset dice roll average
            average = 0;

            //Rolls multiple dice 100 times;
            for (int i = 0; i < MAX_ROLLS; i++)
            {
                roll = die.RollDice(TOTAL_DICE);
                Console.Write(roll + " ");
                if (i == 36 || i == 73)
                {
                    Console.WriteLine();
                }
                average += roll;
            }
            average = average / MAX_ROLLS;
            Console.WriteLine("\nAverage roll for {0} dice: {1:F}", TOTAL_DICE, average);

            //Calculate how many times a space will be landed on
            results = monopoly.Analyze();

            //Print result
            monopoly.PrintResults(results);
        }
    }
}
