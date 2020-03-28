﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Sevens
{
    abstract class Player
    {
        List<Card> listOfCards;
        Boolean passToken;

        public Player()
        {
            listOfCards = new List<Card>();
            passToken = false;
        }


        //takes the Card to be added to the hand
        //adds the card to the end of the listOfCards
        public void addToHand(Card newCard)
        {
            listOfCards.Add(newCard);
        }

        //returns a Boolean representing whether the player's hand contains the 7 of diamonds
        //returns true if the seven of diamonds is in the player's list of cards, and false is the seven of diamonds is not in the player's list of cards
        public Boolean CheckSevenDiamonds() 
        {
            foreach (Card card in listOfCards)
            {
                if (card.equalsSevenOfDiamonds())
                {
                    removeCard(card);
                    return true;
                }
            }

            return false;
        }

        //returns a string array representation of the user's cards
        //loops through each of the cards in the player's hand, and gets the string representation of each of the card's in the listOfCards and adds it to the string array
        public String[] getStringArrayOfCards() 
        {
            String[] stringCards = new String[getCurrentSize()];
            for (int i = 0; i < getCurrentSize(); i++)
            {
                stringCards[i] = getCards()[i].suitIntToString() + getCards()[i].getValue().ToString();
            }

            return stringCards;
        }


        public abstract Card Move();
        public abstract Card retrieveCardToBePlayed(Board board);

        public void removeCard(Card cardToBeRemoved)
        {
            listOfCards.Remove(cardToBeRemoved);
        }

        public void sortCards(Boolean bySuit)
        {
            listOfCards = MergeSort(listOfCards, bySuit);
        }

        public virtual Boolean handEmpty()
        {
            if (getCurrentSize() == 0)
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
            {
                return unsorted;
            }
            else
            {
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

        //returns an integer which is the length of the listOfCards
        public virtual int getCurrentSize()
        {
            return listOfCards.Count;
        }

        public List<Card> getCards()
        {
            return listOfCards;
        }

        public Boolean getPassToken()
        {
            return passToken;
        }

        public void setPassToken(Boolean input)
        {
            passToken = input;
        }
    }
}