using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Space_Invaders
{
    class Player
    {

        //object Variables
        private int xPos, yPos;
        private PictureBox p;
        private int formWidth;

        public Player(Form f, int x, int y)
        {
            p = new PictureBox();
            p.BackgroundImage = Properties.Resources.Player;
            p.BackColor = Color.Transparent;
            p.Visible = true;

            xPos = x;
            yPos = y;
            formWidth = f.Width;

            p.Location = new Point(xPos, yPos);

            f.Controls.Add(p);
        }


        public void move()
        {
            // If above upper window edge > diable
            if (yPos < 0) p.Visible = false;

            if (p.Visible)  //i.e. if it hasn't moved above or oustide the upper window edge
            {
                yPos = yPos - 50; // this allows the bullet item to move upwards
                p.Location = new Point(xPos, yPos);
            }

        }

        public int getxPos()
        {
            return xPos;
        }

      

        public void lMove()
        {
            if (xPos > 0)
            {
                xPos = xPos - 10;
                p.Location = new Point(xPos, yPos);
            }
        }

        public void rMove()
        {
            if (xPos < 1300)
            {
                xPos = xPos + 10;
                p.Location = new Point(xPos, yPos);
            }
        }

        public PictureBox GetPictureBox() //this is used for collision detection
        {
            return p;
        }
    }
}
