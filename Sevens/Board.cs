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
        private Boolean[] sevens;
        private Boolean[] aces;
        private Queue queue;
        private int[] sizeOfPlayersHands;
        private System.Windows.Forms.Timer timer;

        // diamonds 0, hearts 1, clubs 2, spades 3

        //sort out timer
       

        public Board()
        {
            min = new int[] { 7, 7, 7, 7 }; //initialise all mins to 7
            max = new int[] { 7, 7, 7, 7 }; //initialise all maxs to 7
            sevens = new bool[] { false, false, false, false };
            aces = new bool[] { false, false, false, false };
            queue = new Queue();
            sizeOfPlayersHands = new int[4];
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);

        }

        public Queue getQueue()
        {
            return queue;
        }
        public int[] getMin()
        {
            return min;
        }

        public int[] getMax()
        {
            return max;
        }

        public int[] getSizeOfPlayersHands()
        {
            for (int i = 0; i < 4; i++)
            {
                sizeOfPlayersHands[i] = queue.getQueue()[i].getCurrentSize();
            }

            return sizeOfPlayersHands;
        }

        public Boolean[] getSevens()
        {
            return sevens;
        }

        public void Add(Card card)
        {
            if (card.getValue() == 7) {
                sevens[card.getSuit()] = true;
            }
            else if (card.getValue() < min[card.getSuit()])
            {
                min[card.getSuit()] = card.getValue();
            }
            else if (card.getValue() > max[card.getSuit()])
            {
                max[card.getSuit()] = card.getValue();
            }
        }


        public String validMove(Card card)
        {
            //returns 2 if move is one less than cards already played in that suit, or if card to be played is a seven, 1 if move is not null but is not valid, and 0 if move is null

            if (card == null)
            {
                return "null";
            }
            else if ((sevens[card.getSuit()] == true) && (card.getValue() == (min[card.getSuit()] - 1)))
            {
                return "y";
            }
            else if ((sevens[card.getSuit()] == true) && (card.getValue() == (max[card.getSuit()] + 1)))
            {
                return "y";
            }
            else if (card.getValue() == 7)
            {
                return "y";
            }
            else
            {
                return "n";
            }

        }
        public void sevenOfDiamonds() 
            {

            Boolean sevenFound = false;

            while (!(sevenFound)) //this is wrong but stops an infinite loop
            {
                sevenFound = queue.getNextPlayer().CheckSevenDiamonds();
            }

            sevens[0] = true;
        }
        
        public Boolean checkEnd()
        {            
                for (int i = 0; i < 4; i++)
                {
                    if ((min[i] != 2) | (max[i] != 13) | (sevens[i] != true) | (aces[i] != true))
                {
                    return false;
                }
                }
            return true;
     
        }
        
        void timer_Tick(object sender, EventArgs e)
        {

        }
        public void saveBoard()
        {

        }
    }
}
