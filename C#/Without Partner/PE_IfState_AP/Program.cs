/*
 * If Statements
 * Alex Petty
 * 09/15/2021
 */

//Tell the compiler where get other functionality from
using System;

namespace PE_IfState_AP
{
    //Group common definitions together in a class
    class Program
    {
        //Main() method: Defines a chunk of logic to execute at the beginning
        static void Main(string[] args)
        {
            //variable
            string choice = null;

            //Fun is Infinite with Sega Enterprises (except when you quit)
            while (choice != "exit")
            {
                Console.Write("What does the NPC in your game sense? ");
                choice = Console.ReadLine().ToLower().Trim();

                //your actions may or may nor have consequences
                //NPC seems really hungry
                if (choice == "bread loaf")
                {
                    Console.WriteLine("The NPC hungrily stuffs a whole loaf of bread into their mouth.\n");
                }

                //NPC seems really tried
                else if (choice == "tree")
                {
                    Console.WriteLine("The NPC walks over to the tree and then proceeds to fall asleep.\n");
                }

                //NPC has wandered into a dungeon, with an angry bandit living inside it
                else if (choice == "2 doors" || choice == "two doors")
                {
                    //Good job
                    Console.Write("Which door does the enemy go through (left or right)? ");
                    string door = Console.ReadLine().ToLower().Trim();
                    if(door == "left")
                    {
                        Console.WriteLine("The bandit somehow fell into the trap the NPC had made!\n");
                    }

                    //Bad job
                    else if (door == "right")
                    {
                        Console.WriteLine("The bandit finds and attacks the NPC!");
                    }

                    //???
                    else if (door == "up")
                    {
                        Console.WriteLine("The bandit ran into a wall...I think they might need glasses.\n");
                    }

                    //Bandit is too tired to do anything
                    else if (door == "down")
                    {
                        Console.WriteLine("The bandit decide he was too tired and proceeded to go home.\n");
                    }

                    //NPC has no idea what on Earth you just typed
                    else
                    {
                        Console.WriteLine("The NPC is completely baffled about what to." +
                            "\nThe bandit waiting for one fo the correct answers\n");
                    }

                }

                //When you are done playing
                else if(choice == "exit")
                {
                    Console.WriteLine("The NPC went home and went to bed, waiting for next time.");
                }

                //NPC has no idea what on Earth you just typed
                else
                {
                    Console.WriteLine("The NPC is completely baffled about what to do.\n");
                }
            }
        }
    }
}
