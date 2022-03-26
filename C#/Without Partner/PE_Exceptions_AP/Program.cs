using System;

namespace PE_Exceptions_AP
{
    class Program
    {
        //Stuff for Part 2
        // Input helper written by Prof. Mesh
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Red;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return the response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        //Checks to see if the user inputted response is in range and then returns it
        public static int GetValidIntegerInput(string prompt, int min, int max)
        {
            int response;
            //Stores the users response into an int variable
            //Changed to use TryParse
            bool success = int.TryParse(GetPromptedInput(prompt), out response);

            //While the user inputted number is greater than max or less than min
            while (response < min || response > max || !success)
            {
                //Changed to use TryParse
                success = int.TryParse(GetPromptedInput(String.Format("Enter a value within {0} & {1}: ", min, max)), out response);
            }

            //Returns the user response if requirements are met
            return response;

        }
        //Stuff for Part 2

        static void Main(string[] args)
        {
            //Part 1
            //Variables
            string input = null;

            //While the user input is NOT quit
            while(input != "quit")
            {
                Console.Write("Enter something: ");
                Console.ForegroundColor = ConsoleColor.Red;
                input = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                //If the user decides to quit
                if (input == "quit")
                {
                    Console.WriteLine("Goodbye");
                    break;
                }

                //Checks to see if the variable can be parsed to int
                try
                {
                    int.Parse(input);
                    Console.WriteLine("{0} is an int", input);
                }

                //If the variable cannot be parsed to int
                catch (FormatException)
                {
                    Console.WriteLine("{0} is NOT an int", input);
                }

                //Checks to see if the variable can be parsed to double
                try
                {
                    double.Parse(input);
                    Console.WriteLine("{0} is a double", input);
                }

                //If the variable cannot be parsed to double
                catch (FormatException)
                {
                    Console.WriteLine("{0} is NOT a double", input);
                }

                //Checks to see if the variable can be parsed to bool
                try
                {
                    bool.Parse(input);
                    Console.WriteLine("{0} is a bool", input);
                }

                //If the variable cannot be parsed to bool
                catch (FormatException)
                {
                    Console.WriteLine("{0} is NOT a bool", input);
                }

                //Checks to see if the variable can be parsed to char
                try
                {
                    char.Parse(input);
                    Console.WriteLine("{0} is a character\n", input);
                }

                //If the variable cannot be parsed to char
                catch (FormatException)
                {
                    Console.WriteLine("{0} is NOT a character\n", input);
                }

            }
            //End Part 1
            //Start Part 2
            // Get three numbers in different ranges:
            int a = GetValidIntegerInput("\nA [0,10] : ", 0, 10);
            int b = GetValidIntegerInput("\nB [20,30]:", 20, 30);
            int c = GetValidIntegerInput("\nC [40,50]:", 40, 50);

            // Print the sum
            Console.WriteLine("\nA + B + C = {0}", a + b + c);
            //End Part II
        }
    }
}
