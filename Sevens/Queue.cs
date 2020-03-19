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
      //  private int head; //why have head and tail?
     //   private int tail;
        private int currentplayer;
        public int sizeOfQueue;

        public Queue(int difficultyInput)
        {
            sizeOfQueue = 4;

            players = new Player[sizeOfQueue];
            players[0] = new HumanPlayer(); //human player

            if (difficultyInput == 0)
            {
                for (int x = 1; x < sizeOfQueue; x++)
                {
                    players[x] = new EasyPlayer(); //add 3 Easy AI players
                }
            }
            else if (difficultyInput == 1)
            {
                for (int x = 1; x < sizeOfQueue; x++)
                {
                    players[x] = new MediumPlayer(); //add 3 Medium AI players
                }
            }
            else
            {
                for (int x = 1; x < sizeOfQueue; x++)
                {
                    players[x] = new DifficultPlayer(); //add 3 Difficult AI players
                }
            }

          //  head = 0;
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
            currentplayer = (currentplayer + 1) % sizeOfQueue;
            
            return players[currentplayer];
        }

        public Player getHumanPlayer(){
            return getPlayerAt(0);
        }

        public Player getPlayerAt(int position)
        {
            return players[position];
        }

        public void currentPlayerMinusOne()
        {
            if (currentplayer == 0)
            {
                setCurrentPlayerIndex(sizeOfQueue - 1);
            }
            else
            {
                setCurrentPlayerIndex(currentplayer - 1);
            }
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


        public int playerFinished() //replaces current player with a dummy player within the queue
        {
            if (getCurrentPlayer().handEmpty())
            {
                players[getCurrentPlayerIndex()] = new DummyPlayer();
                Card bodge = new Card(7,0);
                players[getCurrentPlayerIndex()].addToHand(bodge);
                return getCurrentPlayerIndex();
            }

            return -1;
        }


        public void setCurrentPlayerIndex(int input)
        {
            currentplayer = input;
        }

        public int whoHasPassToken() //returns the index of the player with the pass token, unless no one has the pass token, then returns -1
        {
            for (int i = 0; i < sizeOfQueue; i++)
            {
                if (getPlayerAt(i).getPassToken() == true)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
