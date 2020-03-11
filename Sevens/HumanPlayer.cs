using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{ //when a card is hidden from gui, name isn't changed
    //when a card is removed from player hand, reference is changed therefore number is reduced
    class HumanPlayer : Player
    {

        public override Card Move()
        {
            return null;
        }

        public override Card retrieveCardToBePlayed(Board board)
        {
            return null;
        }


        }

    }