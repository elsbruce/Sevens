﻿using System;
using System.IO;
using System.Collections.Generic;

namespace Sevens
{
    class Game
    {
        private const int NUMBEROFPLAYERS = 4;

        private List<int> leaderboard;
        private int numberOfRounds;
        private int difficulty;
        private Board board;

        public Game(int rounds, int difficultyInput)
        {
            leaderboard = new List<int>();
            numberOfRounds = rounds;
            difficulty = difficultyInput;
            board = new Board(difficultyInput);

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
        public Board nextMove()
        {
            int playerFinished = board.getQueue().playerFinished();

            if (playerFinished != -1) {
                leaderboard.Add(playerFinished);
            }
            Card cardToBePlayed = board.getQueue().getNextPlayer().getCardToBePlayed(board);

            return Turn(cardToBePlayed);
        }

        public Board Turn(Card cardToBePlayed)
        {
            if (board.validMove(cardToBePlayed).Equals("y"))
            {
                board.Add(board.getQueue().getCurrentPlayer().Move(board));
                return board;
            }
            else if (board.validMove(cardToBePlayed).Equals("n"))
            {

                return board;
            }
            else
            {
                return null;
            }
        }

        public Board currentMove()
        {
            Card cardToBePlayed = board.getQueue().getCurrentPlayer().getCardToBePlayed(board);

            return Turn(cardToBePlayed);
        }

        public Board humanPlay(String indexOfCard)
        {
            Card cardToBePlayed = board.getQueue().getHumanPlayer().getCardAt(Convert.ToInt32(indexOfCard));

            if (board.validMove(cardToBePlayed) == "y")
            {
                board.Add(cardToBePlayed);
                board.getQueue().getHumanPlayer().removeCard(cardToBePlayed);
                return board;
            }
            else
            {
                return null;
            }

        }

        public Board getBoard()
        {
            return board;
        }

        public String isOver()
        {
            if (board.getQueue().getHumanPlayer().handEmpty())
            {
                return "Human wins";
            }
            else if (board.checkEnd())
            {
                return "Game over";
            }
            else
            {
                return "N";
            }
        }

        public string convertToSuit(int suit) 
        {
            if (suit == 0)
            {
                return "D";
            }
            else if (suit == 1)
            {
                return "H";
            }
            else if (suit == 2)
            {
                return "C";
            }
            else
            {
                return "S";
            }
        }

        public void Pause()
        {
            string pathToFile = @"D:\gameState.txt";

            using (StreamWriter streamWrite = File.CreateText(pathToFile))
            {
                streamWrite.WriteLine(board.toBeSaved());
            }
        }

        public List<int> getLeaderboard()
        {
            return leaderboard;
        }

        //public int humanPlayerPosition()
        //{

        //}
    }
}
