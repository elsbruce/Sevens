﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
namespace Sevens
{
    public partial class Gameplay : Form
    {
        PictureBox[,] c = new PictureBox[4, 14];
        Button[] playerHand = new Button[13];
        Label[] otherPlayers = new Label[3];
        Game sevens;

        public Gameplay(int numberOfRounds, int difficulty)
        {
            sevens = new Game(numberOfRounds, difficulty);
            InitializeComponent();

            setUp(sevens.startGame());

            update(sevens.firstMove());

            displayPlayersHand();

            PlayGame();
        }

        private void PlayGame()
        {
            if (sevens.isOver() == "N")
            {

                Board b;
                b = sevens.nextMove();


                while (!this.Turn(b))
                {

                    b = sevens.nextMove();
                }
            }
            else {
                MessageBox.Show(sevens.isOver());
            }
        }

        private Boolean Turn(Board b)
        {
       
            if (b == null)
            {
                // if returns null then switch buttons on
                for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
                {
                    playerHand[cardNumber].Enabled = true;
                    playerHand[cardNumber].Click += playerHand_Click;
                }

                skipTurnButton.Enabled = true;
                //get move
                //then disable buttons
                return true;
            }
            else
            {
                displayAITurn(); //goes to this when current player index = 0
                update(b);
                return false;
            }
        }

        private void playerHand_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            //String moveIsValid = sevens.getBoard().validMove(sevens.getBoard().getQueue().getHumanPlayer().getCardAt(Convert.ToInt32(s.Name)));
            ////if move is valid then card button is hidden and card is added to board
            //if (moveIsValid.Equals("y"))
            //{
            //    for (int i = 0; i < 13; i++)
            //    {
            //        tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
            //    }

            //    update(sevens.humanPlay(s.Name));
            //    displayPlayersHand();
            //    for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
            //    {
            //        playerHand[cardNumber].Enabled = false;
            //    }

            //    PlayGame();

            //}
            //else if ((moveIsValid.Equals("n")))
            //{
            //    MessageBox.Show("This is not a valid move");
            //}

            Board humanTurn = sevens.humanPlay(s.Name);
            if (humanTurn == null)
            {
                MessageBox.Show("This is not a valid move.");
            }
            else
            {
                update(humanTurn);
                for (int i = 0; i < 13; i++)
                {
                    tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
                }
                displayPlayersHand();
                disablePlayerButtons();
                PlayGame();
            }


        }
        private void update(Board board)
        {
            //updates board
            for (int suit = 0; suit < 4; suit++)
            {
                if (board.getSevens()[suit] == true) //if the seven has been placed, then show other things
                {
                    cardPlaced(suit, board.getMin()[suit]);
                    cardPlaced(suit, board.getMax()[suit]);
                }
                if (board.getAces()[suit] == true)
                {
                    placeAce(suit);
                }
            }

            //updates size of other player's hands
            for (int playerNumber = 1; playerNumber < 4; playerNumber++) {
                otherPlayers[(playerNumber - 1)].Text = board.getSizeOfPlayersHands()[playerNumber].ToString(); ;
            }       
        }

        public void displayAITurn() //outlines the card of the player currently moving for a short amount of time
        {
            otherPlayers[(sevens.getBoard().getQueue().getCurrentPlayerIndex() - 1)].BorderStyle = BorderStyle.Fixed3D;

        }

        private void placeAce(int suit)
        {
            if (sevens.getBoard().getMin()[suit] == 2)
            {
                cardPlaced(suit, 1);

                if (sevens.getBoard().getMax()[suit] == 13)
                {
                    condenseSuit(suit);
                }
            }
            else if (sevens.getBoard().getMax()[suit] == 13)
            {
                cardPlaced(suit, 14);
            }
        }


        private void cardPlaced(int suitCounter, int valueCounter)
        {
            c[suitCounter, (valueCounter - 1)].Visible = true;
        }
        private void setUp(Board board)
        {
            //creates board of cards which are all hidden
            for (int suitCounter = 0; suitCounter < 4; suitCounter++)
            {
                for (int valueCounter = 1; valueCounter < 15; valueCounter++)
                {
                    PictureBox temp = new PictureBox();
                    temp.BackgroundImage = getImage("Sevens.images." + sevens.convertToSuit(suitCounter) + valueCounter.ToString() + ".jpg");         
                    temp.BackgroundImageLayout = ImageLayout.Zoom;
                    temp.Dock = DockStyle.Fill;
                    temp.Name = (sevens.convertToSuit(suitCounter) + valueCounter.ToString());
                    temp.Size = new Size(42, 68);
                    temp.Visible = false;
                    c[suitCounter, (valueCounter - 1)] = temp;
                    tablePanel.Controls.Add(temp, (valueCounter-1), suitCounter);
                }
            }

            //adds boxes for other players
            for (int playerNumber = 1; playerNumber < 4; playerNumber++)
            {
                Label temp = new Label();
                temp.BackgroundImage = getImage("Sevens.images.P" + playerNumber + ".jpg");
                temp.BackgroundImageLayout = ImageLayout.Zoom;
                temp.Dock = DockStyle.Fill;
                temp.Name = "Player" + playerNumber;
                temp.Size = new Size(42, 68);
                temp.Text = board.getSizeOfPlayersHands()[playerNumber].ToString();
                temp.Font = new Font(temp.Font, FontStyle.Bold);
                otherPlayers[(playerNumber - 1)] = temp;
                tablePanel.Controls.Add(temp, 15, (playerNumber-1));
            }
        }

        public void displayPlayersHand()
        {
            //displays user's hand
            for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
            {
                Button temp = new Button();
                temp.BackgroundImage = getImage("Sevens.images." + sevens.getBoard().getQueue().getHumanPlayer().getStringArrayOfCards()[cardNumber] + ".jpg");
                temp.BackgroundImageLayout = ImageLayout.Zoom;
                temp.Dock = DockStyle.Fill;
                temp.Name = cardNumber.ToString();
                temp.Size = new Size(42, 68);
                playerHand[cardNumber] = temp;
                tablePanel.Controls.Add(temp, cardNumber, 5);
            }
        }

        public TableLayoutPanel getTableLayoutPanel()
        {
            return tablePanel;
        }



        private void SkipTurn_Click(object sender, EventArgs e)
        {
            PlayGame();
        
        }

        private void TablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void condenseSuit(int suit)
        {
            for (int i = 0; i < 14; i++)
            {
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, suit));
            }

            Button suitComplete = new Button();
            suitComplete.BackgroundImage = getImage("Sevens.images." + sevens.convertToSuit(suit) + ".jpg");
            suitComplete.BackgroundImageLayout = ImageLayout.Zoom;
            suitComplete.Dock = DockStyle.Fill;
            suitComplete.Size = new Size(42, 68);
            tablePanel.Controls.Add(suitComplete, 7, suit);
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            sevens.Pause();
            this.Hide();
            StartMenu startMenu = new StartMenu();
            startMenu.Show();

        }

        private Bitmap getImage(String path)
        {
         
            if (Assembly.GetEntryAssembly().GetManifestResourceStream(path) == null)
            {
                MessageBox.Show("Some of the necessary game files cannot be accessed, so the game cannot be run.");
                StartMenu sm = new StartMenu();
                this.Hide();
                sm.Show();
                //end
                return null;
            }
            else
            {
                return new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(path));
            }
        }

        private void disablePlayerButtons()
        {
            for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
            {
                playerHand[cardNumber].Enabled = false;
            }
        }

        private void SortButton_Click(object sender, EventArgs e) //return to game, combine two sort buttons
        {

            for (int i = 0; i < 13; i++)
            {
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
            }

            sevens.getBoard().getQueue().getHumanPlayer().sortCards(false); 
            displayPlayersHand();
            sevens.currentMove();
            PlayGame();
        }

        private void SortSuit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 13; i++)
            {
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
            }

            sevens.getBoard().getQueue().getHumanPlayer().sortCards(true); 
            displayPlayersHand();
            sevens.currentMove();
            PlayGame();
        }
    }
}
