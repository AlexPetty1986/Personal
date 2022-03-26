using System;

namespace PE_Properties_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //variables
            string title;
            string author;
            int pages;
            string owner;
            string choice = null;

            //Start program
            //Prompt user for info on the book
            //Title of the book
            Console.Write("Welcome to Book Simulator 2021\n\n" +
                "What is the book's title? ");
            title = Console.ReadLine().Trim();

            //Author of the book
            Console.Write("Who is the book's author? ");
            author = Console.ReadLine().Trim();

            //Total pages in the book
            Console.Write("How many pages does it have? ");
            bool success = int.TryParse(Console.ReadLine().Trim(), out pages);

            //While the amount of pages is less than or equal to 0 or success is false
            while(pages <= 0 || !success)
            {
                Console.Write("Invalid Input.\nHow many pages does it have? ");
                success = int.TryParse(Console.ReadLine().Trim(), out pages);
            }

            //Owner of the book
            Console.Write("Who is the book's current owner? ");
            owner = Console.ReadLine().Trim();

            //Saves the variables into the book class
            Book book = new Book(title, author, pages, owner);

            //While user is not done
            while (choice != "done")
            {
                //Ask user what they want to do
                Console.Write("\nWhat would you like to do? ");
                choice = Console.ReadLine().ToLower().Trim();
                switch(choice)
                {
                    //Prints out the title of the book
                    case "title":
                        Console.WriteLine("The title is {0}.", book.Title);
                        break;

                    //Prints out the author of the book
                    case "author":
                        Console.WriteLine("The author is {0}.", book.Author);
                        break;

                    //Prints out the total pages in the book
                    case "pages":
                        Console.WriteLine("The book has {0} pages.", book.Pages);
                        break;

                    //Asks the user if they would like to change the owner of the book
                    case "owner":
                        Console.Write("Would you like to change the owner (yes/no)? ");
                        choice = Console.ReadLine().ToLower().Trim();
                        switch(choice)
                        {
                            //If the user says yes
                            case "yes":
                                Console.Write("Who is the new owner? ");
                                book.Owner = Console.ReadLine();
                                Console.WriteLine("The new owner is {0}.", book.Owner);
                                break;

                            //If the user says no
                            case "no":
                                Console.WriteLine("Ok. {0} is still the owner.", book.Owner);
                                break;
                        }
                        break;

                    //User will read the book
                    case "read":
                        book.TotalTimesRead += 1;
                        Console.WriteLine("The total times read is now {0}.", book.TotalTimesRead);
                        break;

                    //Prints out the information about the book, including owner and total times read
                    case "print":
                        book.Print();
                        break;

                    //Quit the program
                    case "done":
                        Console.WriteLine("Goodbye!");
                        break;

                    //Everything else
                    default:
                        Console.WriteLine("Invalid Input.");
                        break;
                }

            }
        }
    }
}
