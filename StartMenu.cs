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
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void StartMenu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var selectCom = new SelectCompMenu();
            selectCom.FormClosed += (s, args) => this.Close();
            selectCom.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var HowToPlay = new HowToPlay();
            HowToPlay.FormClosed += (s, args) => this.Close();
            HowToPlay.Show();
        }
    }
}
