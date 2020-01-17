using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    abstract class Player
    {
        Card[] hand;
        private const int NUMBEROFCARDS = 13;
        private int currentsize;

        public Player()
        {
            hand = new Card[NUMBEROFCARDS];
            currentsize = 0; //holds the number of cards currently in hand
        }

        public void addToHand(Card newCard) //adds a card to the end of card queue
        {
            hand[currentsize] = newCard;
            currentsize++;
        }

        public Boolean CheckSevenDiamonds() //checks whether player's hand contains the 7 of diamonds
        {
            for (int i = 0; i < NUMBEROFCARDS; i++)
            {
                if (hand[i].equalsSevenOfDiamonds()) {
                    return true;
                }
            }
            return false;
        }

        public String[] arrayOfCardsToArrayOfStrings(Card[] hand) //returns a string of the user's cards
        {
            String[] stringCards = new String[13];

            for (int i = 0; i < 13; i++)
            {
                stringCards[i] = hand[i].getStringSuit() + hand[i].getStringValue();
            }

            return stringCards;
        }


    //    public String[] orderCards()
      //  {
        //    HumanPlayer.MergeValue();
     //   }

        public Card[] getCards() //returns hand
        {
            return hand;
        }
        public abstract Card Move();
        
           

        public Boolean CheckWin()
        {
            return false;
        }


    }
}
