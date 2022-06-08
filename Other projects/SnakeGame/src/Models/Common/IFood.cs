using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models.Interfaces
{
    public interface IFood
    {
        List<ICoordinates> FoodCoordinates { get; set; }
        void GenerateFood(Queue<ICoordinates> snake, List<ICoordinates> obstacles);
    }
}
