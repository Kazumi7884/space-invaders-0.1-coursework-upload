using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;

namespace Space_Invaders
{
    class Bullet
    {
        //object Variables
        private int xPos, yPos;
        private int formHeight;
        private PictureBox b;
        public static bool fired = false;

        public Bullet(Form f)
        {
            b = new PictureBox();
            b.BackgroundImage = Properties.Resources.Bullet;
            b.Width = 5;
            b.Height = 10;
            b.Visible = false;

            xPos = 500;
            yPos = -60;
            formHeight = f.Height;
                    

            move();

            f.Controls.Add(b);

           
        }

        public void move()
        {
            // If above upper window edge > diable
            if (yPos < 0) b.Visible = false;

            if (b.Visible)  //i.e. if it hasn't moved above or oustide the upper window edge
            {
                yPos = yPos - 30; // this allows the bullet item to move upwards
                b.Location = new Point(xPos, yPos);
            }

            if (yPos < -20) // this stops the bullet cosntatly respawning and forces the user to wait for a certain distance to be met
            {
                fired = false;
                b.Visible = false;
            }
        }

        public void fire()
        {
            b.Visible = true; //this allows the bullet to be visible
            yPos = formHeight - 100; // this allows the bullet to traverse the entire form height minus 100 pixels from the top
            fired = true; // this states that if the bullet is fired it is actually on screen
            b.Visible = true;
            b.Location = new Point(xPos, yPos);
        }
         
        public PictureBox GetPictureBox() //this is used for collision detection
        {
            return b;
        }

        public bool getfired()
        {
            return fired;
        }

        public void setxPos(int x)
        {
            xPos = x;
        }

        public void setyPos(int y)
        {
            yPos = y;
        }

        public void lMove()
        {
            xPos = xPos - 10;
            b.Location = new Point(xPos, yPos);
        }

        public void rMove()
        {      
         xPos = xPos + 10;
         b.Location = new Point(xPos, yPos);
            
        }
        
    }
}



