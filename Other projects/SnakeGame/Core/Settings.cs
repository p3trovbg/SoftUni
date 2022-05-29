using SnakeGame.Core.Interfaces;
using SnakeGame.IO;
using System;
using System.Runtime.Versioning;
using System.Text;

namespace SnakeGame
{
    [SupportedOSPlatform("windows")]
    public class Settings : ISettings
    {
        public const int HeightConsole = 40;
        public const int WidthConsole = 110;
        public const int HeightGame = 35;
        public const int WidthGame = 110;
        private const int BufferHeight = 40;
        private const int BufferWidth = 110;
        private const bool CursorVisible = false;
        private const string TitleGame = "SnakeGame v1.0";
        private Writer writer;
        private int score = 0;


        public void SetSettings()
        {
            writer = new Writer();
            Console.OutputEncoding = Encoding.Unicode;
            Console.WindowHeight = HeightConsole;
            Console.WindowWidth = WidthConsole;
            Console.BufferHeight = BufferHeight;
            Console.BufferWidth = BufferWidth;
            writer.SetCursorPosition(0, 0);
            Console.CursorVisible = CursorVisible;
            Console.Title = TitleGame;
        }
        public void DrawFrame()
        {
            int row = HeightConsole;
            int col = WidthConsole;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 1 ||
                       i == row - 1 ||
                       j == 0 ||
                       j == col - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        writer.Write('*');
                    }
                    else
                    {
                        writer.Write(' ');
                    }
                }
            }


            writer.SetCursorPosition(0, HeightGame);
            for (int i = 0; i < WidthGame; i++)
            {
                writer.Write('*');
            }
            Console.ResetColor();
        }
        public void DrawMenu()
        {
            writer.SetCursorPosition(5, 5);
            writer.WriteLine("Press F1 to start new game");
            writer.SetCursorPosition(5, 6);
            writer.WriteLine("Press F9 to exit");
            writer.SetCursorPosition(5, 7);
            writer.WriteLine("Game description: ");
            writer.SetCursorPosition(5, 8);
            writer.WriteLine("@ - means food");
            writer.SetCursorPosition(5, 9);
            writer.WriteLine("X - means obstacle");
            writer.SetCursorPosition(5, 10);
            writer.WriteLine("If you go through @, your snake will be with 1 element more.");
            writer.SetCursorPosition(5, 11);
            writer.WriteLine("If you go through X, your snake will be with 2 element less.");
            writer.SetCursorPosition(5, 12);
            writer.WriteLine("Speed on snake will increase every time when you change direction on snake, either");
            writer.SetCursorPosition(5, 13);
            writer.WriteLine("you go through @ or X");
            writer.SetCursorPosition(5, 14);
            writer.WriteLine("You will start with 100 points, whenever you go through food or an obstacle, ");
            writer.SetCursorPosition(5, 15);
            writer.WriteLine("your points will change with 10 more or less.");

            writer.SetCursorPosition(90, 37);
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            writer.WriteLine("By: George Petrov");
        }
    }
}
