using System;
using System.Collections.Generic;

namespace Тест
{
    public class Window
    {
        public Window()
        {
            WindowCounts = new List<int>();
        }
        public List<int> WindowCounts { get; set; }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int[] ints = new[] { 1, 2, 3 };

            var win = new Window();

            win.WindowCounts = ints;
        }
    }
}
