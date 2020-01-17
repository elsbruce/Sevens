using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class Game
    {
        private  const int NUMBEROFPLAYERS = 4;
        private Queue queue;
        private Player[] leaderboard;
        private int numberOfRounds;
        private int difficulty;
        private Board board;

        public Game(int rounds, int difficultyInput)
        {
            leaderboard = new Player[NUMBEROFPLAYERS];
            numberOfRounds = rounds;
            difficulty = difficultyInput;
            board = new Board();
            queue = new Queue();
        }

      public String[] startGame() //deals all cards and returns the users cards
        {
            Deal();
            return queue.getHumanPlayer().arrayOfCardsToArrayOfStrings(queue.getHumanPlayer().getCards());//player's hand
        }

        public void Deal()
        {
            Deck deck = new Deck();
            deck.Shuffle();
 
            while (!deck.isEmpty())
            {
                    queue.getNextPlayer().addToHand(deck.getNextCard());
                   //loops through players, in order to add a card to each player in the queue's hands in turn
                
            }
        }
        public Board firstMove()
        {
            queue.findSeven();
            board.Add(queue.getCurrentPlayer().Move());
            return board;
        }
        public Board Play()
        {
            board.Add(queue.getNextPlayer().Move());
            return board;
        }
    }
}
