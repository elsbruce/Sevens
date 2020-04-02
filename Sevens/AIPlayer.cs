
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
            RemoveCard(getCardToBePlayed());
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

        public override Card RetrieveCardToBePlayed(Board board)
        {
            DetermineCardToBePlayed(board);
            return getCardToBePlayed();
        }

        public abstract void DetermineCardToBePlayed(Board board);
        protected List<Card> getPossibleMoves(Board board)
        {
            List<Card> possibleMoves = new List<Card>();

            for (int i = 0; i < GetCurrentSize(); i++)
            {
                if (board.ValidMove(base.GetCards()[i]) == "y")
                {
                    possibleMoves.Add(base.GetCards()[i]);
                }
            }

            return possibleMoves;
        }

    }
}
