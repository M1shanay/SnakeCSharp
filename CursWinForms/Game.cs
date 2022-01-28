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
    public class Game
    {
        private Rools Rools = new Rools();
        private MapControl Map = new MapControl();
        private FormControl GameForm;
        private SnakePlayer Snake;
        private Food Fruit;
        private Food Fruit1;
        private Food Fruit2;
        private UpdateSys UpdaterSnake = new UpdateSys();
        private UpdateSys UpdaterRools = new UpdateSys();
        public Game(Form form)
        {

            GameForm = new FormControl(form);
            Snake = new SnakePlayer(Map);
            Fruit = new Food(Map);
            Fruit1 = new FoodRed(Map);
            Fruit2 = new FoodBlue(Map);

    }
        public void GameStart(int value)
        {
            GameForm.SetForm(Map, Snake);
            UpdaterSnake.Init(200, UpdateSnake);
            UpdaterRools.Init(1, UpdateRools);
            Map.GenerateMap(GameForm);
            switch(value){
                case 0:
                    Fruit.GenerateNewLocation(GameForm, Map);
                    break;
                case 1:
                    Fruit.GenerateNewLocation(GameForm, Map);
                    Fruit1.GenerateNewLocation(GameForm, Map);
                    break;
                case 2:
                    Fruit.GenerateNewLocation(GameForm, Map);
                    Fruit1.GenerateNewLocation(GameForm, Map);
                    Fruit2.GenerateNewLocation(GameForm, Map);
                    break;
            }
        }
        public void SetSize(int value)
        {
            Map.ChangeSize(value);
        }
        public void SetDiff(int value)
        {
            Rools.SetDifficulty(value);
        }
       private void UpdateSnake(Object myObject, EventArgs eventArgs)
       {
            if (Snake.Eat(GameForm, Fruit, Map) || Snake.Eat(GameForm, Fruit1, Map) || Snake.Eat(GameForm, Fruit2, Map))
            {
                GameForm.SetHighScore(Snake);
                Rools.DifficultyMinus(UpdaterSnake);
            }
            Snake.Move(Map);
        }
       private void UpdateRools(Object myObject, EventArgs eventArgs)
       {
            Rools.CheckBorders(Snake,Map);
            if(Rools.itSelf(GameForm, Snake))
               Rools.DifficultyPlus(UpdaterSnake);
            GameForm.SetScore(Snake, UpdaterSnake);
       }
    }
}
