using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class AIPlayer : Player {
      //  int index;
        public AIPlayer()
        {
          //  index = 0; // temporary, will be deleted when AI is added
        }
        public override Card Move()
        {
            Card card = getCardToBePlayed();
            playCard(card);
         //   index = 0;
            return card;
        }

        public override Card getCardToBePlayed() //AI will go here
        {
            //if (index < (base.getCurrentSize() - 1)) //-1 because first index is 0
            //{
            //    index++;
            //}
            //else
            //{
            //    index = 0;
            //}
            return base.getCards().FirstOrDefault();
        }

        public void playCard(Card cardToBePlayed)
        {
            removeCard(cardToBePlayed);
        }
    }
    }
