using System.Collections.Generic;
using System.Windows.Forms;

namespace SnakeGame.src
{
    public interface ISnake
    {
        List<CircleItem> SnakeItems { get; set; }
        Directions Direction { get; set; }
        void Eat();
        void Move(KeyEventArgs e);

        void IsOutside();
        
    }
}
