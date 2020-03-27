using System;

namespace Sevens
{
    class Deck
    {
       public Card[] deck;
       public int frontPointer;
       public const int SIZEOFDECK = 52;

        public Deck() //creates deck with all cards (of each of the four suits, and with all values from 2 to 14)
        {
            deck = new Card[SIZEOFDECK]; 
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

            for (int i = 0; i < SIZEOFDECK; i++)
            {

                int first = random.Next(SIZEOFDECK);
                int second = random.Next(SIZEOFDECK);
                temp = deck[first];
                deck[first] = deck[second];
                deck[second] = temp;
            }
        }

        public Card GetNextCard() //returns card from top of deck (first item in array), increments the front pointer to point at the next card in the deck
        {
            int currentTop = GetFrontPointer();
            SetFrontPointer(GetFrontPointer()+1);
            return GetDeck()[currentTop];

        }

        public Boolean IsEmpty() //if no cards are in deck (front of deck is at position 52- a position which doesn't exist), return true
        {
            if (GetFrontPointer() >= SIZEOFDECK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetFrontPointer(int input)
        {
            frontPointer = input;
        }

        public void SetDeck(Card[] input)
        {
            deck = input;
        }

        public int GetFrontPointer()
        {
            return frontPointer;
        }

        public Card[] GetDeck()
        {
            return deck;
        }
    }
}
