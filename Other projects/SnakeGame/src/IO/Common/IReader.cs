using System;

namespace SnakeGame.IO
{
    public interface IReader
    {
        string ReadLine();
        ConsoleKeyInfo ReadKey();
    }
}
