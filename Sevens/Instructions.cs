using System;
using System.Windows.Forms;

namespace Sevens
{
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            StartMenu sm = new StartMenu();
            sm.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
    }
}
