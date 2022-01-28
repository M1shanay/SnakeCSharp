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
    public class Food
    {
       protected PictureBox fruit;
       protected int x, y;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        private void SetLocation(Point point)
        {
            fruit.Location = point;
        }
        private void LocationToForm(FormControl form)
        {
            //form.GameForm.Controls.Add(fruit);
            form.AddFruitToForm(fruit);
        }
        public Food(MapControl map)
        {
            fruit = new PictureBox();
            fruit.BackColor = Color.Yellow;
            fruit.Size = new Size(map.GetSides, map.GetSides);
        }
        public void GenerateNewLocation(FormControl form, MapControl map)
        {
            Random r = new Random();
            x = r.Next(0, map.GetWidth - map.GetSides);
            int tempI = x % map.GetSides;
            x -= tempI;
            y = r.Next(0, map.GetHeight - map.GetSides);
            int tempJ = y % map.GetSides;
            y -= tempJ;
            x++;
            y++;
            //fruit.Location = new Point(x, y);
            SetLocation(new Point(x, y));
            LocationToForm(form);
           // form.AddFruitToForm(fruit);
           // form.GameForm.Controls.Add(fruit);
        }
    }
  public class FoodRed : Food
  {
       public FoodRed(MapControl map): base (map)
      {
          fruit = new PictureBox();
          fruit.BackColor = Color.Red;
          fruit.Size = new Size(map.GetSides, map.GetSides);
      }
  }
   public class FoodBlue : Food
   {
       public FoodBlue(MapControl map): base (map)
       {
           fruit = new PictureBox();
           fruit.BackColor = Color.Blue;
           fruit.Size = new Size(map.GetSides, map.GetSides);
       }
   }
}
