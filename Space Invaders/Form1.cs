using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Space_Invaders
{
    public partial class Form1 : Form
    {
        private Swarm swa;
        private Invader inv;
        private Bullet bul;
        private Player p;
        public static int TimerMsec = 00;
        public static int TimerSec = 00;
        public static int TimerMin = 00;
        //bool GameOverPASS = false;
        //int GameOverCounter = 1;
        public static int firedcount = 0;
        public static int score = 0;
        public static int InvadersC = 10;
        public static int hit = 0;
        int pauseCount = 0;
        bool lockKeys = false;
        public static int Score;
        public static int totalTime;
        //these are all the variables my game uses to run

        public Form1()
        {
            InitializeComponent();
            swa = new Swarm(this);
            bul = new Bullet(this);
            p = new Player(this, this.Width / 2, this.Height - 100);

            //WindowState = FormWindowState.Maximized;
            //FormBorderStyle = FormBorderStyle.None;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {


            swa.move(); //this allows the swarm to move
            bul.move(); //this allows the bulelt to move
            swa.checkIfHit(bul, this); //this checks is the bullet hits the swarm
            swa.checkIfHit(p, this); // this checks if teh swarm hits the player
            shotsLbl.Text = ("You've fired  " + firedcount); //this tracks the shots fired
            scoreLbl.Text = ("Your score   " + score); //this checks the score based on the aliens defeated
            if (InvadersC == 0) //if all on screen invaders are now invisible and none are left, press space to progress to the next sceen (game over screen)
            {
                label1.Visible = false;
                timer1.Stop();

                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"Scores.txt", true))
                {
                    file.WriteLine(("\n") + Score); //this writes the game score to Scores.txt
                }

                this.Hide();

                Game_Over frm1 = new Game_Over(); //this hides the current form and allows the next form to show the game over screen
                frm1.Show();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyValue == (char)Keys.Space) && !bul.getfired() && lockKeys == false)
            {
                bul.setxPos(p.getxPos() + 34);
                bul.fire();
                firedcount += 1;
                SoundPlayer audio = new SoundPlayer(Properties.Resources.needler); //this plays a sound when the bullet is fired
                audio.Play();
            }


            if ((e.KeyCode == Keys.Left) && lockKeys == false || (e.KeyCode == Keys.A) && lockKeys == false)
            {
                p.lMove(); //this lets left key and A move the player left
            }

            if ((e.KeyCode == Keys.Right) && lockKeys == false || (e.KeyCode == Keys.D) && lockKeys == false)
            {
                p.rMove(); //this lets the right key and D move the player right
            }


            if (e.KeyCode == Keys.Escape)
            {
                pauseCount++;
                timer1.Stop();
                timer2.Stop();
                lockKeys = true;
                if (pauseCount == 2)
                {
                    timer1.Start();
                    timer2.Start();
                    pauseCount = 0;
                    lockKeys = false;
                }

                //this lets the player pause the game, this also stops both timers and the player from moving by pressing the escape key

            }

            
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            TimerMsec += 01;
            if (TimerMsec == 59)
            {
                TimerMsec = 00;
                TimerSec += 1;
            }

            if (TimerSec >= 59)
            {
                TimerSec = 00;
                TimerMin += 01;
            }

            if (TimerMin >= 99)
            {
                Close();
            }

            timeLbl.Text = ("Your time:" + TimerMin + ":" + TimerSec + ":" + TimerMsec);
            //this timer allows the lables to show the game time in seconds, minutes and milliseconds
        }



        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void scoreLbl_Click(object sender, EventArgs e)
        {

        }


       
        
    }

}

