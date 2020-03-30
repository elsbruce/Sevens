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
        private String externalTextFile = @"C:\Users\elsb2\OneDrive\Documents\A-Level 1\gameState.txt";
        private int roundsPlayed;

        public Game()
        {
            leaderboard = new List<int>();
            playerScores = new int[] { 0, 0, 0, 0 };
        }

        public Game(int roundsInput, int difficultyInput)
        {
            leaderboard = new List<int>();
            numberOfRounds = roundsInput; //input comes from GUI, where 0 is first option
            difficulty = difficultyInput;
            playerScores = new int[] { 0, 0, 0, 0 };
            roundsPlayed = 0;
        }

        public Board StartGame() //creates new board, shuffles and deals cards
        {
            board = new Board(GetDifficulty());

            Deck deck = new Deck();
            deck.Shuffle();

            while (!deck.IsEmpty())
            {
                board.getQueue().GetNextPlayer().AddToHand(deck.GetNextCard());
                //loops through players, in order to add a card to each player in the queue's hands in turn

            }

            return board;
        }
        public Board FirstMove() //plays seven of diamonds
        {
            board.sevenOfDiamonds();
            return board;
        }
        public Board NextMove() //gets the move from the next player in the queue, and adds it to the board (if possible)
        {
            int playerFinished = board.getQueue().PlayerFinished();

            if (playerFinished != -1)
            {
                leaderboard.Add(playerFinished);
            }
            Card cardToBePlayed = board.getQueue().GetNextPlayer().RetrieveCardToBePlayed(board);

            if (board.validMove(cardToBePlayed).Equals("y"))
            {
                board.Add(board.getQueue().GetCurrentPlayer().Move());
                return board;
            }
            else if (board.validMove(cardToBePlayed).Equals("n"))
            {
                AssignPassToken(board.getQueue().GetCurrentPlayerIndex());
                return board;
            }
            else
            {
                return null;
            }
        }

        public Board HumanPlay(String indexOfCard) //parsed the position of the card to be played in the player's hand, then adds the card to board if it is valid, 
        {
            Card cardToBePlayed = board.getQueue().GetHumanPlayer().GetCards()[(Convert.ToInt32(indexOfCard))];

            if (board.validMove(cardToBePlayed) == "y")
            {
                board.Add(cardToBePlayed);
                board.getQueue().GetHumanPlayer().RemoveCard(cardToBePlayed);
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

        public String IsOver() //checks whether board has all cards added to it, and whether the human player has no cards
        {
            if (board.checkEnd())
            {
                UpdatePlayerScores();
                return "Game over";
            }
            else if (board.getQueue().GetHumanPlayer().HandEmpty())
            {
                UpdatePlayerScores("h");
                return "Human wins";
            }
            else
            {
                return "N";
            }
        }

        public string ConvertToSuit(int suit) //takes an integer (from 0 to 3) converts from a number to its string equivalent
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

        public void Pause(int whereToSave) //saves game state to external text file (at line specified by the int parsed to the method)
        {
            String[] text = new String[5];
            text = File.ReadAllLines(externalTextFile); 
            text[whereToSave - 1] = GetNumberOfRounds().ToString() + GetDifficulty().ToString() + board.toBeSaved() + GetLeaderboard().Count.ToString() + string.Join(", ", GetLeaderboard());
            File.WriteAllLines(externalTextFile, text);
        }


        public void LoadPrevious(int whichGame) //reads in game state from a previous game from textfile and sets up a new game to have all the values and states of the previous game
        {
            String[] text;


            if (File.Exists(externalTextFile))
            {
                text = File.ReadAllLines(externalTextFile);


                SetRounds(Int32.Parse(text[whichGame].Substring(0, 1)));
                SetDifficulty(Int32.Parse(text[whichGame].Substring(1, 1)));
                board = new Board(GetDifficulty());

                text[whichGame] = text[whichGame].Remove(0, 2);
                String[] minsAndMaxes = new String[8];
                minsAndMaxes = text[whichGame].Split('/');
                Array.Resize(ref minsAndMaxes, 8);

                String[] maxes = new String[8];
                minsAndMaxes.CopyTo(maxes, 0);
                Array.Resize(ref minsAndMaxes, 4);
                Array.Reverse(maxes);
                Array.Resize(ref maxes, 4);
                Array.Reverse(maxes);
                board.setMin(Array.ConvertAll(minsAndMaxes, element => Int32.Parse(element)));
                board.setMax(Array.ConvertAll(maxes, element => Int32.Parse(element)));

                String[] playerCards = text[whichGame].Split('~');

                int counter = 8; //skip first 8

                for (int i = 0; i < board.getNUMBEROFPLAYERS(); i++)
                {
                    String[] cardString = playerCards[i].Split('/');

                    while (counter < (cardString.Length - 1)) //-1 as final card is invalid, just created due to final /
                    {
                        board.getQueue().GetPlayerAt(i).AddToHand(new Card(Int32.Parse(cardString[counter].Substring(1)), cardString[counter].Substring(0, 1)));
                        counter++;
                    }
                    counter = 0;
                }

                board.getQueue().SetCurrentPlayerIndex(Int32.Parse(playerCards[4]));
                String[] temp = new String[4];
                temp = playerCards[5].Split('/');
                Array.Resize(ref temp, 4);
                board.setSevens(Array.ConvertAll(temp, element => bool.Parse(element)));
                temp = playerCards[6].Split('/');
                Array.Resize(ref temp, 4);
                board.setAces(Array.ConvertAll(temp, element => bool.Parse(element)));
            }
        }
        public void UpdatePlayerScores(String s) //takes a string, such that the method is specific for human player, 
        {
            for (int i = 0; i < leaderboard.Count; i++)
            {
                int whichPlayer = leaderboard[i];

                if (i == 0)
                {
                    IncrementPlayerScore(whichPlayer, 5);
                }
                else if (i == 1)
                {
                    IncrementPlayerScore(whichPlayer, 3);
                }
                else if (i == 2)
                {
                    IncrementPlayerScore(whichPlayer, 1);
                }

            }
            //for remaining players not on leaderboard

            int[] sizeOfHands = new int[4];
            sizeOfHands = board.getSizeOfPlayersHands();

            //CODE HERE TO ASSIGN POINTS VALUES APPROPRIATELY
        }
        public void UpdatePlayerScores()
        {
            for (int i = 0; i < 4; i++)
            {
                int position = leaderboard.IndexOf(i);

                if (position == 0)
                {
                    IncrementPlayerScore(i, 5);
                }
                else if (position == 1)
                {
                    IncrementPlayerScore(i, 3);
                }
                else if (position == 2)
                {
                    IncrementPlayerScore(i, 1);
                }

            }
        }

        public void AssignPassToken(int toWhichPlayer)
        {
            int whoHasPassToken = board.getQueue().WhoHasPassToken();
            if (whoHasPassToken != -1)
            {
                board.getQueue().GetPlayerAt(whoHasPassToken).SetPassToken(false);
            }

            board.getQueue().GetPlayerAt(toWhichPlayer).SetPassToken(true);
        }



        public void IncrementPlayerScore(int index, int input)
        {
            playerScores[index] = playerScores[index] + input;
        }
        public Boolean FileExists()
        {
            return (File.Exists(externalTextFile));
           
        }
        public void SetDifficulty(int input)
        {
            difficulty = input;
        }
        public void SetRounds(int input)
        {
            numberOfRounds = input;
        }

        public void SetRoundsPlayed(int input)
        {
            roundsPlayed = input;
        }
        public List<int> GetLeaderboard()
        {
            return leaderboard;
        }
        public Board GetBoard()
        {
            return board;
        }

        public int GetDifficulty()
        {
            return difficulty;
        }

        public int GetNumberOfRounds()
        {
            return numberOfRounds;
        }

        public int GetRoundsPlayed()
        {
            return roundsPlayed;
        }

        public int[] GetPlayerScores()
        {
            return playerScores;
        }

    }
}
