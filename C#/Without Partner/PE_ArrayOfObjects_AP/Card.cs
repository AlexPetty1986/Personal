using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArrayOfObjects_AP
{
    //The values and faces of the cards in the deck
    class Card
    {
        //Private fields
        private int value;
        private String suit;

        //Constructor class
        public Card(int value, String suit)
        {
            this.value = value;
            this.suit = suit;
        }

        //Prints the cards to the screen
        public void Print()
        {
            //Determines the value on the card
            switch(value)
            {
                //Ace
                case 1:
                    Console.WriteLine("Ace of " + suit);
                    return;

                //Jack
                case 11:
                    Console.WriteLine("Jack of " + suit);
                    return;

                //Queen
                case 12:
                    Console.WriteLine("Queen of " + suit);
                    return;

                //King
                case 13:
                    Console.WriteLine("King of " + suit);
                    return;

                //2-10
                default:
                    Console.WriteLine(value + " of " + suit);
                    return;
            }
        }
    }
}
