using System;

namespace PE_IOClasses_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string choice = null;
            string name;
            int strength;
            int health;
            PlayerManager manager = new PlayerManager();

            //start program
            while(choice != "quit")
            {
                Console.Write("Create. Print. Save. Load. Quit. >> ");
                choice = Console.ReadLine().ToLower().Trim();

                switch(choice)
                {
                    case "create":
                        Console.Write("What is the player's name? ");
                        name = Console.ReadLine().Trim();
                        Console.Write("Player's strength? ");
                        strength = int.Parse(Console.ReadLine().Trim());
                        Console.Write("Player's health? ");
                        health = int.Parse(Console.ReadLine().Trim());
                        manager.CreatePlayer(name, strength, health);
                        Console.WriteLine();
                        break;

                    case "print":
                        manager.Print();
                        Console.WriteLine();
                        break;

                    case "save":
                        manager.Save();
                        Console.WriteLine();
                        break;

                    case "load":
                        manager.Load();
                        Console.WriteLine();
                        break;

                    case "quit":
                        Console.WriteLine("Goodbye!!\n");
                        break;

                    default:
                        Console.WriteLine("Not a choice!!\n");
                        break;
                }
            }
        }
    }
}
