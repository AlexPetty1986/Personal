using System;
using System.IO;

namespace HW1_GameOfLife_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string choice = null;
            string option = null;
            string filename = "startingBoard.txt";
            Game function = new Game();
            StreamReader input = null;
            StreamWriter output = null;

            Console.Write("Welcome to the Game of Life!\n");

            //While user wants to continue
            while(choice != "4")
            {
                option = null;
                Console.Write("\nOptions: " +
                "\n1 - Generate a random board\n2 - Display Board" +
                "\n3 - Load initial board from file\n4 - Quit" +
                "\n\nYour Choice: ");
                choice = Console.ReadLine();

                switch (choice)
                {
                    //generate random board
                    case "1":
                        function.GenerateBoard();
                        break;

                    //display generated board
                    case "2":
                        function.DisplayBoard();
                        break;

                    //load board from text file
                    case "3":
                        Console.Write("Filename? ");
                        filename = Console.ReadLine();
                        //Attempt to load file
                        try
                        {
                            input = new StreamReader(filename);
                            function.loadFile(input);
                        }

                        //If it fails
                        catch (Exception e)
                        {
                            Console.WriteLine("ERROR! " + e.Message);
                            break;
                        }

                        //End of file
                        if (input != null)
                        {
                            input.Close();
                        }

                        Console.Write("\n");

                        //While the user wants to do anything to the board
                        while(option != "3")
                        {
                            Console.Write("1-Advance, 2-Save Current Board, or " +
                                "3-Main Menu? ");
                            option = Console.ReadLine();
                            switch (option)
                            {
                                //advance board
                                case "1":
                                    function.Advance();
                                    function.DisplayBoard();
                                    Console.WriteLine();
                                    break;

                                //save current board
                                case "2":
                                    Console.Write("Filename? ");
                                    filename = Console.ReadLine();
                                    //try to create file
                                    try
                                    {
                                        output = new StreamWriter(filename);
                                        function.saveFile(output);
                                        //print
                                        Console.WriteLine("Board save into {0}.\n", filename);
                                    }

                                    //unable to create file
                                    catch(Exception e)
                                    {
                                        Console.WriteLine("ERROR! " + e.Message);
                                    }

                                    if(output != null)
                                    {
                                        output.Close();
                                    }
                                    break;

                                //return to main menu
                                case "3":
                                    break;

                                //invalid input
                                default:
                                    Console.WriteLine("Invalid Input!\n");
                                    break;
                            }
                        }
                        break;

                    //end game
                    case "4":
                        Console.WriteLine("Goodbye!");
                        break;

                    //invalid choice
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
