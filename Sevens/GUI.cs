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
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void playButton_Click(object sender, EventArgs e)
        {
            // ADD VALIDATION

            if ((Rounds.SelectedIndex == -1) || (Difficulty.SelectedIndex == -1))
            {
                MessageBox.Show("Please select a number of rounds and a difficulty level");
            }
            else
            {
                this.Hide();
                Gameplay gp = new Gameplay(Rounds.SelectedIndex, Difficulty.SelectedIndex);
                gp.Show();
            }
        }

        private void Rounds_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Difficulty_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void loadPreviousGame_Click(object sender, EventArgs e)
        {
            menu1.Controls.Clear();
            menu1.ColumnCount = 3;
            menu1.RowCount = 3;

            Label messageToUser = new Label();
            messageToUser.Text = "Please input the number, between 1 and 5, where you would like to read the game from:";
            messageToUser.Dock = DockStyle.Fill;
            menu1.Controls.Add(messageToUser, 1, 0);

            TextBox text = new TextBox();
            text.Dock = DockStyle.Fill;
            menu1.Controls.Add(text, 1, 1);

            Button textEntered = new Button();
            textEntered.Text = "Go";
            menu1.Controls.Add(textEntered, 2, 1);
            textEntered.Click += TextEntered_Click;
        }
        private void TextEntered_Click(object sender, EventArgs e)
        {
            int whereToSave;

            if (Int32.TryParse(menu1.GetControlFromPosition(1, 1).Text, out whereToSave) && (whereToSave <= 5) && (whereToSave >= 1))
            {
                MessageBox.Show("ay");
                Game previous = new Game();
                previous.loadPrevious(whereToSave);
            }
            else
            {
                MessageBox.Show("invalid");
            }

        }

        private void Instructions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instructions i = new Instructions();
            i.Show();
        }
    }
}
