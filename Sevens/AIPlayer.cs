using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class AIPlayer : Player {
        public AIPlayer()
        {
        }
        public override Card Move(Board board)
        {
            Card card = getCardToBePlayed(board);
            playCard(card);
            return card;
        }

        public override Card getCardToBePlayed(Board board) //AI will go here
        {
            for (int i = 0; i < getCurrentSize(); i++)
            {
                if (board.validMove(base.getCardAt(i)) == "y")
                {
                    return base.getCardAt(i);
                }
            }
            return base.getCards().FirstOrDefault();
        }

        public void playCard(Card cardToBePlayed)
        {
            removeCard(cardToBePlayed);
        }

        
    }
    }
