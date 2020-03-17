using System;
using System.IO;
using System.Collections.Generic;

namespace Sevens
{
    class Game
    {
        private List<int> leaderboard;
        private int[] playerScores;
        private int numberOfRounds;
        private int difficulty;
        private Board board;
        private String externalTextFile = @"D:\gameState.txt";
        private int roundsPlayed;

        public Game()
        {

        }

        public Game(int roundsInput, int difficultyInput)
        {
            leaderboard = new List<int>();
            numberOfRounds = roundsInput; //input comes from GUI, where 0 is first option
            difficulty = difficultyInput;
            playerScores = new int[] { 0, 0, 0, 0 };
            roundsPlayed = 0;
        }

        public Board startGame()
        {
            board = new Board(getDifficulty());

            Deck deck = new Deck();
            deck.Shuffle();

            while (!deck.isEmpty())
            {
                board.getQueue().getNextPlayer().addToHand(deck.getNextCard());
                //loops through players, in order to add a card to each player in the queue's hands in turn

            }

            return board;
        }
        public Board firstMove() //repetition between here and play, combine into one method
        {
            board.sevenOfDiamonds();
            return board;
        }
        public Board nextMove() //gets the move from the next player in the queue, and adds it to the board (if possible)
        {
            int playerFinished = board.getQueue().playerFinished();

            if (playerFinished != -1) {
                leaderboard.Add(playerFinished);
            }
            Card cardToBePlayed = board.getQueue().getNextPlayer().retrieveCardToBePlayed(board);

            if (board.validMove(cardToBePlayed).Equals("y"))
            {
                board.Add(board.getQueue().getCurrentPlayer().Move());
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

        public Board humanPlay(String indexOfCard)
        {
            Card cardToBePlayed = board.getQueue().getHumanPlayer().getCards()[(Convert.ToInt32(indexOfCard))];

            if (board.validMove(cardToBePlayed) == "y")
            {
                board.Add(cardToBePlayed);
                board.getQueue().getHumanPlayer().removeCard(cardToBePlayed);
                return board;
            }
            else if (board.validMove(cardToBePlayed) == "n")
            {
                return null;
            }
            else
            {
                return board;
            }

        }

        public String isOver()
        {
            if (board.checkEnd())
            {
                updatePlayerScores();
                return "Game over";
            }
            else if (board.getQueue().getHumanPlayer().handEmpty())
            {
                    updatePlayerScores("h");
                    return "Human wins";
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

        public void Pause(int whereToSave) //saves game state to external text file ( at position specified by the 
        {
            String[] text = new String[5];
            text = File.ReadAllLines(externalTextFile); //HERE
            text[whereToSave - 1] = getNumberOfRounds().ToString() + getDifficulty().ToString() + board.toBeSaved();
            File.WriteAllLines(@"D:\Gamestate.txt", text);
        }
    

        public void loadPrevious(int whichGame) //reads in game state from a previous game from textfile and sets up a new game to have all the values and states of the previous game
        {
            whichGame = 0; 

            String[] text;


            if (File.Exists(externalTextFile))
            {               
                text = File.ReadAllLines(externalTextFile);
                setRounds(Int32.Parse(text[whichGame].Substring(0, 1)));
                setDifficulty(Int32.Parse(text[whichGame].Substring(1, 1)));
                board = new Board(getDifficulty());

                text[whichGame] = text[whichGame].Remove(0, 2);
                String[] minsAndMaxes = new String[8];
                minsAndMaxes = text[whichGame].Split('/');
                Array.Resize(ref minsAndMaxes, 8);

                String[] maxes = new String[8];
                minsAndMaxes.CopyTo(maxes, 0);
                Array.Resize(ref minsAndMaxes, 4);
                Array.Reverse(maxes);
                Array.Resize(ref maxes, 4);
                board.setMin(Array.ConvertAll(minsAndMaxes, element => Int32.Parse(element)));
                board.setMax(Array.ConvertAll(maxes, element => Int32.Parse(element)));

                String[] playerCards = text[whichGame].Split('~');

                int counter = 8; //skip first 8

                for (int i = 0; i < board.getNUMBEROFPLAYERS(); i++)
                {
                    String[] cardString = playerCards[i].Split('/');

                    while (counter < (cardString.Length - 1)) //-1 as final card is invalid, just created due to final /
                    {
                        board.getQueue().getPlayerAt(i).addToHand(new Card(Int32.Parse(cardString[counter].Substring(1)), cardString[counter].Substring(0,1)));
                        counter++;
                    }
                    counter = 0;
                }

                board.getQueue().setCurrentPlayerIndex(Int32.Parse(playerCards[4]));
                String[] temp = new String[4];
                temp = playerCards[5].Split('/');
                Array.Resize(ref temp, 4);
                board.setSevens(Array.ConvertAll(temp, element => bool.Parse(element)));
                temp = playerCards[6].Split('/');
                Array.Resize(ref temp, 4);
                board.setAces(Array.ConvertAll(temp, element => bool.Parse(element)));
            }
        }
        public void updatePlayerScores(String s)
        {
            for (int i = 0; i < leaderboard.Count; i++)
            {
                int whichPlayer = leaderboard[i];

                if (i == 0)
                {
                    incrementPlayerScore(whichPlayer, 5);
                }
                else if (i == 1)
                {
                    incrementPlayerScore(whichPlayer, 3);
                }
                else if (i == 2)
                {
                    incrementPlayerScore(whichPlayer, 1);
                }

            }
            //for remaining players not on leaderboard

             int[] sizeOfHands = new int[4];
             sizeOfHands  = board.getSizeOfPlayersHands();   
            
            //CODE HERE TO ASSIGN POINTS VALUES APPROPRIATELY
        }
        public void updatePlayerScores()
        {
            for (int i = 0; i < 4; i++)
            {
                int position = leaderboard.IndexOf(i);

                if (position == 0)
                {
                    incrementPlayerScore(i, 5);
                }
                else if (position == 1)
                {
                    incrementPlayerScore(i, 3);
                }
                else if (position == 2)
                {
                    incrementPlayerScore(i, 1);
                }

            }
        }

        public void setDifficulty(int input)
        {
            difficulty = input;
        }
        public void setRounds(int input)
        {
            numberOfRounds = input;
        }

        public void setRoundsPlayed(int input)
        {
            roundsPlayed = input;
        }

        public void incrementPlayerScore(int index, int input)
        {
            playerScores[index] = playerScores[index] + input;
        }
        public List<int> getLeaderboard()
        {
            return leaderboard;
        }
        public Board getBoard()
        {
            return board;
        }

        public int getDifficulty()
        {
            return difficulty;
        }

        public int getNumberOfRounds()
        {
            return numberOfRounds;
        }

        public int getRoundsPlayed()
        {
            return roundsPlayed;
        }

        public int[] getPlayerScores()
        {
            return playerScores;
        }
        public Boolean fileExists()
        {
            if (File.Exists(externalTextFile)){
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
