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
        private Queue queue;
        private int[] sizeOfPlayersHands;
        private System.Windows.Forms.Timer timer;

        // diamonds 0, hearts 1, clubs 2, spades 3

        //sort out timer, possibly increment aces in the same way as 7s?
       

        public Board()
        {
            min = new int[] { 7, 7, 7, 7 };
            max = new int[] { 7, 7, 7, 7 }; //initialise all maxs to 7
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

        public void Add(Card card)
        {
            if (card.getValue() < min[card.getSuit()])
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
            else if (card.getValue() == (min[card.getSuit()] - 1))
            {
                return "y";
            }
            else if (card.getValue() == (max[card.getSuit()] + 1))
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
        public void removeCardFromHand()
        {

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
        void timer_Tick(object sender, EventArgs e)
        {

        }
        public void saveBoard()
        {

        }
    }
}
