using SnakeGame.Core;
using SnakeGame.IO.Interfaces;
using SnakeGame.Messages;
using System;
using System.Runtime.Versioning;

namespace SnakeGame.IO
{
    [SupportedOSPlatform("windows")]
    class Catcher : ICatcher
    {
        private Reader reader;
        private Writer writer;
        private const int colPositionMessage = 30;
        private const int rowPositionMessage = 20;
        public Catcher()
        {
            reader = new Reader();
            writer = new Writer();
        }
        public int ErrorHandling(string message)
        {
            if(message.Contains(ExceptionMessages.SnakeOutOfRange))
            {
                SetMessegePosition(ExceptionMessages.SnakeOutOfRange, OutputMessages.StartNewGame);
                return ClickHandling();
            }
            else if (message.Contains(ExceptionMessages.SnakeEatYourself))
            {
                SetMessegePosition(ExceptionMessages.SnakeEatYourself, OutputMessages.StartNewGame);
                return ClickHandling();
            }

            return default;
        }


        private void SetMessegePosition(string exceptionMessage, string outputMessage)
        {
            writer.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            writer.SetCursorPosition(colPositionMessage, rowPositionMessage);
            writer.Write(exceptionMessage);
            writer.SetCursorPosition(colPositionMessage, rowPositionMessage + 1);
            writer.WriteLine(outputMessage);
        }

        private int ClickHandling()
        {
            var button = reader.ReadKey();
            if (button.Key == ConsoleKey.Spacebar)
            {
                return 1;
            }
            return 0;
        }
    }
}
