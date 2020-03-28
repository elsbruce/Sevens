using System;

namespace Sevens
{
    class Queue
    {
        private Player[] players;
        private int currentplayer;
        public const int SIZEOFQUEUE = 4;

        //difficulty input - integer - stores the difficulty that the AI players are to be
        //creates an array of players with the size of the constant "SIZEOFQUEUE", sets the first player in the array to be the human player, and creates the remaining players as AI players according to the difficulty input
        public Queue(int difficultyInput)
        {

            players = new Player[SIZEOFQUEUE];
            players[0] = new HumanPlayer(); //human player

            if (difficultyInput == 0)
            {
                for (int x = 1; x < SIZEOFQUEUE; x++)
                {
                    players[x] = new EasyPlayer(); //add 3 Easy AI players
                }
            }
            else if (difficultyInput == 1)
            {
                for (int x = 1; x < SIZEOFQUEUE; x++)
                {
                    players[x] = new MediumPlayer(); //add 3 Medium AI players
                }
            }
            else
            {
                for (int x = 1; x < SIZEOFQUEUE; x++)
                {
                    players[x] = new DifficultPlayer(); //add 3 Difficult AI players
                }
            }

            SetCurrentPlayerIndex(0);
        }


        //returns Player at current player index
        public Player GetCurrentPlayer()
        {
            return GetPlayerAt(GetCurrentPlayerIndex());
        }


        //increments currentPlayerIndex to the next Player in the circular queue, by adding one and calculating the modulus of this with the SIZEOFQUEUE constant integer
        //returns the player at the currentPlayerIndex
        public Player GetNextPlayer()
        {
            SetCurrentPlayerIndex((GetCurrentPlayerIndex() + 1) % SIZEOFQUEUE);

            return GetCurrentPlayer();
        }

        //returns the player at position 0, as this player is always the humanPlayer
        public Player GetHumanPlayer()
        {
            return GetPlayerAt(0);
        }

        //sets current player index to index - 1, but if current player index equals 0 then the current player index goes to the back of the queue (the size of the queue minus one)
        public void CurrentPlayerMinusOne()
        {
            if (GetCurrentPlayerIndex() == 0)
            {
                SetCurrentPlayerIndex(SIZEOFQUEUE - 1);
            }
            else
            {
                SetCurrentPlayerIndex(currentplayer - 1);
            }
        }

        //loops through each of the players in the queue, and if any of the players are not a dummy then returns false
        //if all players are looped through without returning anything, then all players are dummys
        //returns a Boolean, which is true if all players are dummys
        public Boolean AllPlayersAreDummy()
        {
            for (int i = 0; i < SIZEOFQUEUE; i++)
            {
                if (!(players[i] is DummyPlayer))
                {
                    return false;
                }
            }
            return true;
        }

        //calls handEmpty on the current player, if it returns true then this player's position in the queue is replaced by a dummy player
        //if handEmpty returned true, the position of the current player in the queue is returned as an integer, else -1 is returned
        public int PlayerFinished()
        {
            if (GetCurrentPlayer().handEmpty())
            {
                players[GetCurrentPlayerIndex()] = new DummyPlayer();
                Card impossibleCard = new Card(7, 0);
                players[GetCurrentPlayerIndex()].addToHand(impossibleCard);
                return GetCurrentPlayerIndex();
            }

            return -1;
        }

        //loops through each of the players, and calls getPassToken on each player
        //returns an integer of the index of the player with the pass token, if a player has the pass token, else returns -1
        public int WhoHasPassToken()
        {
            for (int i = 0; i < SIZEOFQUEUE; i++)
            {
                if (GetPlayerAt(i).getPassToken() == true)
                {
                    return i;
                }
            }
            return -1;
        }

        public Player[] GetQueue()
        {
            return players;
        }

        public void SetCurrentPlayerIndex(int input)
        {
            currentplayer = input;
        }

        public int GetCurrentPlayerIndex()
        {
            return currentplayer;
        }

        public Player GetPlayerAt(int position)
        {
            return players[position];
        }
    }
}
