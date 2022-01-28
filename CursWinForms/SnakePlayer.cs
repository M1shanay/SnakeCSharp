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
    public class SnakePlayer
    {
        private SnakeMoveSys MoveSystem = new SnakeMoveSys();
        private PictureBox[] Snake = new PictureBox[400];
        private SoundPlayer sp = new SoundPlayer(Properties.Resources.Запись__9_);
        private int sizeofsnake;

        public PictureBox this[int index]
        {
            get { return Snake[index]; }
        }

        public int SizeOfSnake
        {
            get { return sizeofsnake; }
            set { sizeofsnake = value; }
        }
        public SnakePlayer(MapControl map)
        {
            Snake[0] = new PictureBox();
            Snake[0].Location = new Point(1, 1);
            Snake[0].Size = new Size(map.GetSides - 1, map.GetSides - 1);
            Snake[0].BackColor = Color.GreenYellow;
        }
        public void ChangeSize(int value)
        {
            sizeofsnake -= value;
        }
        public bool Eat(FormControl form,Food fruit, MapControl map)
        {
            if (Snake[0].Location.X == fruit.X && Snake[0].Location.Y == fruit.Y)
            {
                sp.Play();
                ++sizeofsnake;
                //if (Properties.Settings.Default.HighestScore < sizeofsnake)
                //{
                //    Properties.Settings.Default.HighestScore = sizeofsnake;
                //    Properties.Settings.Default.Save();
                //} 
                Snake[sizeofsnake] = new PictureBox();
                Snake[sizeofsnake].Location = new Point(Snake[sizeofsnake - 1].Location.X + map.GetSides * MoveSystem.DirX,
                                                        Snake[sizeofsnake - 1].Location.Y - map.GetSides * MoveSystem.DirY);
                Snake[sizeofsnake].Size = new Size(map.GetSides - 1, map.GetSides - 1);
                Snake[sizeofsnake].BackColor = Color.Green;
                //form.GameForm.Controls.Add(Snake[sizeofsnake]);
                form.AddSnakeTailToForm(Snake[sizeofsnake]);
                fruit.GenerateNewLocation(form,map);
                return true;
            }
            return false;
        }
        public void Move(MapControl map)
        {
            for (int i = sizeofsnake; i >= 1; i--)
            {
                Snake[i].Location = Snake[i - 1].Location;
            }
            Snake[0].Location = new Point(Snake[0].Location.X + MoveSystem.DirX * map.GetSides,
                                          Snake[0].Location.Y + MoveSystem.DirY * map.GetSides);
        }

        public void MovementSystem(object sender, KeyEventArgs e)
        {
            MoveSystem.MovementSystem(sender, e);
        }

    }
}
