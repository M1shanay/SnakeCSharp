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
    public class Rools
    {
        private Difficulty difficulty = new Difficulty();
        private FindDifference Diff = new FindDifference();
        private SnakeLocationControl SLC = new SnakeLocationControl();
        public void SetDifficulty(int value)
        {
            difficulty.Diffic = value;
        }
        public void CheckBorders(SnakePlayer Snake, MapControl map)
        {
            if (Snake[0].Location.X < 0)
            {
                SLC.ReverseMinX(Snake, map);
            }
            if (Snake[0].Location.Y < 0)
            {
                SLC.ReverseMinY(Snake, map);
            }
            if (Snake[0].Location.X > map.GetWidth + 1)
            {
                SLC.ReversePlusX(Snake, map);
            }
            if (Snake[0].Location.Y > map.GetHeight + 1)
            {
                SLC.ReversePlusY(Snake, map);
            }
        }
        public bool itSelf(FormControl form,SnakePlayer Snake)
        {
            for (int _i = 1; _i < Snake.SizeOfSnake; _i++)
            {
                if (Snake[0].Location == Snake[_i].Location)
                {
                    for (int _j = _i; _j <= Snake.SizeOfSnake; _j++)
                    {
                        //form.GameForm.Controls.Remove(Snake[_j]);
                        form.RemoveSnakePart(Snake[_j]);
                    }
                    //Diff.Difference = Snake.SizeOfSnake - _i + 1;
                    Diff.SetDiff(Diff.FindDiff(Snake.SizeOfSnake, _i));
                   // Snake.SizeOfSnake = Snake.SizeOfSnake - Diff.FindDiff(Snake.SizeOfSnake,_i);
                    Snake.ChangeSize(Diff.Difference);
                    return true;
                }
            }
            return false;
        }
        public void DifficultyMinus(UpdateSys Move)
        {
            Move.UpdateTimerIntervalMinus(difficulty.Diffic);
           // difficulty.DifficultyMinus(Move);
        }
        public void DifficultyPlus(UpdateSys Move/*, int Diff*/)
        {
            Move.UpdateTimerIntervalPlus((difficulty.Diffic * Diff.Difference) + difficulty.Diffic);
            //difficulty.DifficultyPlus(Move,_Difference);
        }
    }
}
