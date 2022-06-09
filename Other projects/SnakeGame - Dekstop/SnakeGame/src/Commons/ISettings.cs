using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame.src.Commons
{
    public interface ISettings
    {
        int Width { get; set; }
        int Height { get; set; }
        int MaxWidth { get; set; }
        int MaxHeight { get; set; }
    }
}
