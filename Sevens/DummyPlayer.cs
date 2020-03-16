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

        public override Card retrieveCardToBePlayed(Board board)
        {
            Card dummyCard = new Card(7, 0);
            return dummyCard;
        }

        public override Card Move()
        {
            return new Card(7,0);
        }

       public override Boolean handEmpty()
        {
            return true;
        }

        public override int getCurrentSize()
        {
            return 0;
        }
    }
 
}
