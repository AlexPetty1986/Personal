using System;
using System.Collections.Generic;

namespace PE_Graphs_APBG
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            Graph rooms = new Graph(new Dictionary<string, List<string>>());
            string currentRoom = "drawing room";
            string nextRoom;

            //while the current room isn't the exit
            while (currentRoom != "exit")
            {
                List<string> nearBy = rooms.GetAdjacentList(currentRoom);
                Console.WriteLine("You are currently in the {0}", currentRoom.ToUpper());
                Console.Write("Nearby are: ");

                //for each room that is nearby
                foreach (string i in nearBy)
                {
                    Console.Write(" {0} ", i);
                }

                //prompt for input
                Console.Write("\nWhere would you like to go? ");
                nextRoom = Console.ReadLine();
                Console.WriteLine();

                //if that room is connected to the current room
                if (rooms.IsConnected(currentRoom, nextRoom))
                {
                    //set current room to the next room
                    currentRoom = nextRoom;
                }

                //room doesn't exist
                else
                {
                    Console.WriteLine("Sorry, that is not an adjacent room.");
                }
            }

            Console.WriteLine("You have successfully escaped.");
        }
    }
}
