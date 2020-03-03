using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    abstract class Player
    {
        List<Card> listOfCards;

        public Player()
        {
            listOfCards = new List<Card>();
        }

        public void addToHand(Card newCard) //adds a card to the end of card queue
        {
            listOfCards.Add(newCard);
        }

        public Boolean CheckSevenDiamonds() //checks whether player's hand contains the 7 of diamonds
        {
            foreach (Card card in listOfCards)
            {
                if (card.equalsSevenOfDiamonds())
                {
                    listOfCards.Remove(card);
                    return true;
                }
            }

            return false;
        }

        public String[] getStringArrayOfCards() //returns a string of the user's cards
        {
            String[] stringCards = new String[13];
            int i = 0;

            foreach (Card card in listOfCards)
            {
                stringCards[i] = card.getStringSuit() + card.getStringValue();
                i++;
            }

            return stringCards;
        }


        public abstract Card Move(Board board);
        public abstract Card getCardToBePlayed(Board board);

        public Card removeCard(Card cardToBeRemoved)
        {
            listOfCards.Remove(cardToBeRemoved);
            return cardToBeRemoved;
        }

        public void sortCards(Boolean bySuit)
        {
            listOfCards = MergeSort(listOfCards, bySuit);
        }

        public Boolean handEmpty()
        {
            if (listOfCards.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int[] cardsSuitCounts()
        {
            int[] cardCount = new int[4] { 0, 0, 0, 0 };

            for (int i = 0; i < getCurrentSize(); i++)
            {
                cardCount[getCards()[i].getSuit()]++;
            }

            return cardCount;
        }

        private static List<Card> MergeSort(List<Card> unsorted, Boolean bySuit)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<Card> left = new List<Card>();
            List<Card> right = new List<Card>();

            int mid = unsorted.Count / 2;
            for (int i = 0; i < mid; i++)  //Dividing the unsorted list
            {
                left.Add(unsorted.ElementAt(i));
            }
            for (int i = mid; i < unsorted.Count; i++)
            {
                right.Add(unsorted.ElementAt(i));
            }

            left = MergeSort(left, bySuit);
            right = MergeSort(right, bySuit);
            return Merge(left, right, bySuit);
        }

        private static List<Card> Merge(List<Card> left, List<Card> right, Boolean bySuit)
        {
            List<Card> mergedList = new List<Card>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (bySuit)
                    {
                        if (compareBySuit(left, right))  //compares first two elements to see which has smaller value
                        {
                            mergedList.Add(left.First());
                            left.Remove(left.First());
                        }//removes first element from left list and adds it to merged list
                        else
                        {
                            mergedList.Add(right.First());
                            right.Remove(right.First());
                        }
                    }
                    else
                    {
                        if (compareByValue(left, right))  //compares first two elements to see which has smaller value
                        {
                            mergedList.Add(left.First());
                            left.Remove(left.First());
                        }//removes first element from left list and adds it to merged list
                        else
                        {
                            mergedList.Add(right.First());
                            right.Remove(right.First());
                        }
                    }
                }
                else if (left.Count > 0) //if right tree is empty, add first element of left tree
                {
                    mergedList.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0) //if left tree is empty add first element of right tree
                {
                    mergedList.Add(right.First());

                    right.Remove(right.First());
                }
            }
            return mergedList;
        }

        public static Boolean compareByValue(List<Card> left, List<Card> right)
        {
            return (left.First().getValue() <= right.First().getValue());
        }

        public static Boolean compareBySuit(List<Card> left, List<Card> right)
        {
            return (left.First().getSuit() <= right.First().getSuit());
        }
        public int getCurrentSize()
        {
            return listOfCards.Count;
        }

        public List<Card> getCards() //returns hand
        {
            return listOfCards;
        }
    }
}