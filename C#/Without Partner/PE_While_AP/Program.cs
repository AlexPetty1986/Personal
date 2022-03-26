using System;

namespace PE_While_AP
{
    class Program
    {
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

            // Switch back to white and then return the response.
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        //Checks to see if the user inputted response is in range and then returns it
        public static int GetValidIntegerInput(string prompt, int min, int max)
        {
            //Stores the users response into an int variable
            int response = int.Parse(GetPromptedInput(prompt));

            //While the user inputted number is greater than max or less than min
            while(response < min || response > max)
            {
                response = int.Parse(GetPromptedInput(String.Format("Enter a value within {0} & {1}: ", min, max)));
            }

            //Returns the user response if requirements are met
            return response;

        }
        static void Main(string[] args)
        {
            // Use a do-while so that the menu is 
            // always shown at least once
            bool gameActive = true;
            do
            {
                // Prompt for and get their choice
                Console.WriteLine("\n\nWhat do you want to do?\n" +
                    "\tDo some MATH\n" +
                    "\tQUIT\n");
                string choice = GetPromptedInput(">").ToUpper();

                // Do something based on the user choice
                switch (choice)
                {
                    case "MATH":
                        Console.WriteLine("Enter positive numbers < 100 until the total is above 100:");
                        int total = 0;
                        while (total < 100)
                        {
                            total += GetValidIntegerInput(String.Format("Total: {0} > ", total), 0, 100);
                        }
                        Console.Write("Final Total: {0}", total);
                        break;

                    case "QUIT":
                        // end the game by changing the LCV to false
                        gameActive = false;
                        break;

                    default:
                        Console.WriteLine("That wasn't an option...");
                        break;
                }
            }
            while (gameActive);


        }
    }
}
