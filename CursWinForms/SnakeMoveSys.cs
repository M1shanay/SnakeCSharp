using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CursWinForms
{
    public class SnakeMoveSys
    {
        private int dirX = 1, dirY = 0;
        public int DirX
        {
            get { return dirX; }
        }
        public int DirY
        {
            get { return dirY; }
        }

        public void MovementSystem(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode.ToString())
            {
                case "Right":
                    if (dirX == -1)
                        return;
                    dirX = 1;
                    dirY = 0;
                    break;
                case "Left":
                    if (dirX == 1)
                        return;
                    dirX = -1;
                    dirY = 0;
                    break;
                case "Up":
                    if (dirY == 1)
                        return;
                    dirX = 0;
                    dirY = -1;
                    break;
                case "Down":
                    if (dirY == -1)
                        return;
                    dirX = 0;
                    dirY = 1;
                    break;

            }
        }
    }
}
