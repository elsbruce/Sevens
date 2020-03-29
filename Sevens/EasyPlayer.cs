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

        public override void DetermineCardToBePlayed(Board board)
        {
            // 1 in 4 chance of returning random card, otherwise returns first of possible moves

            Random random = new Random();
            if (random.Next(0, 3) == 0)
            {
                setCardToBePlayed(base.GetCards().FirstOrDefault());
            }
            else
            {
                List<Card> possibleMoves = getPossibleMoves(board);

                if (possibleMoves.Count == 0)
                {
                    setCardToBePlayed(base.GetCards().FirstOrDefault());
                }
                else
                {
                    setCardToBePlayed(possibleMoves.First());
                }
            }
        }

    }
}
