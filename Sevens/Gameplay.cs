using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Sevens
{
    public partial class Gameplay : Form
    {
        PictureBox[,] c = new PictureBox[4, 14];
        Button[] playerHand = new Button[13];

        public Gameplay(int numberOfRounds, int difficulty)
        {
            Game sevens = new Game(numberOfRounds, difficulty);
            String[] playerHand = sevens.startGame(); //returns player's hand
            InitializeComponent();
            setUp(playerHand);
            // loop of turns, each turn returns a board which the GUI uses
            update(sevens.firstMove());
            sevens.Play();
            
            cardPlaced(0, 7);
        }

        private void update(Board board)
        {

        }
        private string convertToSuit(int suit)
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
    

        private void setUp(String[] hand)
        {

            //creates board of cards which are all hidden
            for (int suitCounter = 0; suitCounter < 4; suitCounter++)
            {
                for (int valueCounter = 1; valueCounter < 15; valueCounter++)
                {
                    PictureBox temp = new PictureBox();
                    temp.BackgroundImage = Image.FromFile("../" + convertToSuit(suitCounter) + valueCounter.ToString() + ".jpg");
                    temp.BackgroundImageLayout = ImageLayout.Zoom;
                    temp.Dock = DockStyle.Fill;
                    temp.Name = (convertToSuit(suitCounter) + valueCounter.ToString());
                    temp.Size = new Size(42, 68);
                    temp.Visible = false;
                    c[suitCounter, (valueCounter - 1)] = temp;
                    tablePanel.Controls.Add(temp, valueCounter, suitCounter);
                }
            }
            
            //displays user's hand
        for (int cardNumber = 0; cardNumber < 13; cardNumber++)
         {
                Button temp = new Button();
                temp.BackgroundImage = Image.FromFile("../" + hand[cardNumber] + ".jpg");
                temp.BackgroundImageLayout = ImageLayout.Zoom;
                temp.Dock = DockStyle.Fill;
                temp.Name = hand[cardNumber];
                temp.Size = new Size(42, 68);
                playerHand[cardNumber] = temp;
                tablePanel.Controls.Add(temp, cardNumber, 4);
            }
                        
        }
    private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public TableLayoutPanel getTableLayoutPanel()
        {
            return tablePanel;
        }

        private void D3_Click(object sender, EventArgs e)
        {

        }

        private void D2_Click(object sender, EventArgs e)
        {

        }

        private void D1_Click(object sender, EventArgs e)
        {

        }

        private void S3_Click(object sender, EventArgs e)
        {

        }

        private void S5_Click(object sender, EventArgs e)
        {

        }
    }
}
