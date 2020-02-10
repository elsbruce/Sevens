using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class MediumPlayer : AIPlayer
    {

        public MediumPlayer(){

        }


        public override Card getCardToBePlayed(Board board)
        {
            {
                List<Card> possibleMoves = getPossibleMoves(board);
                int[] moveScores = new int[possibleMoves.Count];

       //         List<Card> cardsOfSuit

                for (int i = 0; i < possibleMoves.Count; i++)
                {
                    Card currentMove = possibleMoves.ElementAt(i);

                    
                }

                sortCards(true);

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
}
