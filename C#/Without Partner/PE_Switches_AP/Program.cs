/*
 * If's & Switches
 * Alex Petty
 * 09/15/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace PE_Switches_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //variables for the program
            //Player score
            int score = 0;
            //Player answers
            int answer;
            double num1;
            double num2;
            double num3;
            char playerChoice;
            
            //Question 1
            Console.Write("What is (8 * 9) / 4? ");
            answer = int.Parse(Console.ReadLine());
            //Checks to see if the answer is correct
            if(answer != 18)
            {
                Console.WriteLine("Wrong!! :(");
            }
            else
            {
                Console.WriteLine("Nice Job!! :D");
                score++;
            }

            //Question 2
            Console.WriteLine("\n\nGive me three numbers that are " +
                "half of the one before it in descending order");
            Console.Write("1:  ");
            num1 = double.Parse(Console.ReadLine());
            Console.Write("2:  ");
            num2 = double.Parse(Console.ReadLine());
            Console.Write("3:  ");
            num3 = double.Parse(Console.ReadLine());

            //Checks to see if the answer is not only correct but also in the correct order
            if(num2 == (num1 / 2) && num3 == (num2 / 2))
            {
                Console.WriteLine("Correct!!");
                score++;
            }

            else if (num2 == (num1 * 2) && num3 == (num2 * 2))
            {
                Console.WriteLine("You fool! This is backwards!!");
            }

            else
            {
                Console.WriteLine("I don't even know what this is!!");
            }

            //Question 3
            Console.Write("\n\nWhat is the final mask you can obtain and use in Majora's Mask?"
                + "\n\ta. Deku Mask \n\tb. Majora's Mask \n\tc. Fierce Deity's Mask \n\td. Giant's Mask" +
                "\n\n> ");
            playerChoice = char.Parse(Console.ReadLine().ToLower().Trim());

            //Checks to see if the player put in the right answer
            switch(playerChoice)
            {

                case 'a':
                case 'd':
                case 'b':
                    Console.WriteLine("Incorrect!! The correct answer is the Fierce Deity's Mask.");
                    break;

                case 'c':
                    Console.WriteLine("Correct!!");
                    score++;
                    break;

                default:
                    Console.WriteLine("This wasn't even a choice!!");
                    break;
            }

            //Shows you how many questions you got correct
            Console.WriteLine("\n\nFINAL SCORE:" + score);
            if(score == 0)
            {
                Console.WriteLine("Now that is just sad.");
            }
            else if (score == 1)
            {
                Console.WriteLine("One point...are you serious?");
            }
            else if (score == 2)
            {
                Console.WriteLine("So close yet so far.");
            }
            else if (score == 3)
            {
                Console.WriteLine("Nice Job! Perfect Score.");
            }
            else
            {
                Console.WriteLine("I don't even know how you got this.");
            }
        }
    }
}
