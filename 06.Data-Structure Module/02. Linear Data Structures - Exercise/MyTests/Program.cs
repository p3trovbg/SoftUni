using Problem03.ReversedList;
using System;

namespace MyTests
{
    public class Program
    {
        static void Main(string[] args)
        {
            var list = new ReversedList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            Console.WriteLine(list[2]);
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
