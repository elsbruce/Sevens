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
                List<int> humanValues = board.getQueue().getHumanPlayer().cardsSuitCounts().OfType<int>().ToList();
                humanValues.AsReadOnly();
                List<int> temp = humanValues;
                temp.Sort();

                //sort human values
                //create new list of their indexes in position

                //finds suit of min value in human values, removes this min value from human values, if there is a card of this suit in valid moves, then returns this
                //loops through 4 times, to go through each of the 4 suits in order of how beneficial they are to the human player
                for (int a = 0; a < 4; a++)
                {
                    int i = humanValues.IndexOf(humanValues.Min());
                    humanValues.Insert(i, 99);

                    bestMoves = possibleMoves.FindAll(item => item.getSuit() == i);

                    if (bestMoves.Count == 1)
                    {
                        setCardToBePlayed(bestMoves.FirstOrDefault());
                        break;
                    }
                    else if (bestMoves.Count > 1)
                    { //calculates using other AIs

                        board.getQueue().getNextPlayer().getCards();
                        if (board.getQueue().getCurrentPlayer().GetType().ToString() == "HumanPlayer")
                        {
                            board.getQueue().getNextPlayer().getCards();
                            board.getQueue().currentPlayerMinusOne();
                            board.getQueue().currentPlayerMinusOne();
                        }
                        board.getQueue().currentPlayerMinusOne();
                        setCardToBePlayed(bestMoves.FirstOrDefault());
                        break;
                    }

                }
            }
            }
        }
    }