using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sevens
{
    class Game
    {
        private const int NUMBEROFPLAYERS = 4;

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
            board.sevenOfDiamonds();
            return board;
        }
        public Board Play()
        {
            Card cardToBePlayed = board.getQueue().getNextPlayer().getCardToBePlayed(board);

            if (board.validMove(cardToBePlayed).Equals("y")) {
                board.Add(board.getQueue().getCurrentPlayer().Move(board));
                return board;
            }
            else if (board.validMove(cardToBePlayed).Equals("n"))
            {
             //   board.Add(board.getQueue().getCurrentPlayer().Move()); //delete this
                return board;
            }
            else
            {
                return null;
            }
        }

        public Board humanPlay(String indexOfCard)
        {
            board.Add(board.getQueue().getHumanPlayer().getCardAt(Convert.ToInt32(indexOfCard)));
            return board;
        }

        public Board getBoard()
        {
            return board;
        }

        public Boolean isOver()
        {
            return board.checkEnd();
        }
    }
}
