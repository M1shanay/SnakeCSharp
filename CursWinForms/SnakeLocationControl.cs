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

namespace CursWinForms
{
    public class SnakeLocationControl
    {
        public void ReversePlusY(SnakePlayer Snake,MapControl map)
        {
            Snake[0].Location = new Point(Snake[0].Location.X, Snake[0].Location.Y - map.GetHeight - map.GetSides);
        }
        public void ReversePlusX(SnakePlayer Snake, MapControl map)
        {
            Snake[0].Location = new Point(Snake[0].Location.X - map.GetWidth - map.GetSides, Snake[0].Location.Y);
        }
        public void ReverseMinY(SnakePlayer Snake, MapControl map)
        {
            Snake[0].Location = new Point(Snake[0].Location.X, Snake[0].Location.Y + map.GetHeight + map.GetSides);
        }
        public void ReverseMinX(SnakePlayer Snake, MapControl map)
        {
            Snake[0].Location = new Point(Snake[0].Location.X + map.GetWidth + map.GetSides, Snake[0].Location.Y);
        }
    }
}
