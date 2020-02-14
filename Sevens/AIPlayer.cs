
using System.Collections.Generic;

namespace Sevens
{
    abstract class AIPlayer : Player {

    
        public AIPlayer()
        {
            
        }
        public override Card Move(Board board)
        {
            Card card = getCardToBePlayed(board);
            playCard(card);
            return card;
        }



        public void playCard(Card cardToBePlayed)
        {

            removeCard(cardToBePlayed);
        }

        protected List<Card> getPossibleMoves(Board board)
        {
            List<Card> possibleMoves = new List<Card>();

            for (int i = 0; i < getCurrentSize(); i++)
            {
                if (board.validMove(base.getCardAt(i)) == "y")
                {
                    possibleMoves.Add(base.getCardAt(i));
                }
            }

            return possibleMoves;
        }

}
    }
