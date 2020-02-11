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

        public override Card getCardToBePlayed(Board board)
        {
            // AI players gang up
            //counts cards of each suit in human player, then plays card of that suit
        List<Card> possibleMoves = getPossibleMoves(board);

            if (possibleMoves.Count == 0)
            {
                return base.getCards().FirstOrDefault();
            }
            else
            {
                int[] humanValues = board.getQueue().getHumanPlayer().cardsSuitCounts();
                humanValues.OrderBy
                return possibleMoves.First();
            }
        }
    }
}
