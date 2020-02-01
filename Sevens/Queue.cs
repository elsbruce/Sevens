using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class Queue
    {
        private Player[] players;
        private int head; //why have head and tail?
        private int tail;
        private int currentplayer;

        public Queue()
        {

            players = new Player[4];
            players[0] = new HumanPlayer(); //human player
            for (int x = 1; x < 4; x++)
            {
                players[x] = new AIPlayer(); //add 3 AI players
            }
            head = 0;
            tail = 4;
            currentplayer = 0;

        }

        public Player[] getQueue()
        {
            return players;
        }

        public Player getCurrentPlayer()
        {
            return players[currentplayer];
        }

        public int getCurrentPlayerIndex()
        {
            return currentplayer;
        }
        
        public Player getNextPlayer()
        {
      //      int temp = currentplayer;
            currentplayer = (currentplayer + 1) % tail;
            return players[currentplayer];
        }

        public Player getHumanPlayer(){
            return players[0];
        }
      
        public Boolean isEmpty() //returns true if no players remain in queue
        {
            return false;
        }

        public void removePlayer(int positionOfPlayer)
        {
            tail = tail - 1;
        }
    }
}
