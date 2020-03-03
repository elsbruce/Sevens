using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class MediumPlayer : AIPlayer
    {

        public MediumPlayer()
        {

        }


        public override Card getCardToBePlayed(Board board) //gets card which is of maximum benefit to the AI player
        {
            List<Card> possibleMoves = getPossibleMoves(board);
            int[] moveScores = new int[possibleMoves.Count];
            int max = 0;
            Card cardToReturn = base.getCards().FirstOrDefault();

            if (possibleMoves.Count == 0)
            {
                return cardToReturn;
            }

            for (int i = 0; i < possibleMoves.Count; i++) //loops through possible moves and finds score of each one
            {
                moveScores[i] = Count(possibleMoves.ElementAt(i));


                if (moveScores[i] > max) //if score is the biggest of the possible moves so far, then update cardToReturn
                {
                    max = moveScores[i];
                    cardToReturn = possibleMoves.ElementAt(i);
                }

            }
            return cardToReturn;

         }

        public int Count(Card possibleMoveCard) //counter increments by one each time another card of the same suit and the same side of the seven is found in their hand
        {
            int counter = 0;

            for (int i = 0; i < base.getCurrentSize(); i++)
            {
                if ((base.getCards()[i].getSuit() == possibleMoveCard.getSuit()) && sameSide(possibleMoveCard, base.getCards()[i]))
                {
                    counter++;
                }
            }

            return counter;
        }

        public Boolean sameSide(Card possibleMoveCard, Card comparisonCard) //checks whether both cards are the same side of the seven
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
