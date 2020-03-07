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
        private const int numberOfPlayers = 4;

        // diamonds 0, hearts 1, clubs 2, spades 3

        public Board(int difficultyInput)
        {
            min = new int[] { 7, 7, 7, 7 }; //initialise all mins to 7
            max = new int[] { 7, 7, 7, 7 }; //initialise all maxs to 7
            sevens = new bool[] { false, false, false, false };
            aces = new bool[] { false, false, false, false };
            queue = new Queue(difficultyInput);
        }



        public int[] getSizeOfPlayersHands()
        {
            int[] sizeOfPlayersHands = new int[numberOfPlayers];

            for (int i = 0; i < numberOfPlayers; i++)
            {
                sizeOfPlayersHands[i] = queue.getQueue()[i].getCurrentSize();
            }

            return sizeOfPlayersHands;
        }


        public void Add(Card card)
        {
            if (card.getValue() == 7)
            {
                sevens[card.getSuit()] = true;
            }
            else if ((card.getValue() == 14) && ((min[card.getSuit()] == 2) || (max[card.getSuit()] == 13))) //??????
            {
                aces[card.getSuit()] = true;
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
            else if ((card.getValue() == 14) && (min[card.getSuit()] == 2))
            { //if aces is to be played low
                return "y";
            }
            else
            {
                return "n";
            }

        }
        public void sevenOfDiamonds()
        {
            Boolean sevenFound;
            do
            {
                sevenFound = queue.getNextPlayer().CheckSevenDiamonds();
            } while (!sevenFound); 

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

        public String toBeSaved()
        {
            String board = "";

            for (int i = 0; i < 4; i++)
            {
                board = board + min[i].ToString() + max[i].ToString() + "//";
            }

            foreach (Player p in getQueue().getQueue()) //if dummyplayers
            {
                foreach (String s in p.getStringArrayOfCards())
                {

                    board = board + s + "/";
                }

                board = board + "<>";
            }

            board = board + getQueue().getCurrentPlayerIndex().ToString();

            return board;
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


        public Boolean[] getSevens()
        {
            return sevens;
        }

        public Boolean[] getAces()
        {
            return aces;
        }

        public void setMin(int[] input)
        {
            this.min = input;
        }
        public void setMax(int[] input)
        {
            this.max = input;
        }
        public void setSevens(Boolean[] input)
        {
            this.sevens = input;
        }
        public void setAces(Boolean[] input)
        {
            this.aces = input;
        }
        public void setQueue(Player[] input) //do
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {

            }
        }
    }
}