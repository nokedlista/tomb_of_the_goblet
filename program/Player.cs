using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace program
{
    internal class Player
    {
        public int lives { get; set; }

        public void startGame()
        {
            lives = 3;
        }

        public void minusLife()
        {
            if(lives < 1)
            {
                death();
            }
            else
            {
                lives--;
            }
        }

        public void death()
        {

        }

        
    }
}
