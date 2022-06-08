using SnakeGame.IO;
using SnakeGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;

namespace SnakeGame.Models
{
    [SupportedOSPlatform("windows")]
    public class Food : IFood
    {
        private Writer writer;
        private int row = Settings.HeightGame;
        private int col = Settings.WidthGame;
        private ICoordinates food;
        
        public Food()
        {
            writer = new Writer();
            FoodCoordinates = new List<ICoordinates>();
        }

        public List<ICoordinates> FoodCoordinates { get; set; }

        public void GenerateFood(Queue<ICoordinates> snake, List<ICoordinates> obstacles)
        {
            Random elementFood = new Random();
            do
            {
                food = new Coordinates(elementFood.Next(1, row - 2), elementFood.Next(1, col - 2));
            }
            while (snake.Any(x => x.Col == food.Col && x.Row == food.Row) &&
                   obstacles.Any(x => x.Col == food.Col && x.Row == food.Row));

            FoodCoordinates.Add(food);
            writer.SetCursorPosition(food.Col, food.Row);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            writer.Write("@");
            Console.ResetColor();
        }

        public List<ICoordinates> GetAllFoods() => FoodCoordinates;

        
    }
}
