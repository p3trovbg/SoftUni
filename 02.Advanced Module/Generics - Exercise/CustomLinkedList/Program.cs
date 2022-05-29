using System;

namespace CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMethod(1);
        }

        static void MyMethod(int s)
        {
            while (s <= 1000)
            {
                Console.WriteLine(s++);
            }
        }
    }
}
