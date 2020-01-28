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

        private Player[] leaderboard;
        private int numberOfRounds;
        private int difficulty;
        private Board board;
        private int THISISHORRIFICDESIGNCHANGELATER;

        public Game(int rounds, int difficultyInput)
        {
            leaderboard = new Player[NUMBEROFPLAYERS];
            numberOfRounds = rounds;
            difficulty = difficultyInput;
            board = new Board();
            THISISHORRIFICDESIGNCHANGELATER = 0;

        }

      public Board startGame() //deals all cards (is this method needed??)
        {
            Deal();
            return board;
        }

        public void Deal()
        {
            Deck deck = new Deck();
            deck.Shuffle();
 
            while (!deck.isEmpty())
            {
                    board.getQueue().getNextPlayer().addToHand(deck.getNextCard());
                   //loops through players, in order to add a card to each player in the queue's hands in turn
                
            }
        }
        public Board firstMove() //repetition between here and play, combine into one method
        {
            board.sevenOfDiamonds(); //move find seven method into board
            return board;
        }
        public Board Play()
        {
            Card cardToBePlayed = board.getQueue().getNextPlayer().getCardToBePlayed();

            if (board.validMove(cardToBePlayed).Equals("y")) {
                board.Add(board.getQueue().getCurrentPlayer().Move());
                return board;
            }
            else  if (board.validMove(cardToBePlayed).Equals("n"))
            {
                return board;
            }
            else
            {
                return null;
            }
        }

        public Board humanPlay(String indexOfCard) //shouldn't need this i
        {
            board.Add(board.getQueue().getHumanPlayer().getCardAt(Convert.ToInt32(indexOfCard)));
            return board;
        }

        public Boolean isOver()
        {
            THISISHORRIFICDESIGNCHANGELATER++;

            if (THISISHORRIFICDESIGNCHANGELATER < 1000)
            {
                return false;
            }
            else
            {
                return true;
            }

            //if (!(board.getQueue().isEmpty())) //currently infinite loop
            //{
            //    return false;
            //}
            //else
            //{
            //    return true;
            //}
        }

        public Board getBoard()
        {
            return board;
        }
    }
}
