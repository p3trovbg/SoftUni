using SnakeGame.Core;
using SnakeGame.Core.Interfaces;
using System;
using System.Runtime.Versioning;

namespace SnakeGame
{
    [SupportedOSPlatform("windows")]
    class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Menu();         
        }
    }
}
