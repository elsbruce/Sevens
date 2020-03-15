
using System.Collections.Generic;

namespace Sevens
{
    abstract class AIPlayer : Player {
        private Card cardToBePlayed;
    
        public AIPlayer()
        {
            
        }
        public override Card Move()
        {
            removeCard(getCardToBePlayed());
            return getCardToBePlayed();
        }

        protected void setCardToBePlayed(Card card)
        {
            cardToBePlayed = card;
        }
        public Card getCardToBePlayed()
        {
            return cardToBePlayed;
        }

        public override Card retrieveCardToBePlayed(Board board)
        {
            determineCardToBePlayed(board);
            return getCardToBePlayed();
        }

        public abstract void determineCardToBePlayed(Board board);
        protected List<Card> getPossibleMoves(Board board)
        {
            List<Card> possibleMoves = new List<Card>();

            for (int i = 0; i < getCurrentSize(); i++)
            {
                if (board.validMove(base.getCards()[i]) == "y")
                {
                    possibleMoves.Add(base.getCards()[i]);
                }
            }

            return possibleMoves;
        }

    }
}
