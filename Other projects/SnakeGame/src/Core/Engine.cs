using SnakeGame.Core.Common;
using SnakeGame.Core.Interfaces;
using SnakeGame.IO;
using SnakeGame.IO.Interfaces;
using SnakeGame.Models;
using SnakeGame.Models.Interfaces;
using System;
using System.Runtime.Versioning;
using System.Threading;

namespace SnakeGame.Core
{
    [SupportedOSPlatform("windows")]
    class Engine : IEngine
    {
        private IWriter writer;
        private IReader reader;
        private ICatcher catcher;
        private IPlayer player;
        private IMusic music;
        public Engine()
        {
            writer = new Writer();
            reader = new Reader();
            catcher = new Catcher();
            music = new Music();
            music.PlayMusic();
        }

        public void Menu()
        {
            player = new Player();
            var settings = new Settings();
            settings.SetSettings();
            settings.DrawFrame();
            settings.DrawMenu();     
            var input = reader.ReadKey();
            if (input.Key == ConsoleKey.F1)
            {
                writer.Clear();
                settings.SetSettings();
                settings.DrawFrame();
                player.SetName();
                player.UpdatePoints();
                Run();
            }
            else if (input.Key == ConsoleKey.F9)
            {
                return;
            }
            else
            {
                Menu();
            }
        }

        public void Run()
        {
            var snake = new Snake();
            var foods = new Food();
            var obstacles = new Obstacle();
            InitialFoodsAndOstacle(foods, obstacles, snake);

            while (true)
            {
                if(foods.GetAllFoods().Count < 2 || obstacles.GetAllObstacles().Count < 2)
                {
                    InitialFoodsAndOstacle(foods, obstacles, snake);
                }
                try
                {
                    snake.MoveSnake();
                    snake.IncreaseSnake();
                    snake.DecreaseSnake();
                    var food = snake.Eat(foods.GetAllFoods());
                    if (food != null)
                    {

                        foods.FoodCoordinates.Remove(food);
                        foods.GenerateFood(snake.SnakeElements, obstacles.GetAllObstacles());
                        player.IncreasePoints();
                        player.UpdatePoints();
                        continue;
                    }

                    var obstacle = snake.Hit(obstacles.GetAllObstacles());
                    if(obstacle != null)
                    {
                        obstacles.RemoveObstacle(obstacle);
                        obstacles.GenerateObstacle(snake.SnakeElements, foods.GetAllFoods());
                        player.DecreasePoints();
                        player.UpdatePoints();
                    }
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1200);
                    var answer = catcher.ErrorHandling(ex.Message);
                    if (answer == 1)
                    {
                        Menu();
                    }
                    else
                    {
                        Menu();
                    }
                }
                Thread.Sleep((int)snake.SnakeSpeed);
            }
        }

        private void InitialFoodsAndOstacle(Food foods, Obstacle obstacles, Snake snake)
        {
            for (int i = 0; i < 2; i++)
            {
                foods.GenerateFood(snake.SnakeElements, obstacles.GetAllObstacles());
                obstacles.GenerateObstacle(snake.SnakeElements, foods.GetAllFoods());
            }
        }
    }
}
