using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW3_LinkedLists
{
    // DO NOT MODIFY THIS FILE EXCEPT WHERE MARKED
    // NO NEW class fields/properties!
    class Deck
    {
        // Each Deck is effectively a doubly linked list of Card objects that it manages
        // via references to the head and tail (top and bottom) cards + a field to track
        // the current # of cards
        private Card head;
        private Card tail;
        private int count;

        /// <summary>
        /// Returns the current number of Cards
        /// </summary>
        public int Count
        {
            get { return count; }
        }

        /// <summary>
        /// Implement an indexer property for the list that correctly gets 
        /// data in the node at a specific index. If the index is invalid, throw 
        /// an IndexOutOfRangeException exception. 
        /// </summary>
        public Card this[int index]
        {
            //only gets data at the current index, no need to set it
            get
            {
                // TODO: IMPLEMENT THIS (but you should really implement Add and test it using the debugger first!)
                Card current = head;

                //if the index is 0 or ends up being greater than the count
                if(index < 0 || index >= Count)
                {
                    //throws out of range exception
                    throw new IndexOutOfRangeException(
                        String.Format("Index {0} does not work for the list with a count of {1}.", index, Count));
                }

                //for each variable in the index
                for(int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                //returns card in current index
                return current;
            }
        }

        /// <summary>
        /// Add a new Card object (with the specified suit and rank) to the end of the list. 
        /// Increment the count and update the head and/or tail when you add the card.
        /// </summary>
        public void Add(CardSuit suit, CardRank rank)
        {
            // TODO: IMPLEMENT THIS (and test it by checking the Deck contents using the debugger!)
            //variables
            Card hand = new Card(suit, rank);

            //if the head is null
            if(head == null)
            {
                //adds the card to the start of the deck
                hand.Previous = null;
                head = hand;
                tail = hand;
            }
           
            //if the head equals something other than null
            else
            {
                //adds the card to the end of the deck
                tail.Next = hand;
                hand.Previous = tail;
                tail = hand;
            }

            //increment the counter
            count++;
        }

        /// <summary>
        /// This method should utilize the “next” field of each node to print 
        /// out all of the cards in order.  This will help to test if all of 
        /// your “arrows” point to the correct “boxes”.
        /// </summary>
        public void Print()
        {
            // TODO: IMPLEMENT THIS
            Console.WriteLine("The deck has {0} cards:", Count);

            //for each card in the deck
            for(int i = 0; i < Count; i++)
            {
                //print out a card from the deck
                Console.WriteLine("\t" + this[i]);
            }
        }

        /// <summary>
        /// This method should utilize the “previous” field of each node to 
        /// print out all of the data in reverse order.  This will help to 
        /// test if all of your “arrows” point to the correct “boxes”.
        /// </summary>
        public void PrintReversed()
        {
            // TODO: IMPLEMENT THIS
            Console.WriteLine("The deck has {0} cards:", Count);

            //for each card in the deck
            for (int i = Count - 1; i >= 0; i--)
            {
                //print out a card from the deck
                Console.WriteLine("\t" + this[i]);
            }
        }

        /// <summary>
        /// This method will clear the list.  Update the count attribute, 
        /// as well as the head and tail.
        /// </summary>
        public void Clear()
        {
            // TODO: IMPLEMENT THIS
            //resets the head, tail and count
            count = 0;
            head = null;
            tail = null;
        }

        /// <summary>
        /// This method returns a deck for each player that represents the cards 
        /// in that player’s hand. All the cards in the deck need to be dealt out 
        /// to the players. All players do not need to have the same number of 
        /// cards.
        /// 
        /// Hint: Remember that while, after dealing cards in real life, the full deck
        ///         is split among the players into N smaller decks, but the total
        ///         number of cards remains the same and no cards are repeated. This
        ///         is NOT what will happen here. In order to preserve the links in the
        ///         main deck, your deal will COPY the cards as it adds them to each
        ///         player's deck!
        /// </summary>
        public List<Deck> DealPlayerHands(int playerCount)
        {
            // TODO: IMPLEMENT THIS
            //variables
            List<Deck> player = new List<Deck>();
            Random rand = new Random();
            Card newCard = head;

            //for each player in the game
            for (int i = 0; i < playerCount; i++)
            {
                //creates a new deck for each player
                player.Add(new Deck());
            }

            //for each card in the deck
            for(int j = 0; j < Count; j++)
            {
                //puts a random card into one of the hands for the players
                player[rand.Next(0, playerCount)].Add(newCard.Suit, newCard.Rank);
                //so cards do not repeat
                newCard = newCard.Next;
            }

            //returns the deck of the player
            return player; // TMP so starter code compiles
        }

        /// <summary>
        /// This method will remove a number of cards from the end of the list and 
        /// insert them back into the list before a certain index. This method only 
        /// has to worry about moving one group of cards in the deck. The main program 
        /// will repeatedly call this method to shuffle the entire deck.  The first 
        /// parameter is the number of cards to be removed from the end of the list. 
        /// The second parameter is the new index of the first card in the 
        /// group of cards that were moved in the list.
        /// 
        /// Notes:
        ///     - You can assume valid parameters will be give for the size of the deck.
        ///     - If you leverage your this[] get indexer, there's no need for loops here.
        /// </summary>
        public void Move(int cardsToMove, int targetIndex)
        {
            // TODO: IMPLEMENT THIS
            //variables
            Card start = this[Count - cardsToMove]; //first card getting moved
            Card end = start.Previous; //last card getting moved
            Card after = this[targetIndex]; //target location
            Card before = after.Previous; //area before the target location
            Card newTail; //the new tail

            //if the value before the target index is null
            if (before == null)
            {
                //makes the tail the new head and move the the old head forward
                head.Previous = tail;
                newTail = head;
                tail.Next = newTail;

                //makes the next card the tail
                newTail = end;
                tail = newTail;

                //makes the end of the tail null
                tail.Next = null;

                //make the card moved to the front the new head
                head = start;
                head.Previous = null;
            }

            //if it is anything but null
            else
            {
                //make the tail equal to the target index
                tail.Next = after;

                //move the head to the index before the target index
                start.Previous = before;

                after.Previous = tail;
                newTail = end;
                tail = newTail;

                //makes the end of the tail null
                tail.Next = null;

                //move the first card move to the target index
                before.Next = start;
            }
        }
    }
}
