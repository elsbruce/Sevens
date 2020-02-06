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


        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void Instructions_Click(object sender, EventArgs e)
        {
            this.Hide();
            Instructions i = new Instructions();
            i.Show();
        }
    }
}
