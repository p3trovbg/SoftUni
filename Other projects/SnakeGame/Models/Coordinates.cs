using SnakeGame.Models.Interfaces;

namespace SnakeGame.Models
{
    public class Coordinates : ICoordinates
    {
        public Coordinates(int row, int col)
        {
            Row = row;
            Col = col;
        }

        public int Row { get; set; }
        public int Col { get; set; }
    }
}
