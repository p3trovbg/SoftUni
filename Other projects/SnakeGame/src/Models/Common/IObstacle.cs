
using System.Collections.Generic;

namespace SnakeGame.Models.Interfaces
{
    public interface IObstacle
    {
        List<ICoordinates> GetAllObstacles();
        void RemoveObstacle(ICoordinates obstacle);
        void GenerateObstacle(Queue<ICoordinates> snake, List<ICoordinates> foods);
    }
}
