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
                setCardToBePlayed(possibleMoves.Find(item => item.getSuit() == humanValues.ToList().IndexOf(humanValues.Max())));
                //what if none of this suit
            }
        }
    }
}
