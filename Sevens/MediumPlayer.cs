using System;
using System.Collections.Generic;
using System.Linq;

namespace Sevens
{
    //MediumPlayer class inherits from AIPlayer, overriding the DetermineCardToBePlayed class, and adding the CalculateBenefit and SameSide class which only exist within the MediumPlayer class
    class MediumPlayer : AIPlayer
    {

        public MediumPlayer()
        {

        }


        public override void DetermineCardToBePlayed(Board board) //gets card which is of maximum benefit to the AI player
        {
            List<Card> possibleMoves = getPossibleMoves(board);
            int[] moveScores = new int[possibleMoves.Count];
            int max = 0;
            Card card = base.GetCards().FirstOrDefault();


                for (int i = 0; i < possibleMoves.Count; i++) //loops through possible moves and finds score of each one
                {
                    moveScores[i] = CalculateBenefit(possibleMoves.ElementAt(i));


                    if (moveScores[i] > max) //if score is the biggest of the possible moves so far, then update cardToReturn
                    {
                        max = moveScores[i];
                        card = possibleMoves.ElementAt(i);
                    }

                }

            setCardToBePlayed(card);
         }

        public int CalculateBenefit(Card possibleMoveCard) //counter increments by one each time another card of the same suit and the same side of the seven is found in their hand
        {
            int counter = 0;

            for (int i = 0; i < base.GetCurrentSize(); i++)
            {
                if ((base.GetCards()[i].getSuit() == possibleMoveCard.getSuit()) && SameSide(possibleMoveCard, base.GetCards()[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        public Boolean SameSide(Card possibleMoveCard, Card comparisonCard) //checks whether both cards are the same side of the seven
        {
            if (((possibleMoveCard.getValue() < 7) && (comparisonCard.getValue() < 7)) || ((possibleMoveCard.getValue() > 7) && (comparisonCard.getValue() > 7)))
            {
                return true;
            }
            else if (possibleMoveCard.getValue() == 7)
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
