using System;

namespace SnakeGame.IO
{
    public class Writer : IWriter
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void SetCursorPosition(int left, int top)
        {
            Console.SetCursorPosition(left, top);
        }

        public void Write(string input)
        {
            Console.Write(input);
        }

        public void Write(char input)
        {
            Console.Write(input);
        }

        public void WriteLine(string input)
        {
            Console.WriteLine(input);
        }

        public static implicit operator Writer(Reader v)
        {
            throw new NotImplementedException();
        }
    }
}
