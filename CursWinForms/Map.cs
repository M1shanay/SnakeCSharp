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
    public class Map
    {
        private int widthmap = 400;
        private int heightmap = 400;
        private int sizeofsides = 20;
        public int WidthOfMap
        {
            get { return widthmap; }
            set { widthmap = value; }
        }
        public int HeightOfMap
        {
            get { return heightmap; }
            set { heightmap = value; }
        }
        public int SizeOfSides
        {
            get { return sizeofsides; }
            set { sizeofsides = value; }
        }
    }
}
