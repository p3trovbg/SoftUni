
namespace SnakeGame.IO
{
    public interface IWriter
    {
        void WriteLine(string input);
        void Write(string input);
        void Write(char input);
        void Clear();
        void SetCursorPosition(int left, int top);
    }
}
