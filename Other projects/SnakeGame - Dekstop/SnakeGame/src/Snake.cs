using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SnakeGame.src
{
    public class Snake : ISnake
    {
        private const int X = 10;
        private const int Y = 5;
        public Snake()
        {
            Direction = Directions.Right;
            SnakeItems = new List<CircleItem>();
            for (int i = 0; i < 10; i++)
            {
                SnakeItems.Add(new CircleItem(X, Y));
            }
        }
        public List<CircleItem> SnakeItems { get; set; }
        public Directions Direction { get; set; }
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void IsOutside()
        {
            
            throw new NotImplementedException();
        }

        public void Move(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && Direction != Directions.Right)
            {
                Direction = Directions.Left;
            }
            if (e.KeyCode == Keys.Right && Direction != Directions.Left)
            {
                Direction = Directions.Right;
            }
            if (e.KeyCode == Keys.Up && Direction != Directions.Down)
            {
                Direction = Directions.Up;
            }
            if (e.KeyCode == Keys.Down && Direction != Directions.Up)
            {
                Direction = Directions.Down;
            }
        }
    }
}
