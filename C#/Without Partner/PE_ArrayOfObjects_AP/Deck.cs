using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_ArrayOfObjects_AP
{
    //Saves objects into the deck and then deals them randomly
    class Deck
    {
        //Private fields
        private Random rng;
        private Card[] deck;

        //Constructor class
        public Deck()
        {
            //The deck and the dealer
            this.deck = new Card[52];
            this.rng = new Random(deck.Length);
            //Used for the array
            int cardsInDeck = 0;
            String[] cardSuit = { "Hearts", "Spades", "Diamonds", "Clubs" };

            //Add the objects into the array
            for (int j = 0; j < 4; j++)
            {
                string suit = cardSuit[j]; 
                for (int num = 1; num < 14; num++)
                {
                    deck[cardsInDeck] = new Card(num, suit);
                    cardsInDeck++;
                }
            }
        }

        //Prints out the entire deck using the Print method in the Card class
        public void Print()
        {
            //Deals out the cards in the deck
            Console.WriteLine("Cards in Deck" +
                "\n------------------------------------------------");
            for (int i = 0; i < deck.Length; i++)
            {
                deck[i].Print();
            }
        }

        //Deals out random cards from the deck
        public void Deal(int amount)
        {
            Console.WriteLine("\nCards Dealt" +
                "\n------------------------------------------------");

            //Used to deal the cards out in a randomized order
            for (int i = 0; i < amount; i++)
            {
                deck[rng.Next(deck.Length)].Print();
            }
        }
    }
}
