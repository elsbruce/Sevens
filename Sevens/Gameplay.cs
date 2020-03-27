using System;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
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

          //  displayPlayersHand();

            PlayGame();
        }

        public Gameplay(int whereToReadFrom)
        {
            InitializeComponent();
            sevens = new Game();
            sevens.loadPrevious(whereToReadFrom);
            setUp(sevens.getBoard()); //creates all objects
            resumeFromPreviousGame(); //sets up the board
            displayPlayersHand();
            update(sevens.getBoard());
            PlayGame();
        }

        private void PlayGame() //if the game is not over, loops through each player's turn, if game is over displays appropriate messages
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
            else
            {
                MessageBox.Show("Player " + sevens.getLeaderboard()[0].ToString() + " won.");
                for (int i = 0; i < sevens.getLeaderboard().Count; i++)
                {
                    if (sevens.getLeaderboard()[i] == 0)
                    {
                        MessageBox.Show("You came in position " + (i + 1));
                    }
                }


                if (sevens.getRoundsPlayed() < sevens.getNumberOfRounds())
                {
                    restartGame();
                }
                else
                {
                    StartMenu returnToStart = new StartMenu();
                    this.Hide();
                    returnToStart.Show();
                }
            }

        }


        private Boolean Turn(Board b)
        {

            if (b == null)
            {
                // if returns null then switch buttons on
                for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().GetHumanPlayer().getCurrentSize(); cardNumber++)
                {
                    playerHand[cardNumber].Enabled = true;
                  //  playerHand[cardNumber].Click += playerHand_Click;
                }

                skipTurnButton.Enabled = true;
                //get move
                //then disable buttons
                return true;
            }
            else
            {
                displayAITurn(); //goes to this when current player index = 0
                update(sevens.getBoard());
                Refresh();
                otherPlayers[(sevens.getBoard().getQueue().GetCurrentPlayerIndex() - 1)].BackgroundImage = getImage("Sevens.images.P" + (sevens.getBoard().getQueue().GetCurrentPlayerIndex()) + ".jpg");
                return false;
            }
        }

        private void playerHand_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            if (s.Name == "skipTurnButton" || s.Name == "")
            {
                PlayGame();
            }

            else {
                Board humanTurn = sevens.humanPlay(s.Name);
                if (humanTurn == null)
                {
                    MessageBox.Show("This is not a valid move.");
                    Turn(null);
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
            for (int playerNumber = 1; playerNumber < 4; playerNumber++)
            {
                if (sevens.getBoard().getQueue().GetPlayerAt(playerNumber).handEmpty())
                {
                    otherPlayers[(playerNumber - 1)].Text = "finished";
                }
                else
                {
                    otherPlayers[(playerNumber - 1)].Text = sevens.getBoard().getSizeOfPlayersHands()[playerNumber].ToString();
                }
            }
        }


        public void displayAITurn() //displays a loading symbol on the player currently moving for a short amount of time
        {
            otherPlayers[(sevens.getBoard().getQueue().GetCurrentPlayerIndex() - 1)].BackgroundImage = getImage("Sevens.images.loading.jpg");
            int milliseconds = 500;
            Thread.Sleep(milliseconds);

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
                    //  temp.Name = (sevens.convertToSuit(suitCounter) + valueCounter.ToString());
                    temp.Size = new Size(42, 68);
                    temp.Visible = false;
                    c[suitCounter, (valueCounter - 1)] = temp;
                    tablePanel.Controls.Add(temp, (valueCounter - 1), suitCounter);
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
                temp.Font = new Font("Arial", 18, FontStyle.Bold);
                temp.ForeColor = Color.Black;
                otherPlayers[(playerNumber - 1)] = temp;
                tablePanel.Controls.Add(temp, 15, (playerNumber - 1));
            }

            pauseButton.BackgroundImage = getImage("Sevens.images.pause.png");
            pauseButton.BackgroundImageLayout = ImageLayout.Zoom;
            pauseButton.Text = ("");

            displayPlayersHand();

            for (int i = 0; i < sevens.getBoard().getQueue().GetHumanPlayer().getCurrentSize(); i++) //creates an event handler for when a button representing one of the player's cards is clicked
            {
                playerHand[i].Click += playerHand_Click;
            }
        }

        public void resumeFromPreviousGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int value = sevens.getBoard().getMin()[i]; value < sevens.getBoard().getMax()[i]; value++)
                {
                    cardPlaced(i, value);
                }
            }
        }

        public void displayPlayersHand()
        {
            //displays user's hand
            for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().GetHumanPlayer().getCurrentSize(); cardNumber++)
            {
                Button temp = new Button();
                temp.BackgroundImage = getImage("Sevens.images." + sevens.getBoard().getQueue().GetHumanPlayer().getStringArrayOfCards()[cardNumber] + ".jpg");
                temp.BackgroundImageLayout = ImageLayout.Zoom;
                temp.Dock = DockStyle.Fill;
                temp.Name = cardNumber.ToString();
                temp.Size = new Size(42, 68);
                playerHand[cardNumber] = temp;
                tablePanel.Controls.Add(temp, cardNumber, 5);
            }
        }

        private void restartGame()
        {
            sevens.setRoundsPlayed(sevens.getRoundsPlayed() + 1);
            for (int suit = 0; suit < 4; suit++)
            {
                for (int i = 0; i < 14; i++)
                {
                    tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, suit));
                }
            }
            sevens.startGame();
            update(sevens.firstMove());
            displayPlayersHand();
            PlayGame();
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

        private void PauseButton_Click(object sender, EventArgs e) //checks whether text file to be saved to exists, then clears tablelayoutpanel to allow the user to input a number for where the game is to be saved
        {

            if (!(sevens.fileExists()))
            {
                MessageBox.Show("This game cannot be saved to an external file");

            }
            else
            {
                tablePanel.Controls.Clear();
                tablePanel.ColumnCount = 3;
                tablePanel.RowCount = 3;
                tablePanel.BackColor = Color.White;
                Label messageToUser = new Label();
                messageToUser.Text = "Please input the number, between 1 and 5, where you would like to save this game position to:";
                messageToUser.Dock = DockStyle.Fill;
                tablePanel.Controls.Add(messageToUser, 1, 0);

                TextBox text = new TextBox();
                text.Dock = DockStyle.Fill;
                tablePanel.Controls.Add(text, 1, 1);

                Button textEntered = new Button();
                textEntered.Text = "Go";
                tablePanel.Controls.Add(textEntered, 2, 1);
                textEntered.Click += TextEntered_Click;
            }
        }

        private void TextEntered_Click(object sender, EventArgs e)
        {
            int whereToSave;

            if (Int32.TryParse(tablePanel.GetControlFromPosition(1, 1).Text, out whereToSave) && (whereToSave <= 5) && (whereToSave >= 1))
            {
                sevens.Pause(whereToSave);
                returnToStartMenu();
            }
            else
            {
                MessageBox.Show("invalid");
            }

        }

        private Bitmap getImage(String path)
        {

            if (Assembly.GetEntryAssembly().GetManifestResourceStream(path) == null)
            {
                MessageBox.Show("Some of the necessary game files cannot be accessed, so the game cannot be run.");
                returnToStartMenu();
                return null;
            }
            else
            {
                return new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(path));
            }
        }

        private void disablePlayerButtons()
        {
            for (int cardNumber = 0; cardNumber < sevens.getBoard().getQueue().GetHumanPlayer().getCurrentSize(); cardNumber++)
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

            sevens.getBoard().getQueue().GetHumanPlayer().sortCards(false);
            displayPlayersHand();
            sevens.getBoard().getQueue().CurrentPlayerMinusOne();
            PlayGame();
        }

        private void SortSuit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 13; i++)
            {
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
            }

            sevens.getBoard().getQueue().GetHumanPlayer().sortCards(true);
            displayPlayersHand();
            sevens.getBoard().getQueue().CurrentPlayerMinusOne();
            PlayGame();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void returnToStartMenu()
        {
            StartMenu start = new StartMenu();
            this.Hide();
            start.Show();
        }
    }
}
