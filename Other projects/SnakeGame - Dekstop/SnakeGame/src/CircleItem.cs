using SnakeGame.src.Commons;

namespace SnakeGame
{
    public class CircleItem : ICircleItem
    {
        public CircleItem(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }
    }
}
