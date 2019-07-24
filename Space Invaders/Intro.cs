using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Space_Invaders
{
    public partial class introScreen : Form
    {
        public introScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1= new Form1();
            frm1.Show();
            SoundPlayer audio = new SoundPlayer(Properties.Resources.gun_cock);
            audio.Play();
        }

        private void introScreen_Load(object sender, EventArgs e)
        {

        }

       
    }
}
