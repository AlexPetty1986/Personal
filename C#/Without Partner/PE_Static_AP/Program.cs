using System;

namespace PE_Static_AP
{
    class Program
    {
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // LEAVE THESE HELPER METHODS ALONE!
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Helper written by Prof. Mesh
        // Check if one number is a factor of another
        public static bool IsFactorOf(int factor, int number)
        {
            // Return true if "factor" is smaller than "number"
            // and is evenly divisible into "number"
            return factor < number && number % factor == 0;
        }

        // Input helper written by Prof. Mesh
        public static string GetPromptedInput(string prompt)
        {
            // Always print in white
            Console.ForegroundColor = ConsoleColor.White;

            // Print the prompt
            Console.Write(prompt + " ");

            // Switch color and get user input (trim too)
            Console.ForegroundColor = ConsoleColor.Cyan;
            string response = Console.ReadLine().Trim();

            // Switch back to white and then return response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        //Checks to see if the inputted number are factorable
        public static void CheckNumbers(int a, int b)
        {
                //If the numbers are factors of each other
                if (IsFactorOf(a, b) || IsFactorOf(b, a))
                {
                    Console.WriteLine("{0} & {1} are awesome numbers.", a, b);
                }

                //If they are not factors of each other
                else
                {
                    Console.WriteLine("{0} & {1} are okay I guess.", a, b);
                }

        }

        //Gives the user a secret code using their name and inputted numbers
        public static int GetSecretCode(string name, int a, int b)
        {
            //Super secret code maker equation
            return ((a*b) + b - name.Length + name[0] * (name.Length * b * a + name[0]));
        }

        //Prints out all the info of the user, including name, favorite numbers and secret code
        public static void PrintAllInfo(string name, int a, int b)
        {
            //Prints out all information for the user
            Console.WriteLine("Your name is {0},\n\tyour favorite number are {1} and {2}," +
                "\n\tand your secret code is {3}.", name.ToUpper(), a, b, GetSecretCode(name,a, b));
        }
        
        static void Main(string[] args)
        {
            // Setup variables
            string name = "";
            int a = 0;
            int b = 0;
            int choice = 0;

            // Get values for name, a, and b using GetPromptedInput and parsing if needed.
            // Fyi, lines that begin with // TODO: will appear in a VS task list for you!
            // https://docs.microsoft.com/en-us/visualstudio/ide/using-the-task-list
            
            name = GetPromptedInput("What is your name? ");
            a = int.Parse(GetPromptedInput("Enter a whole number: "));
            b = int.Parse(GetPromptedInput("Enter another whole number: "));

            // Reformat the name
            name = name[0].ToString().ToUpper() + name.Substring(1, name.Length - 1).ToLower();

            // Print the menu
            Console.WriteLine("\nHello {0}, what would you like to do?\n" +
                "\t1 - Compare numbers\n" +
                "\t2 - Get my secret code\n" +
                "\t3 - Output all info",
                name);
            choice = int.Parse(GetPromptedInput(">"));
            Console.WriteLine();

            // Figure out what to do and do it
            switch (choice)
            {
                // Check numbers
                case 1:
                    CheckNumbers(a, b);
                    break;

                // Get secret code
                case 2:
                    Console.WriteLine(GetSecretCode(name, a, b));
                    break;

                // Output all info
                case 3:
                    PrintAllInfo(name, a, b);
                    CheckNumbers(a, b);
                    break;

                // Say goodbye for invalid choices
                default:
                    Console.WriteLine("That wasn't a valid choice. Goodbye.");
                    break;
            }
        }
    }
}
