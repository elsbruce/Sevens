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

        List<Card> possibleMoves = getPossibleMoves(board);

            if (possibleMoves.Count == 0)
            {
                return base.getCards().FirstOrDefault();
            }
            else
            {
                return possibleMoves.First();
            }
        }
    }
}
