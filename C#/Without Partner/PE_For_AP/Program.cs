using System;

namespace PE_For_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start Part 1
            //variables
            int number = 0;
            //While loop
            while(number != 6)
            {
                Console.WriteLine(number);
                number++;
            }

            Console.Write("\n");
            number = 100;
            //Do while
            do
            {
                Console.WriteLine(number);
                number--;
            }
            while (number != 94);

            Console.Write("\n");
            //For loop
            for(number = 0; number != 30; number += 5)
            {
                Console.WriteLine(number);
            }
            Console.Write("\n");
            //End Part 1

            //Start Part 2
            //variables
            int width;
            int height;
            //Prompt user for width
            Console.Write("Enter a width: ");
            width = int.Parse(Console.ReadLine());
            //Prompt user for height
            Console.Write("Enter a height: ");
            height = int.Parse(Console.ReadLine());
            Console.Write("\n");

            //Start drawing the whole rectangle
            for (int i = 0; i != height; i ++)
            {
                for(int j = 0; j != width; j ++)
                {
                    Console.Write("o");
                }

                Console.Write("\n");
            }

            Console.Write("\n");

            //Draw only the border
            for (int i = 0; i != height; i++)
            {
                for (int j = 0; j != width; j++)
                {
                    if ((i > 0 && i < height - 1) && (j > 0 && j < width - 1))
                        Console.Write(" ");
                    else
                        Console.Write('o');

                }

                Console.Write("\n");
            }
        }
    }
}
