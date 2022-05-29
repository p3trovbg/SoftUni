using System;
using System.Linq;

namespace _01._Randomize_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            var myList = Console.ReadLine()
                .Split()
                .ToList();

            Random rnd = new Random();
            for (int i = 0; i < myList.Count; i++)
            {
                string word = myList[i];
                int index = rnd.Next(0, myList.Count );
                myList.Remove(word);
                myList.Insert(index ,word);
            }

            foreach (var item in myList)
            {
                Console.WriteLine(item);
            }
        }
    }
}
