using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class DummyPlayer : Player
    {
        public DummyPlayer()
        {

        }

        public override Card getCardToBePlayed(Board board)
        {
            Card dummyCard = new Card(-1, -1);
            return dummyCard;
        }

        public override Card Move(Board board)
        {
            return getCardToBePlayed(board);
        }
    }
 
}
