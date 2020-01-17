using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class Deck
    {
       public Card[] deck;
       public int frontPointer;

        public Deck() //creates deck with all cards
        {
            deck = new Card[52]; 
            frontPointer = 0;

            int counter = 0;

            for (int suitCounter = 0; suitCounter < 4; suitCounter++)
            {
                for (int valueCounter = 2; valueCounter < 15; valueCounter++)
                {
                    deck[counter] = new Card(valueCounter, suitCounter);
                    counter++;
                }
            }
        }
        public void Shuffle() //shuffles deck by swapping random pairs of cards
        {
            Card temp;
            Random random = new Random();

            for (int i = 0; i < 50; i++)
            {

                int first = random.Next(52);
                int second = random.Next(52);
                temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public Card getNextCard() //returns card from top of deck
        {
            int currentTop = frontPointer;

            frontPointer++;
            return deck[currentTop];

        }

        public Boolean isEmpty() //if no cards are in deck (front of deck is at position 52- a position which doesn't exist), return true
        {
            if (frontPointer >= 52)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
