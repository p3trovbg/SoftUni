
using SnakeGame.IO;
using SnakeGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;

namespace SnakeGame.Models
{
    [SupportedOSPlatform("windows")]
    public class Obstacle : IObstacle
    {
        private Writer writer = new Writer();
        private int row = Settings.HeightGame;
        private int col = Settings.WidthGame;
        private ICoordinates obstacle;
        private List<ICoordinates> obstaclesCoordinates;

        public Obstacle()
        {
            obstaclesCoordinates = new List<ICoordinates>();
        }

        public List<ICoordinates> GetAllObstacles() => obstaclesCoordinates;

        public void GenerateObstacle(Queue<ICoordinates> snake, List<ICoordinates> foods)
        {
            Random obstacleElement = new Random();
            do
            {
                obstacle = new Coordinates(obstacleElement.Next(1, row - 2), obstacleElement.Next(1, col - 2));
            }
            while (snake.Any(x => x.Col == obstacle.Col && x.Row == obstacle.Row) &&
            foods.Any(x => x.Col == obstacle.Col && x.Row == obstacle.Row));

            obstaclesCoordinates.Add(obstacle);
            writer.SetCursorPosition(obstacle.Col, obstacle.Row);
            Console.ForegroundColor = ConsoleColor.Cyan;
            writer.Write("X");
            Console.ResetColor();
        }

        public void RemoveObstacle(ICoordinates obstacle)
        {
            obstaclesCoordinates.Remove(obstacle);
        }
    }
}
