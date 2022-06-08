using SnakeGame.IO;
using SnakeGame.Models.Interfaces;
using System;

namespace SnakeGame.Models
{
    class Player : IPlayer
    {
        private int points = 100;
        private Writer writer;
        private Reader reader;
        public Player()
        {
            writer = new Writer();
            reader = new Reader();
        }
        
        public string Name { get; set; }

        public void UpdatePoints()
        {
            writer.SetCursorPosition(2, 37);
            writer.Write($"Score: {points} points");
        }
        public void DecreasePoints()
        {
            points -= 20;
        }
        public void IncreasePoints()
        {
            points += 10;
        }

        public void SetName()
        {
            writer.SetCursorPosition(2, 36);
            writer.Write("Your nickname:");
            Name = reader.ReadLine();
        }
    }
}
