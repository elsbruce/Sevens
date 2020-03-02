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
   partial class FileWrite : Form
    {
        Game sevens;
        public FileWrite(Game sevens)
        {
            InitializeComponent();

            this.sevens = sevens;


        }
        private void FileWrite_Load(object sender, EventArgs e)
        {

        }

        private void PositionToSave_TextChanged(object sender, EventArgs e)
        {

        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            sevens.Pause(Int32.Parse(positionToSave.Text), 100);
            StartMenu startMenu = new StartMenu();
            startMenu.Show();
        }
    }
}
