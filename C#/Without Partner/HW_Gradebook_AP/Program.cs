/*
 * Gradebook
 * Alex Petty
 * 10/22/2021
 */

////////////////////////////////////////////////////
// Part 1 - Collect the Data
////////////////////////////////////////////////////

// Declare the variables you'll need

// Prompt for and save the # of grades to manage

// Use the # of grades to create the arrays big enough
// to hold assignment names and grades

// Populate the arrays by repeatedly prompting for
// assignment name and corresponding grade

// Make sure the grade is a non-negative double.
// If not, error & prompt again
////////////////////////////////////////////////////
// Part 2 - Print and Average
////////////////////////////////////////////////////

// For each assignment/grade pair, display it with a 
// user-friendly index (index + 1)
// Calculate the sum of all grades as we display
// to avoid needing a second loop

// Use the sum to calculate the average

// Display the average
////////////////////////////////////////////////////
// Part 3 - Get a replacement grade
////////////////////////////////////////////////////

// Prompt for a valid assignment grade to update by index 
// (index + 1 really)

// If the index isn't valid, error & reprompt

// Prompt for a new grade and validate

// If not valid, error & reprompt
// Replace the grade
////////////////////////////////////////////////////
// Part 4 - Re-print and average
////////////////////////////////////////////////////

// Re-print and re-calc (basically a cut & paste of Part 2)

//Tell the compiler where get other functionality from
using System;

namespace HW_Gradebook_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //Variables
            double[] grades;
            string[] homework;
            int result;
            int gradeRep;
            double gradeResult;
            double average = 0;

            //Start the program
            //Start Part 1
            Console.Write("Welcome to the Gradebook." +
                "\n\nHow many assignments have you had?\n > ");

            //Checks to see if user response can be parsed
            bool success = int.TryParse(Console.ReadLine().Trim(), out result);

            //While the user choice is not in range
            while (result <= 0 || !success)
            {
                //Asks user to enter a correct response
                Console.Write("\nNot a valid whole number.\n" +
                    "Enter number of assignments.\n > ");

                //Checks to see if user response can be parsed
                success = int.TryParse(Console.ReadLine().Trim(), out result);
            }

            //Initialize the size of the arrays
            grades = new double[result];
            homework = new string[result];

            //Ask the user for the grades and names of the homework
            for(int i = 0; i < result; i++)
            {
                //Prompt user for assignment name
                Console.Write("\nEnter assignment name.\n > ");
                //Save homework name in array
                homework[i] = Console.ReadLine().Trim();
                //Prompt user for assignment grade
                Console.Write("\nEnter assignment grade.\n > ");

                //Checks to see if user response can be parsed
                success = double.TryParse(Console.ReadLine().Trim(), out gradeResult);

                //While the user choice is not in range
                while (gradeResult < 0 || gradeResult > 100|| !success)
                {
                    //Asks user to enter a correct response
                    Console.Write("\nNot a valid grade.\n" +
                        "Enter assignment grade.\n > ");

                    //Checks to see if user response can be parsed
                    success = double.TryParse(Console.ReadLine().Trim(), out gradeResult);
                }

                //Stores grade in array
                grades[i] = gradeResult;
            }
            //End Part1
            //Start Part 2
            //Print out grades and average
            Console.WriteLine("\nGrade Report:");

            //Prints out the information of the assignment and adds up all of the grades
            for(int j = 0; j < result; j++)
            {
                Console.WriteLine("  {0}: " + homework[j] + ": " + grades[j], j + 1);
                average += grades[j];
            }

            //Calculates the average
            average = average / result;

            Console.WriteLine("--------------------------------------------" +
                "\nFinal Average: {0}", average);
            //End Part 2
            //Start Part 3
            //ASk the user what grade they would like to replace
            Console.Write("\nWhat is the index of the grade to replace?\n > ");
            success = int.TryParse(Console.ReadLine().Trim(), out gradeRep);

            //While the user choice is not in range or inputs something other than an int
            while(gradeRep <= 0 || gradeRep > result || !success)
            {
                Console.Write("\nIndex must be a number between 1 & {0}.\n" +
                    "What is the index of the grade to replace?\n > ", result);
                success = int.TryParse(Console.ReadLine().Trim(), out gradeRep);
            }

            //Ask user what they want to change the grade to
            Console.Write("\nWhat is the new grade?\n > ");
            success = double.TryParse(Console.ReadLine().Trim(), out gradeResult);

            //While the user choice is not in range
            while (gradeResult < 0 || gradeResult > 100 || !success)
            {
                //Asks user to enter a correct response
                Console.Write("\nNot a valid grade.\n" +
                    "Enter assignment grade.\n > ");

                //Checks to see if user response can be parsed
                success = double.TryParse(Console.ReadLine().Trim(), out gradeResult);
            }

            //Stores the changed grade in the array
            grades[gradeRep - 1] = gradeResult;
            //End Part 3
            //Start Part 4
            //Reset average to 0
            average = 0;
            //Print out grades and average
            Console.WriteLine("\nGrade Report:");

            //Prints out the information of the assignment and adds up all of the grades
            for (int j = 0; j < result; j++)
            {
                Console.WriteLine("  {0}: " + homework[j] + ": " + grades[j], j + 1);
                average += grades[j];
            }

            //Calculates the average
            average = average / result;

            Console.WriteLine("--------------------------------------------" +
                "\nFinal Average: {0}", average);
            //End Part 4
        }
    }
}
