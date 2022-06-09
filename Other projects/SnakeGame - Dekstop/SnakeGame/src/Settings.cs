using SnakeGame.src;
using SnakeGame.src.Commons;

namespace SnakeGame
{
    class Settings : ISettings
    {
        public Settings()
        {
            Width = 16;
            Height = 16;
        }

        public Settings(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        
        public int MaxWidth { get; set; }
        public int MaxHeight { get; set; }
        public Directions Direction { get; set; }
    }
}
