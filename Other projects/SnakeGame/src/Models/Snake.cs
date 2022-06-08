using SnakeGame.IO;
using SnakeGame.Messages;
using SnakeGame.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Versioning;

namespace SnakeGame.Models
{
    [SupportedOSPlatform("windows")]
    public class Snake : ISnake
    {
        private const int InitialSnakeHealth = 10;
        private const int left = 0, right = 1, up = 2, down = 3;
        private Writer writer;
        private Reader reader;
        private ICoordinates[] directions = new Coordinates[]
            {
                new Coordinates(0, -1), //left
                new Coordinates(0, 1), // right
                new Coordinates(-1, 0), // up
                new Coordinates(1, 0), // down
            };
        public Snake()
        {
            writer = new Writer();
            reader = new Reader();
            writer.SetCursorPosition(1, 1);
            SnakeElements = new Queue<ICoordinates>();
            SnakeDirection = right;
            SnakeSpeed = 60;

            //Initial generate ten snake elements.
            for (int i = 1; i < InitialSnakeHealth; i++)
            {
                SnakeElements.Enqueue(new Coordinates(1, i));
            }

        }
        public int SnakeDirection { get; set; }
        public Queue<ICoordinates> SnakeElements { get; set; }
        public bool IsDead => SnakeElements.Count == 0;
        public double SnakeSpeed { get; set; }
        public ICoordinates SnakeHead => SnakeElements.Last();
        public ICoordinates NextDirection => directions[SnakeDirection];
        public ICoordinates NextSnakeHead => new Coordinates
                (
                SnakeHead.Row + NextDirection.Row,
                SnakeHead.Col + NextDirection.Col
                );
        public void MoveSnake()
        {
            if (Console.KeyAvailable)
            {
                var input = reader.ReadKey();
                //left
                if (input.Key == ConsoleKey.LeftArrow && SnakeDirection != right)
                {
                    SnakeDirection = left;
                }
                //right
                else if (input.Key == ConsoleKey.RightArrow && SnakeDirection != left)
                {
                    SnakeDirection = right;
                }
                //up
                else if (input.Key == ConsoleKey.UpArrow && SnakeDirection != down)
                {
                    SnakeDirection = up;
                }
                //down
                else if (input.Key == ConsoleKey.DownArrow && SnakeDirection != up)
                {
                    SnakeDirection = down;
                }
            }

            SnakeSpeed -= 0.01;
        }
        public void IncreaseSnake()
        {
            writer.SetCursorPosition(SnakeHead.Col, SnakeHead.Row);
            writer.Write("o");
            SnakeElements.Enqueue(NextSnakeHead);
            if (IsOutside())
            {
                throw new ArgumentOutOfRangeException(ExceptionMessages.SnakeOutOfRange);
            }
            IsEatYourself();
            writer.SetCursorPosition(NextSnakeHead.Col, NextSnakeHead.Row);

        }
        public void DecreaseSnake()
        {
            writer.SetCursorPosition(NextSnakeHead.Col, NextSnakeHead.Row);
            ICoordinates queueSnake = SnakeElements.Dequeue();
            if (IsDead)
            {
                //GameOver(snake.Count);

                return;
            }
            writer.SetCursorPosition(queueSnake.Col, queueSnake.Row);
            writer.Write(' ');
        }
        public ICoordinates Eat(List<ICoordinates> foods)
        {
            var anyFood = foods.FirstOrDefault(x => x.Row == SnakeHead.Row && x.Col == SnakeHead.Col);   
            if(anyFood != null)
            {
                SnakeElements.Enqueue(NextSnakeHead);
                writer.SetCursorPosition(anyFood.Col, anyFood.Row);
                writer.Write("o");
                SnakeSpeed -= 0.10;
                return anyFood;
            }
            return null;
        }
        public ICoordinates Hit(List<ICoordinates> obstacles)
        {
            var anyObstacles = obstacles.FirstOrDefault(x => x.Row == SnakeHead.Row && x.Col == SnakeHead.Col);
            if (anyObstacles != null)
            {
                DecreaseSnake();
                DecreaseSnake();
                SnakeSpeed -= 0.10;
                return anyObstacles;
            }
            return null;
        }
        private bool IsOutside()
        {
            return NextSnakeHead.Row < 0 ||
                NextSnakeHead.Col < 0 ||
                NextSnakeHead.Row > Settings.HeightGame ||
                NextSnakeHead.Col > Settings.WidthGame;
        }
        private void IsEatYourself()
        {
            if (SnakeElements.Any(x => x.Col == NextSnakeHead.Col && x.Row == NextSnakeHead.Row)) 
            {
                throw new ArgumentException(ExceptionMessages.SnakeEatYourself);
            }
        }
    }
}
