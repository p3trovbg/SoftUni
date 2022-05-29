using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.Models.Interfaces
{
    interface IPlayer
    {
        string Name { get; set; }
        void UpdatePoints();
        void IncreasePoints();
        void DecreasePoints();
        void SetName();
    }
}
