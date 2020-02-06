using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    abstract class AIPlayer : Player {

        private List<Card> possibleMoves; //do i need this??
        public AIPlayer(int difficulty)
        {
            possibleMoves = new List<Card>();

            if (difficulty == 1)
            {
                
            }

        }
        public override Card Move(Board board)
        {
            Card card = getCardToBePlayed(board);
            playCard(card);
            return card;
        }

        public override Card getCardToBePlayed(Board board); //AI will go here
      

        public void playCard(Card cardToBePlayed)
        {
            removeCard(cardToBePlayed);
        }

        protected List<Card> getPossibleMoves(Board board)
        {
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
