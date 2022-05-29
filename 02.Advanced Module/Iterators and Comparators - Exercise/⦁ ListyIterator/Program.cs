using System;
using System.Linq;
using System.Collections.Generic;
namespace ListIterator
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] data = Console.ReadLine()
                  .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var collection = new ListyIterator<string>(data[1..]);
            while ((data[0] = Console.ReadLine()) != "END")
            {
                switch (data[0])
                {
                    case "HasNext":
                        Console.WriteLine(collection.HasNext());
                        break;
                    case "Move":
                        Console.WriteLine(collection.Move());
                        break;
                    case "Print":
                        collection.Print();
                        break;
                    case "PrintAll":
                        collection.PrintAll();
                        break;
                }
            }
        }
    }
}
