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
            // AI players gang up
            //counts cards of each suit in human player, then plays card of that suit
        List<Card> possibleMoves = getPossibleMoves(board);

            if (possibleMoves.Count == 0)
            {
                setCardToBePlayed(base.getCards().FirstOrDefault());
            }
            else
            {
                int[] humanValues = board.getQueue().getHumanPlayer().cardsSuitCounts();

                //sort human values
                //create new list of their indexes in position

                for (int a = 0; a < 4; a++)
                {
                    int i = humanValues.ToList().IndexOf(humanValues.Min());
                    humanValues.ToList().Remove(humanValues.Min());
                    Card card = possibleMoves.Find(item => item.getSuit() == i);
                    
                    setCardToBePlayed(card);
                    
                }

                //what if none of this suit
            }
        }
    }
}
