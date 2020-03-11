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

        public override Card determineCardToBePlayed(Board board)
        {
            Card dummyCard = new Card(7, 0);
            return dummyCard;
        }

        public override Card Move()
        {
            return determineCardToBePlayed(board);
        }

       
    }
 
}
