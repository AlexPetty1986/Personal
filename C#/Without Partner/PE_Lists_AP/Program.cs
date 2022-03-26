using System;
using System.Collections.Generic;

namespace PE_Lists_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            Random rng = new Random();
            string stolen = "stolen";
            string player1;
            string player2;
            string item;
            string choice = null;
            int option;
            int itemsStolen = 0;
            string stolenItem;

            //Start program
            //Prompt user for player names
            Console.Write("Enter Player 1's Name: ");
            player1 = Console.ReadLine();
            Console.Write("Enter Player 2's Name: ");
            player2 = Console.ReadLine();
            Console.WriteLine();

            //Create the lists
            Player playList1 = new Player(player1);
            Player playList2 = new Player(player2);
            Player stolenList = new Player(stolen);

            //Get some items
            for(int i = 0; i < 5; i++)
            {
                //Prompt user for items
                Console.Write("Enter an item: ");
                item = Console.ReadLine().ToLower().Trim();

                //If random is less
                if (rng.NextDouble() > 0.5)
                {
                    playList1.AddToInventory(item);
                }
                else
                {
                    playList2.AddToInventory(item);
                }
            }

            //Print out the lists
            Console.WriteLine("");
            playList1.PrintInventory();
            Console.WriteLine("");
            playList2.PrintInventory();
            Console.WriteLine("");

            while(choice != "quit")
            {
                Console.Write("Enter a command (print, steal, or quit) or an item: ");
                choice = Console.ReadLine().ToLower().Trim();
                switch (choice)
                {
                    //Will print out the list of the both players
                    case "print":
                        Console.WriteLine("");
                        playList1.PrintInventory();
                        Console.WriteLine("");
                        playList2.PrintInventory();
                        Console.WriteLine("");
                        break;

                    case "steal":

                        Console.Write("Which user do you want to steal from? (1 or 2): ");
                        bool success = int.TryParse(Console.ReadLine(), out option);

                        //If user input is 1
                        if (option == 1)
                        {
                            Console.Write("What do you want to steal? ");
                            success = int.TryParse(Console.ReadLine(), out option);
                            stolenItem = playList1.GetItemInSlot(option);
                            playList2.AddToInventory(stolenItem);
                            stolenList.AddToInventory(stolenItem);
                            Console.WriteLine("");
                            if(stolenItem != null)
                            {
                                itemsStolen++;
                            }
                        }

                        //If user input is 2
                        else if (option == 2)
                        {
                            Console.Write("What do you want to steal? ");
                            success = int.TryParse(Console.ReadLine(), out option);
                            stolenItem = playList2.GetItemInSlot(option);
                            playList1.AddToInventory(stolenItem);
                            stolenList.AddToInventory(stolenItem);
                            Console.WriteLine("");
                            if (stolenItem != null)
                            {
                                itemsStolen++;
                            }
                        }

                        //If user input is not a valid number
                        else
                        {
                            Console.WriteLine("{0} is not a valid user number!", option);
                            Console.WriteLine("");
                        }
                        break;

                    //Quits the loop and then reveals how many items were stolen as well as what they were
                    case "quit":
                        Console.WriteLine("\nYou stole {0} item(s):", itemsStolen);
                        stolenList.PrintInventory();
                        break;

                    //Adds and item to one of the lists
                    default:
                        //If random is less
                        if (rng.NextDouble() > 0.5)
                        {
                            playList1.AddToInventory(choice);
                        }
                        else
                        {
                            playList2.AddToInventory(choice);
                        }
                        Console.WriteLine("");
                        break;
                }

            }

        }
    }
}
