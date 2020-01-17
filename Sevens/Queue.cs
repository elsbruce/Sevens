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
        private int head = 0;
        private int tail = 0;
        private int currentplayer = 0;

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

        }

        public Player getNextPlayer()
        {
            currentplayer = (currentplayer + 1) % 4;
            return players[currentplayer];
        }
        
        public Player getCurrentPlayer()
        {
            return players[currentplayer];
        }

        public Player getHumanPlayer(){
            return players[0];
        }
        
        public void findSeven() //identifies which player has the seven of diamonds, and sets current player to the player before
        {
            currentplayer = 0;
            while ((this.players[currentplayer].CheckSevenDiamonds()) != true)
            {
                currentplayer++;
            }
        }

        public Boolean isEmpty() //returns true if no players remain in queue
        {
            return false;
        }
    }
}
