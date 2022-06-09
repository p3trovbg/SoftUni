using SnakeGame.src.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.src
{
    class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
}
