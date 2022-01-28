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
    public class FormControl
    {
        private System.Windows.Forms.Form GameForm;
        public FormControl(System.Windows.Forms.Form form)
        {
            GameForm = form;
        }

        public void SetForm(MapControl Map, SnakePlayer Snake)
        {
            GameForm.Size = new Size(Map.GetWidth + 15, Map.GetHeight + 40);
            GameForm.Controls.Add(Snake[0]);
            GameForm.KeyDown += new KeyEventHandler(Snake.MovementSystem);
        }

        public void SetScore(SnakePlayer Snake, UpdateSys UpdaterSnake)
        {
            GameForm.Text = "Score: " + Snake.SizeOfSnake + " Speed: +" 
                                      + (UpdaterSnake.MaxInterval - UpdaterSnake.GetInterval()) 
                                      + " Highest score: " + Properties.Settings.Default.HighestScore;
        }
        public void SetHighScore(SnakePlayer Snake)
        {
            if (Properties.Settings.Default.HighestScore < Snake.SizeOfSnake)
            {
                Properties.Settings.Default.HighestScore = Snake.SizeOfSnake;
                Properties.Settings.Default.Save();
            }
        }
        public void AddFruitToForm(PictureBox Fruit)
        {
            GameForm.Controls.Add(Fruit);
        }
        public void AddSnakeTailToForm(PictureBox SnakeTail)
        {
            GameForm.Controls.Add(SnakeTail);
        }
        public void AddSideOfMap(PictureBox Side)
        {
            GameForm.Controls.Add(Side);
        }
        public void RemoveSnakePart(PictureBox SnakePart)
        {
            GameForm.Controls.Remove(SnakePart);
        }
    }
}
