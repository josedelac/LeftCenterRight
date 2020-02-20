using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CST343Project
{
    public partial class SelectCompMenu : Form
    {
        public SelectCompMenu()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var twoComGame = new twoComGame();
            twoComGame.FormClosed += (s, args) => this.Close();
            twoComGame.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var threeComGame = new threeComGame();
            threeComGame.FormClosed += (s, args) => this.Close();
            threeComGame.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            var StartMenu = new StartMenu();
            StartMenu.FormClosed += (s, args) => this.Close();
            StartMenu.Show();
        }
    }
}
