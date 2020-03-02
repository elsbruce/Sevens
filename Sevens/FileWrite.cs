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
    public partial class FileWrite : Form
    {
        public FileWrite(Game sevens)
        {
            InitializeComponent();


            sevens.Pause(Int32.Parse(positionToSave.Text), 100);
            StartMenu startMenu = new StartMenu();
            startMenu.Show();

        }
        private void FileWrite_Load(object sender, EventArgs e)
        {

        }
    }
}
