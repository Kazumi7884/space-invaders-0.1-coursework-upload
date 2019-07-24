using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace Space_Invaders
{
    class Swarm
    {
        private Invader[] swa = new Invader[10];

        //constructor: same name as the class
        public Swarm(Form f)
        {
            for (int i = 0; i < swa.Length;  ++i)
            {
                swa[i] = new Invader(f, 10 + (i * 130), 10); //this has created an array of invaders for the game
            }
            Form1.InvadersC += 1;

        } // end of the constructor


        public void move()
        {
            for (int i = 0; i < swa.Length; ++i)
            {
                swa[i].move();
            }
        } // end of move method

        public void checkIfHit(Bullet b, Form f)
        {
            for (int i = 0; i < swa.Length; ++i)
            {
                swa[i].checkIfHit(b, f);
            }
        } // checks if the bullet collides

        public void checkIfHit(Player p, Form f)
        {
            for (int i = 0; i < swa.Length; ++i)
            {
                swa[i].checkIfHit(p, f);
            }
        } // checks for player collison

    }
}
