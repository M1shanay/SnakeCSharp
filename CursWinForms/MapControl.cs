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
    public class MapControl
    {
        private Map map = new Map();
        public int GetWidth
        {
            get { return map.WidthOfMap; }
        }
        public int GetHeight
        {
            get { return map.HeightOfMap; }
        }
        public int GetSides
        {
            get { return map.SizeOfSides; }
        }
        public void ChangeSize(int value)
        {
            switch (value)
            {
                case 0:
                    map.WidthOfMap = 400;
                    map.HeightOfMap = 400;
                    break;
                case 1:
                    map.WidthOfMap = 600;
                    map.HeightOfMap = 600;
                    break;
                case 2:
                    map.WidthOfMap = 800;
                    map.HeightOfMap = 800;
                    break;
            }
        }
        public void GenerateMap(FormControl form)
        {
            for (int i = 0; i <= map.WidthOfMap / map.SizeOfSides; ++i)
            {
                PictureBox hside = new PictureBox();
                hside.BackColor = Color.Black;
                hside.Location = new Point(0, map.SizeOfSides * i);
                hside.Size = new Size(map.WidthOfMap, 1);
                form.AddSideOfMap(hside);
            }
            for (int i = 0; i <= map.HeightOfMap / map.SizeOfSides; ++i)
            {
                PictureBox vside = new PictureBox();
                vside.BackColor = Color.Black;
                vside.Location = new Point(map.SizeOfSides * i, 0);
                vside.Size = new Size(1, map.WidthOfMap);
                form.AddSideOfMap(vside);
                //form.Controls.Add(vside);
            }
        }
    }
}
