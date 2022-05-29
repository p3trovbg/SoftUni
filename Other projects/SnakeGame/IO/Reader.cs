using System;

namespace SnakeGame.IO
{
    public class Reader : IReader

    {
        public ConsoleKeyInfo ReadKey()
        {
            return Console.ReadKey();
        }

        public string ReadLine()
        {
            return Console.ReadLine();
        }

    }
}
