using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class MapTestComplex
    {
        [TestMethod]
        public void ChangeSizeMapTest()
        {
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            MC.ChangeSize(0);
            int Before = MC.GetWidth;
            MC.ChangeSize(1);
            int After = MC.GetWidth;
            MC.ChangeSize(2);
            int AfterSecond = MC.GetWidth;
            Assert.IsTrue(After + Before + AfterSecond == 1800);

        }
        [TestMethod]
        public void MapCreateTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            int Before = form.Controls.Count;
            MC.GenerateMap(FC);
            int After = form.Controls.Count;
            Assert.IsTrue(After - Before == 42);
        }
    }
    [TestClass]
    public class SnakeTestComplex 
    {
        [TestMethod]
        public void SnakeEatTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            FakeFood FD = new FakeFood(MC);
            FakeFood FD1 = new FakeFood(MC);
            FakeFood FD2 = new FakeFood(MC);
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            SP.Eat(FC, FD, MC);
            SP.Eat(FC, FD1, MC);
            SP.Eat(FC, FD2, MC);
            Assert.IsTrue(SP.SizeOfSnake == 3);
        }
        [TestMethod]
        public void SnakeMoveTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            FakeFood FD = new FakeFood(MC);
            SP.Move(MC);
            Assert.IsFalse(SP.Eat(FC, FD, MC));
        }
        [TestMethod]
        public void SnakeMoveSystemTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            System.Windows.Forms.KeyEventArgs Down = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down);
            System.Windows.Forms.KeyEventArgs Left = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Left);
            System.Windows.Forms.KeyEventArgs Up = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up);
            SP.Move(MC);
            FakeFood FD = new FakeFood(MC);
            SP.MovementSystem(form, Down);
            SP.Move(MC);
            Assert.IsFalse(SP.Eat(FC, FD, MC));
            SP.MovementSystem(form, Left);
            SP.Move(MC);
            Assert.IsFalse(SP.Eat(FC, FD, MC));
            SP.MovementSystem(form, Up);
            SP.Move(MC);
            Assert.IsTrue(SP.Eat(FC, FD, MC));

        }
    }
    [TestClass]
    public class FoodTestComplex 
    {
        [TestMethod]
        public void FoodNewLocationTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            CursWinForms.Food FD = new CursWinForms.Food(MC);
            System.Drawing.Point LocationBefore = new System.Drawing.Point(FD.X, FD.Y);
            FD.GenerateNewLocation(FC, MC);
            Assert.IsTrue(LocationBefore != new System.Drawing.Point(FD.X, FD.Y));
        }
    }
    [TestClass]
    public class RoolsTestComplex 
    {
        [TestMethod]
        public void CheckBorderTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.Rools RL = new CursWinForms.Rools();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            int Border = 1;
            while (Border < MC.GetWidth + MC.GetSides)
            {
                Border += MC.GetSides;
                SP.Move(MC);
            }
            RL.CheckBorders(SP, MC);
            Console.WriteLine(SP[0].Location);
            FakeFood FD = new FakeFood(MC);
            Assert.IsTrue(SP.Eat(FC, FD, MC));
        }
        [TestMethod]
        public void ItSelfTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.Rools RL = new CursWinForms.Rools();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            FakeFood FD = new FakeFood(MC);
            System.Windows.Forms.KeyEventArgs Down = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down);
            System.Windows.Forms.KeyEventArgs Left = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Left);
            System.Windows.Forms.KeyEventArgs Up = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up);
            for (int i = 0; i < 6; i++)
            {
                SP.Eat(FC, FD, MC);
                FD.SetLocation();
            }
            int SizeBefore = SP.SizeOfSnake;
            SP.Move(MC);
            SP.MovementSystem(form, Down);
            SP.Move(MC);
            SP.MovementSystem(form, Left);
            SP.Move(MC);
            SP.MovementSystem(form, Up);
            SP.Move(MC);
            RL.itSelf(FC, SP);
            int SizeAfter = SP.SizeOfSnake;
            Assert.IsTrue(SizeBefore / SizeAfter == 2);
        }
        [TestMethod]
        public void DifficultyPlusTest()
        {

            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.Rools RL = new CursWinForms.Rools();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            CursWinForms.UpdateSys US = new CursWinForms.UpdateSys();
            int Before = US.GetInterval();
            int Value = 5;
            RL.SetDifficulty(Value);
            RL.DifficultyMinus(US);
            int After = US.GetInterval();
            Assert.IsTrue(Before - After == Value);
        }
        [TestMethod]
        public void DifficultyMinusTest()
        {

            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.Rools RL = new CursWinForms.Rools();
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            CursWinForms.UpdateSys US = new CursWinForms.UpdateSys();
            FakeFood FD = new FakeFood(MC);
            System.Windows.Forms.KeyEventArgs Down = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Down);
            System.Windows.Forms.KeyEventArgs Left = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Left);
            System.Windows.Forms.KeyEventArgs Up = new System.Windows.Forms.KeyEventArgs(System.Windows.Forms.Keys.Up);
            int Value = 5;
            RL.SetDifficulty(Value);
            int Before = US.GetInterval();
            for (int i = 0; i < 6; i++)
            {
                SP.Eat(FC, FD, MC);
                RL.DifficultyMinus(US);
                FD.SetLocation();
            }
            SP.Move(MC);
            SP.MovementSystem(form, Down);
            SP.Move(MC);
            SP.MovementSystem(form, Left);
            SP.Move(MC);
            SP.MovementSystem(form, Up);
            SP.Move(MC);
            RL.itSelf(FC, SP);
            RL.DifficultyPlus(US);
            Assert.IsTrue((SP.SizeOfSnake - 1) * Value + US.GetInterval() == Before);
        }
    }
    [TestClass]
    public class ScoreTestComplex 
    {
        [TestMethod]
        public void ScoreTest()
        {
            CursWinForms.Form form = new CursWinForms.Form();
            CursWinForms.MapControl MC = new CursWinForms.MapControl();
            CursWinForms.SnakePlayer SP = new CursWinForms.SnakePlayer(MC);
            CursWinForms.FormControl FC = new CursWinForms.FormControl(form);
            CursWinForms.UpdateSys US = new CursWinForms.UpdateSys();
            FakeFood FD = new FakeFood(MC);
            FC.SetScore(SP, US);
            string before = form.Text;
            SP.Eat(FC, FD, MC);
            FC.SetScore(SP, US);
            FC.SetHighScore(SP);
            string after = form.Text;
           Assert.IsTrue(before != after);

        }
    }
        public class FakeFood : CursWinForms.Food
        {
            public FakeFood(CursWinForms.MapControl map) : base(map)
            {
                fruit = new System.Windows.Forms.PictureBox();
                x = 1;
                y = 1;
            }
            public void SetLocation()
            {
                x = 1;
                y = 1;
            }
        }
}