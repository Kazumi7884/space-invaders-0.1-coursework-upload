using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Space_Invaders
{
    public partial class Game_Over : Form
    {
        public static int Results; 

        public Game_Over()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;
        }

        private void Game_Over_Load(object sender, EventArgs e)
        {
            scoreBox.Text = "Your final score:" + Form1.Score.ToString();
            Form1.Score = Form1.Score + (Form1.totalTime * 2);
            scoreBox.Items.Add("Final Score:  " + Form1.Score.ToString());
            Form1.totalTime = Form1.TimerMin + Form1.TimerSec + Form1.TimerMsec;
            //scoreBox = Form1.totalTime  + Form1.firedcount;


        }

        private void scoreBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using(System.IO.StreamWriter file = new System.IO.StreamWriter(@"Scores.txt", true))
                {
                file.WriteLine(textBox1.Text + " " + Form1.Score + ("\n"));
            }


            Form1.totalTime = Form1.TimerMin + Form1.TimerSec + Form1.TimerMsec;
            string[] lines = System.IO.File.ReadAllLines(@"Scores.txt");
            foreach (string line in lines)
            {
                scoreBox.Items.Add(line + Form1.Score);
            }
            // this gets the score added to the listbox

        }
    }
}
