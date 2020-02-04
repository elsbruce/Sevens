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
            currentplayer = (currentplayer + 1) % tail;
            playerFinished();
            return players[currentplayer];
        }

        public Player getHumanPlayer(){
            return players[0];
        }
      
        public Boolean isEmpty() //returns true if all players are dummy players
        {
            for (int i = 0; i < 4; i++)
            {
                if (players[i] is DummyPlayer)
                {
                    return false;
                }
            }
            return true;
        }

        public void removePlayer(int positionOfPlayer)
        {
            tail = tail - 1;
        }

        public void playerFinished()
        {
            if (getCurrentPlayer().handEmpty())
            {
                players[getCurrentPlayerIndex()] = new DummyPlayer();
            }
        }

    }
}
