using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class DifficultPlayer : AIPlayer
    {

        public DifficultPlayer()
        {

        }

        public override void determineCardToBePlayed(Board board)
        {
            //AI players gang up
            //counts cards of each suit in human player, then plays card of that suit
            List<Card> possibleMoves = getPossibleMoves(board);
            List<Card> bestMoves = new List<Card>();

            if (possibleMoves.Count == 0)
            {
                setCardToBePlayed(base.getCards().FirstOrDefault());
            }
            else
            {
                List<int> humanValues = board.getQueue().GetHumanPlayer().cardsSuitCounts().OfType<int>().ToList();

                
                //finds suit of min value in human values, removes this min value from human values, if there is a card of this suit in valid moves, then returns this
                //loops through 4 times, to go through each of the 4 suits in order of how beneficial they are to the human player- but loop is broken when a card of the suit being searched for is found
                for (int a = 0; a < 4; a++)
                {
                    int index = humanValues.IndexOf(humanValues.Min());
                    humanValues.Insert(index, 99);

                    bestMoves = possibleMoves.FindAll(item => item.getSuit() == index); //all possible moves of worst suit for human player

                    if (bestMoves.Count == 1) //one move of human's worst possible suit
                    {
                        setCardToBePlayed(bestMoves.FirstOrDefault());
                        break;
                    }
                    else if (bestMoves.Count > 1) //more than one move of worst possible suit
                    { //calculates using other AIs


                        int[] moveScores = new int[possibleMoves.Count];
                        int max = 0;

                        Player temp = getNextAIPlayer(board);

                        for (int i = 0; i < bestMoves.Count; i++) //loops through possible moves and finds score of each one
                        {
                            moveScores[i] = Count(temp, bestMoves.ElementAt(a));


                            if (moveScores[i] > max) //if score is the biggest of the possible moves so far, then update cardToReturn
                            {
                                max = moveScores[i];
                                setCardToBePlayed(bestMoves.ElementAt(i));
                            }
                        }
                        break;
                    }
                }
            }
        }

        public int Count(Player player, Card possibleMoveCard) //counter increments by one each time another card of the same suit and the same side of the seven is found in their hand
        {
            int counter = 0;

            for (int i = 0; i < player.getCurrentSize(); i++)
            {
                if ((player.getCards()[i].getSuit() == possibleMoveCard.getSuit()) && sameSide(possibleMoveCard, player.getCards()[i]))
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

        public Player getNextAIPlayer(Board board)
        {
            Player temp = new DifficultPlayer();

            temp = board.getQueue().GetNextPlayer();
            if (board.getQueue().GetCurrentPlayer().GetType().ToString() == "HumanPlayer")
            {
                temp = board.getQueue().GetNextPlayer();
                board.getQueue().CurrentPlayerMinusOne();
            }
            board.getQueue().CurrentPlayerMinusOne();

            return temp;
        }
    }
}
        