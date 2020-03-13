using System;
using System.IO;
using System.Collections.Generic;

namespace Sevens
{
    class Game
    {
        private List<int> leaderboard;
        private int numberOfRounds;
        private int difficulty;
        private Board board;
        private String externalTextFile = @"D:\gameState.txt";

        public Game()
        {

        }

        public Game(int roundsInput, int difficultyInput)
        {
            leaderboard = new List<int>();
            numberOfRounds = roundsInput; //input comes from GUI, where 0 is first option
            difficulty = difficultyInput;
            board = new Board(difficultyInput);
        }

        public Board startGame()
        {
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
            else
            {
                return null;
            }

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

        public void Pause(int whereToSave) //saves game state to external text file ( at position specified by the 
        {

            FileStream fout;
            int size = 100;
            BinaryWriter bw;

            //create a file stream object

            fout = new FileStream(@"D:\GAMESTATE.bin", FileMode.OpenOrCreate, FileAccess.Write);

            //create a binary writer object
            bw = new BinaryWriter(fout);

            //set file position where to write data
            fout.Position = whereToSave * size;
            //write data
            bw.Write(getNumberOfRounds().ToString() + getDifficulty().ToString() + board.toBeSaved());
            bw.Flush();
            //write data

            bw.Close();
            fout.Close();

        }


        public void loadPrevious(int whichGame) //reads in game state from a previous game from textfile and sets up a new game to have all the values and states of the previous game
        {
            int size = 100;
            FileStream fn;
            BinaryReader binaryReader;
            fn = new FileStream(@"D:\GAMESTATE.bin", FileMode.Open, FileAccess.Read);
            binaryReader = new BinaryReader(fn);

            fn.Seek(whichGame * size, 0);
            String t = binaryReader.ReadString();
            String[] text;


            if (File.Exists(externalTextFile))
            {
              // using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
                
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

        public void setDifficulty(int input)
        {
            difficulty = input;
        }
        public void setRounds(int input)
        {
            numberOfRounds = input;
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
