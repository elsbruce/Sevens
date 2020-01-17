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
        public override Card Move()
        {
            return (base.getCards())[0];
        }
    }
    }
