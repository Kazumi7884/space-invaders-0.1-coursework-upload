using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing; // this is for the colour and point
using System.Windows.Forms; // this is for the picturebox to be used within the form
using System.Media;

namespace Space_Invaders
{
    class Invader
    {
        //object variables
        private int xPos, yPos;
        private int moveDir = 6;
        private PictureBox inv;
        private int counter = 0;
        private int formWidth;


        // Constructor = Same name as the class
        public Invader(Form f, int x, int y)
        {
            inv = new PictureBox();
            inv.Image = Properties.Resources.Arbiter_1;
            inv.Height = inv.Image.Height;
            inv.Width = inv.Image.Width;
            inv.BackColor = Color.Transparent;

            yPos = y;
            xPos = x;
            inv.Location = new Point(xPos, yPos);

            f.Controls.Add(inv);
            formWidth = f.Width;
        }

        public void move()
        {
            //flick between the two appearences
            ++counter;
            if (counter == 40) counter = 0;

            if (counter < 20)
            {
                inv.Image = Properties.Resources.Arbiter_1;
            }
            else
            {
                inv.Image = Properties.Resources.Arbiter_2;
            }



            // move code
            xPos = xPos + moveDir;
            // if end of widnow is reached
            if (((xPos + inv.Width + 5) > formWidth || (xPos < 10)))
            {
                yPos = yPos + inv.Height + 10;
                moveDir = -moveDir;
            }

            inv.Location = new Point(xPos, yPos);
        }// end of move method

        public void checkIfHit(Bullet bll, Form f) //collision detection method
        {
          

            if (bll.GetPictureBox().Bounds.IntersectsWith(inv.Bounds) && bll.GetPictureBox().Visible)
            {
            
                inv.Visible = false;
                bll.GetPictureBox().Visible = false;
                Bullet.fired = false;
                Form1.score += 1;
                Form1.InvadersC -= 1;
                Form1.hit += 1;

                SoundPlayer audio = new SoundPlayer(Properties.Resources.explosion);
                audio.Play();
            }
                     
        } // end of checkIfHit method


        public PictureBox GetPictureBox() //this is used for collision detection
        {
            return inv;
        }

        public void checkIfHit(Player p, Form f) //collision detection method
        {
            if (p.GetPictureBox().Bounds.IntersectsWith(inv.Bounds) && p.GetPictureBox().Visible)
            {

                inv.Visible = false;
                p.GetPictureBox().Visible = false;

                Game_Over frm1 = new Game_Over();
                frm1.Show();

            }

        } // end of checkIfHit method
    }

}
