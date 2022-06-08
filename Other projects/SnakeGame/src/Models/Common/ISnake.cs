
using System.Collections.Generic;

namespace SnakeGame.Models.Interfaces
{
    public interface ISnake
    {
        Queue<ICoordinates> SnakeElements { get; set; }
        ICoordinates SnakeHead { get; }
        ICoordinates NextDirection { get; }
        ICoordinates NextSnakeHead { get; }
        int SnakeDirection { get; set; }
        double SnakeSpeed { get; set; }
        void MoveSnake();
        void IncreaseSnake();
        void DecreaseSnake();
        bool IsDead { get; }
        ICoordinates Eat(List<ICoordinates> foods);
        ICoordinates Hit(List<ICoordinates> obstacles);

    }
}
