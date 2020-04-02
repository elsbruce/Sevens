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
        private const int NUMBEROFPLAYERS = 4;

        // diamonds 0, hearts 1, clubs 2, spades 3

        public Board(int difficultyInput)
        {
            min = new int[] { 7, 7, 7, 7 }; //initialise all mins to 7
            max = new int[] { 7, 7, 7, 7 }; //initialise all maxs to 7
            sevens = new bool[] { false, false, false, false };
            aces = new bool[] { false, false, false, false };
            queue = new Queue(difficultyInput);
        }



        public int[] GetSizeOfPlayersHands()
        {
            int[] sizeOfPlayersHands = new int[NUMBEROFPLAYERS];

            for (int i = 0; i < NUMBEROFPLAYERS; i++)
            {
                sizeOfPlayersHands[i] = queue.GetQueue()[i].GetCurrentSize();
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


        public String ValidMove(Card card)
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
        public void SevenOfDiamonds()
        {
            Boolean sevenFound;
            do
            {
                sevenFound = queue.GetNextPlayer().CheckSevenDiamonds();
            } while (!sevenFound); 

            sevens[0] = true;
        }

        public Boolean CheckEnd()
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

        public String ToBeSaved()
        {
            String board = "";

            for (int i = 0; i < 4; i++)
            {
                board = board + min[i].ToString() + "/";
            }
            for (int i = 0; i < 4; i++)
            {
                board = board + max[i].ToString() + "/";
            }
            foreach (Player p in GetQueue().GetQueue()) //if dummyplayers
            {
                foreach (String s in p.GetStringArrayOfCards())
                {

                    board = board + s + "/";
                }

                board = board + "~";
            }

            board = board + GetQueue().GetCurrentPlayerIndex().ToString() + "~";

            for (int i = 0; i < 4; i++)
            {
                board = board + GetSevens()[i].ToString() + "/";
            }

            board = board + "~";
            for (int i = 0; i < 4; i++)
            {
                board = board + GetAces()[i].ToString() + "/";
            }
            return board;
        }
        public Queue GetQueue()
        {
            return queue;
        }
        public int[] GetMin()
        {
            return min;
        }

        public int[] GetMax()
        {
            return max;
        }


        public Boolean[] GetSevens()
        {
            return sevens;
        }

        public int GetNUMBEROFPLAYERS()
        {
            return NUMBEROFPLAYERS;
        }

        public Boolean[] GetAces()
        {
            return aces;
        }

        public void SetMin(int[] input)
        {
            this.min = input;
        }
        public void SetMax(int[] input)
        {
            this.max = input;
        }
        public void SetSevens(Boolean[] input)
        {
            this.sevens = input;
        }
        public void SetAces(Boolean[] input)
        {
            this.aces = input;
        }
        public void SetQueue(Player[] input) //do
        {
            for (int i = 0; i < NUMBEROFPLAYERS; i++)
            {

            }
        }

        public Boolean SuitComplete(int whichSuit)
        {
            if ((GetMin()[whichSuit] == 2) && (GetMax()[whichSuit] == 13) && (GetAces()[whichSuit] == true)){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}