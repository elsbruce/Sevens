using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace Sevens
{
    public partial class Gameplay : Form
    {
        PictureBox[,] c = new PictureBox[4, 14];
        Button[] playerHand = new Button[13];
        Label[] otherPlayers = new Label[3];
        Game sevens;

        //when a button is pressed how to then return to the main body of code (not possible?)

        public Gameplay(int numberOfRounds, int difficulty)
        {
            sevens = new Game(numberOfRounds, difficulty);
            InitializeComponent();

            setUp(sevens.startGame());

            update(sevens.firstMove());

            PlayGame();
        }



        private void PlayGame()
        {


            Board b;

            b = sevens.Play();


            while (!this.Turn(b)){

              b=sevens.Play();
            }
            
                
            
        }

        private Boolean Turn(Board b)
        {
       
            if (b == null)
            {
                // if returns null then switch buttons on
                //timer.Start();
                for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
                {
                    playerHand[cardNumber].Enabled = true;
                    playerHand[cardNumber].Click += playerHand_Click;
                }
                //get move
                //then disable buttons
                return true;
            }
            else
            {
                update(b);
                return false;
            }
        }

        private void playerHand_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;

            //if move is valid then card button is hidden and card is added to board
            if (sevens.getBoard().validMove(sevens.getBoard().getQueue().getHumanPlayer().getCardAt(Convert.ToInt32(s.Name))).Equals("y")){
                playerHand[Convert.ToInt32(s.Name)].Visible = false;
                update(sevens.humanPlay(s.Name));
            }
            else
            {
                DialogResult errorMessage = MessageBox.Show("This is not a valid move");
            }

            for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
            {
                playerHand[cardNumber].Enabled = false;
            }

            PlayGame();
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
            }

            //updates size of other player's hands
            for (int playerNumber = 1; playerNumber < 4; playerNumber++) {
                otherPlayers[(playerNumber - 1)].Text = board.getSizeOfPlayersHands()[playerNumber].ToString(); ;
            }

            //updates player's cards
            //DONE AT HOME
        }

        //public void lightUp(int whichPlayer) //outlines the card of the player currently moving
        //{
        //    otherPlayers[(whichPlayer-1)].BorderStyle = BorderStyle.Fixed3D;
        //}

        private string convertToSuit(int suit) //probs shouldn't be in gameplay
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
                    temp.BackgroundImage = Image.FromFile("../" + convertToSuit(suitCounter) + valueCounter.ToString() + ".jpg"); //could move to card class
                    temp.BackgroundImageLayout = ImageLayout.Zoom;
                    temp.Dock = DockStyle.Fill;
                    temp.Name = (convertToSuit(suitCounter) + valueCounter.ToString());
                    temp.Size = new Size(42, 68);
                    temp.Visible = false;
                    c[suitCounter, (valueCounter - 1)] = temp;
                    tablePanel.Controls.Add(temp, (valueCounter-1), suitCounter);
                }
            }

            //displays user's hand
            for (int cardNumber = 0; cardNumber < board.getQueue().getHumanPlayer().getCurrentSize(); cardNumber++)
            {
                Button temp = new Button();
                temp.BackgroundImage = Image.FromFile("../" + board.getQueue().getHumanPlayer().getStringArrayOfCards()[cardNumber] + ".jpg");
                temp.BackgroundImageLayout = ImageLayout.Zoom;
                temp.Dock = DockStyle.Fill;
                temp.Name = cardNumber.ToString();
                temp.Size = new Size(42, 68);
                temp.Enabled = false;
                playerHand[cardNumber] = temp;
                tablePanel.Controls.Add(temp, cardNumber, 5);
            }

            //adds boxes for other players
            for (int playerNumber = 1; playerNumber < 4; playerNumber++)
            {
                Label temp = new Label();
                temp.BackgroundImage = Image.FromFile("../P" + playerNumber + ".jpg");
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
        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e) //concerningly does seem to work
        {
           // Turn(sevens.Play());
        }

        public TableLayoutPanel getTableLayoutPanel()
        {
            return tablePanel;
        }

        private void SortButton_Click(object sender, EventArgs e)
        {
            sevens.getBoard().getQueue().getHumanPlayer().sortCards(); //calls merge sort

            tablePanel.Controls.Clear(); //only needs to clear player hand
            setUp(sevens.getBoard());
            PlayGame();
            
        }


    }
}
