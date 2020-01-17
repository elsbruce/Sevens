using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class Board
    {
        private int[] min;
        private int[] max;

        // diamonds 0, hearts 1, clubs 2, spades 3
        // int[4][3] = [min,max, 0 if ace hasn't been played, 1 if it has]

        public Board()
        {
            min = new int[] { 8, 8, 8, 8 };
            max = new int[] { 7, 7, 7, 7 }; //initialise all maxs to 7
        }

        public Boolean Add(Card card)
        {
            if (card.getValue()< min[card.getSuit()])
            {
                min[card.getSuit()] = card.getValue();
                return true;
            }
            else if (card.getValue() > max[card.getSuit()])
            {
                max[card.getSuit()] = card.getValue();
                return true;
            }
            else
            {
                return false;
            }

            
        }
        /*
        public Boolean checkEnd()
        {
            if ((min[0] == 2) && (min[1] == 2) && (min[2] == 2) && (min[3] == 2)) //incomplete, what about aces?
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        */
        public void saveBoard()
        {

        }
    }
}
