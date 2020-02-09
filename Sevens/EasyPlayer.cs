using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class EasyPlayer : AIPlayer
    {
        public EasyPlayer()
        {

        }

        public override Card getCardToBePlayed(Board board)
        {
            // 1 in 4 chance of returning random card, otherwise returns first of possible moves

            Random random = new Random();
            if (random.Next(0, 3) == 0)
            {
                return base.getCards().FirstOrDefault();
            }

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
