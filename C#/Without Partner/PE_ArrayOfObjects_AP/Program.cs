using System;

namespace PE_ArrayOfObjects_AP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Variables
            int result;
            Deck deck = new Deck();

            //Prints out the entire deck
            deck.Print();

            //Prompt user for how many cards they want dealt
            Console.Write("\nHow many cards do you want to deal?\n > ");
            bool success = int.TryParse(Console.ReadLine(), out result);

            //While the user input does not work
            while(result <= 0 || !success)
            {
                Console.Write("\nInvalid Input\nHow many cards do you want to deal?\n > ");
                success = int.TryParse(Console.ReadLine(), out result);
            }

            //Will print out the dealt cards
            deck.Deal(result);
        }
    }
}
