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
        PictureBox passToken = new PictureBox();

        public Gameplay(int numberOfRounds, int difficulty)
        {
            sevens = new Game(numberOfRounds, difficulty);
            InitializeComponent();

            SetUp(sevens.StartGame());

            Update(sevens.FirstMove());

            PlayGame();
        }

        public Gameplay(int whereToReadFrom)
        {
            InitializeComponent();
            sevens = new Game();
            sevens.LoadPrevious(whereToReadFrom);
            SetUp(sevens.GetBoard()); //creates all objects
            ResumeFromPreviousGame(); //sets up the board
                                      //   displayPlayersHand();
            Update(sevens.GetBoard());
            PlayGame();
        }

        private void PlayGame() //if the game is not over, loops through each player's turn, if game is over displays appropriate messages
        {
            if (sevens.IsOver() == "N")
            {
                Board b;
                b = sevens.NextMove();

                while (!this.Turn(b))
                {
                    b = sevens.NextMove();
                }
            }
            else
            {
                MessageBox.Show("Player " + sevens.GetLeaderboard()[0].ToString() + " won.");
                for (int i = 0; i < sevens.GetLeaderboard().Count; i++)
                {
                    if (sevens.GetLeaderboard()[i] == 0)
                    {
                        MessageBox.Show("You came in position " + (i + 1));
                    }
                }


                if (sevens.GetRoundsPlayed() < sevens.GetNumberOfRounds())
                {
                    RestartGame();
                }
                else
                {
                    Leaderboard leaderboard = new Leaderboard();
                    this.Hide();
                    leaderboard.Show();
                }
            }

        }

        //Turn takes a Board b, which stores the current state of the game (which cards have been placed, the cards held by each player and the queue of players)
        //returns a Boolean which is true if it is a HumanPlayer's turn, and false if it is an AI player's turn
        //Turn distinguishes between whether it is the turn of a human player or an AI player, and updates the GUI appropriately
        //if it is a human player's turn then the buttons representing the human player's hands are switched on, as is the skip turn button
        //if it is an AI player's turn, then displayAITurn and update are called, and then the background image of the current AI player is returned to the back of a card
        private Boolean Turn(Board b)
        {

            if (b == null)
            {
                // if returns null then switch buttons on for players turn - card buttons and skip turn buttons
                for (int cardNumber = 0; cardNumber < sevens.GetBoard().getQueue().GetHumanPlayer().GetCurrentSize(); cardNumber++)
                {
                    playerHand[cardNumber].Enabled = true;
                }

                skipTurnButton.Enabled = true;
                return true;
            }
            else
            {
                DisplayAITurn();
                Update(sevens.GetBoard());
                Refresh();
                otherPlayers[(sevens.GetBoard().getQueue().GetCurrentPlayerIndex() - 1)].BackgroundImage = GetImage("Sevens.images.P" + (sevens.GetBoard().getQueue().GetCurrentPlayerIndex()) + ".jpg");
                return false;
            }
        }

        //called when one of the player's cards are clicked, parsed an object "sender" which is a reference to the control/object that raised the event, and a parameter "e" which contains the event data
        //
        private void PlayerHand_Click(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            //if (s.Name == "skipTurnButton" || s.Name == "")
            //{
            //    PlayGame();
            //}

            Board humanTurn = sevens.HumanPlay(s.Name);
            if (humanTurn == null)
            {
                MessageBox.Show("This is not a valid move.");
                Turn(null);
            }
            else
            {
                Update(humanTurn);
                for (int i = 0; i < 13; i++)
                {
                    tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
                }
                DisplayPlayersHand();
                DisablePlayerButtons();
                PlayGame();
            }
        }

        private void Update(Board board)
        {
            //updates board
            for (int suit = 0; suit < 4; suit++)
            {
                if (board.SuitComplete(suit))
                {
                    CondenseSuit(suit);
                }
                else
                {
                    if (board.getSevens()[suit] == true) //if the seven has been placed, then show other things
                    {
                        CardPlaced(suit, board.getMin()[suit]);
                        CardPlaced(suit, board.getMax()[suit]);
                    }
                    if (board.getAces()[suit] == true)
                    {
                        PlaceAce(suit);
                    }
                }
            }

            //updates size of other player's hands
            for (int playerNumber = 1; playerNumber < 4; playerNumber++)
            {
                if (sevens.GetBoard().getQueue().GetPlayerAt(playerNumber).HandEmpty())
                {
                    otherPlayers[(playerNumber - 1)].Text = "finished";
                }
                else
                {
                    otherPlayers[(playerNumber - 1)].Text = sevens.GetBoard().getSizeOfPlayersHands()[playerNumber].ToString();
                }
            }

            //assign pass token
            //     otherPlayers[0].Image = getImage("Sevens.images.passToken.jpg");

        }


        public void DisplayAITurn() //displays a loading symbol on the player currently moving for a short amount of time
        {
            otherPlayers[(sevens.GetBoard().getQueue().GetCurrentPlayerIndex() - 1)].BackgroundImage = GetImage("Sevens.images.loading.jpg");
            int milliseconds = 500;
            Thread.Sleep(milliseconds);

        }

        private void PlaceAce(int suit) //if both
        {
            if (sevens.GetBoard().getMin()[suit] == 2) //if minimumm equals 2, then play ace low
            {
                CardPlaced(suit, 1);

            }
            else if (sevens.GetBoard().getMax()[suit] == 13) //if maximum equals 13, then play ace high
            {
                CardPlaced(suit, 14);
            }
        }


        private void CardPlaced(int suitCounter, int valueCounter)
        {
            c[suitCounter, (valueCounter - 1)].Visible = true;
        }
        private void SetUp(Board board)
        {

            SetUpBoardOfCards(board);

            //adds boxes for other players
            for (int playerNumber = 1; playerNumber < 4; playerNumber++)
            {
                Label temp = new Label();
                temp.BackgroundImage = GetImage("Sevens.images.P" + playerNumber + ".jpg");
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

            //create pause button
            pauseButton.BackgroundImage = GetImage("Sevens.images.pause.png");
            pauseButton.BackgroundImageLayout = ImageLayout.Zoom;
            pauseButton.Text = ("");

            //create pass token
            passToken.BackgroundImage = GetImage("Sevens.images.passToken.jpg");
            passToken.BackgroundImageLayout = ImageLayout.Zoom;
            passToken.Dock = DockStyle.Fill;
            passToken.Size = new Size(30, 50); //doesn't work
            tablePanel.Controls.Add(passToken, 13, sevens.GetBoard().getQueue().WhoHasPassToken());

            DisplayPlayersHand();
        }

        public void ResumeFromPreviousGame()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int value = sevens.GetBoard().getMin()[i]; value < sevens.GetBoard().getMax()[i]; value++)
                {
                    CardPlaced(i, value);
                }
            }
        }

        public void DisplayPlayersHand()
        {
            //displays user's hand
            for (int cardNumber = 0; cardNumber < sevens.GetBoard().getQueue().GetHumanPlayer().GetCurrentSize(); cardNumber++)
            {
                Button temp = new Button();
                temp.BackgroundImage = GetImage("Sevens.images." + sevens.GetBoard().getQueue().GetHumanPlayer().GetStringArrayOfCards()[cardNumber] + ".jpg");
                temp.BackgroundImageLayout = ImageLayout.Zoom;
                temp.Dock = DockStyle.Fill;
                temp.Name = cardNumber.ToString();
                temp.Size = new Size(42, 68);
                playerHand[cardNumber] = temp;
                playerHand[cardNumber].Click += PlayerHand_Click;
                tablePanel.Controls.Add(temp, cardNumber, 5);
            }
        }

        private void RestartGame()
        {
            sevens.SetRoundsPlayed(sevens.GetRoundsPlayed() + 1);

            for (int suit = 0; suit < 4; suit++)
            {
                for (int i = 0; i < 14; i++)
                {
                    if (tablePanel.GetControlFromPosition(i, suit) != null)
                    {
                        tablePanel.GetControlFromPosition(i, suit).Visible = false;
                    }
                }
            }
            SetUpBoardOfCards(sevens.StartGame());
            Update(sevens.FirstMove());
            DisplayPlayersHand();
            PlayGame();
        }

        private void SkipTurn_Click(object sender, EventArgs e)
        {
            sevens.AssignPassToken(0);
            PlayGame();

        }

        private void TablePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CondenseSuit(int suit)
        {
            for (int i = 0; i < 14; i++)
            {
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, suit));
            }

            Button suitComplete = new Button();
            suitComplete.BackgroundImage = GetImage("Sevens.images." + sevens.ConvertToSuit(suit) + ".jpg");
            suitComplete.BackgroundImageLayout = ImageLayout.Zoom;
            suitComplete.Dock = DockStyle.Fill;
            suitComplete.Size = new Size(42, 68);
            tablePanel.Controls.Add(suitComplete, 7, suit);
        }

        private void PauseButton_Click(object sender, EventArgs e) //checks whether text file to be saved to exists, then clears tablelayoutpanel to allow the user to input a number for where the game is to be saved
        {

            if (!(sevens.FileExists()))
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
                messageToUser.Font = new Font("Arial", 16);
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
                ReturnToStartMenu();
            }
            else
            {
                MessageBox.Show("invalid");
            }

        }

        private Bitmap GetImage(String path)
        {

            if (Assembly.GetEntryAssembly().GetManifestResourceStream(path) == null)
            {
                MessageBox.Show("Some of the necessary game files cannot be accessed, so the game cannot be run.");
                ReturnToStartMenu();
                return null;
            }
            else
            {
                return new Bitmap(Assembly.GetEntryAssembly().GetManifestResourceStream(path));
            }
        }

        private void DisablePlayerButtons()
        {
            for (int cardNumber = 0; cardNumber < sevens.GetBoard().getQueue().GetHumanPlayer().GetCurrentSize(); cardNumber++)
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

            sevens.GetBoard().getQueue().GetHumanPlayer().SortCards(false);
            DisplayPlayersHand();
            sevens.GetBoard().getQueue().CurrentPlayerMinusOne();
            PlayGame();
        }

        private void SortSuit_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 13; i++)
            {
                tablePanel.Controls.Remove(tablePanel.GetControlFromPosition(i, 5));
            }

            sevens.GetBoard().getQueue().GetHumanPlayer().SortCards(true);
            DisplayPlayersHand();
            sevens.GetBoard().getQueue().CurrentPlayerMinusOne();
            PlayGame();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void ReturnToStartMenu()
        {
            StartMenu start = new StartMenu();
            this.Hide();
            start.Show();
        }

        private void SetUpBoardOfCards(Board board)
        {
            //creates board of cards which are all hidden
            for (int suitCounter = 0; suitCounter < 4; suitCounter++)
            {
                for (int valueCounter = 1; valueCounter < 15; valueCounter++)
                {
                    PictureBox temp = new PictureBox();
                    temp.BackgroundImage = GetImage("Sevens.images." + sevens.ConvertToSuit(suitCounter) + valueCounter.ToString() + ".jpg");
                    temp.BackgroundImageLayout = ImageLayout.Zoom;
                    temp.Dock = DockStyle.Fill;
                    temp.Size = new Size(42, 68);
                    temp.Visible = false;
                    c[suitCounter, (valueCounter - 1)] = temp;
                    tablePanel.Controls.Add(temp, (valueCounter - 1), suitCounter);
                }
            }

        }

        public TableLayoutPanel GetTableLayoutPanel()
        {
            return tablePanel;
        }
    }

}
