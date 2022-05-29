using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _04._Mixed_up_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> second = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToList();

            //Взимаме по - малкия списък за лимит в цикъла.
            //Взимаме и двете числа от по - големия списък.
            int limit = 0;
            List<int> range = new List<int>();
            if (first.Count > second.Count)
            {
                range = first.GetRange(first.Count - 2, 2);
                limit = second.Count;
            }
            else
            {
                range = second.GetRange(second.Count - 2, 2);
                limit = first.Count;
            }
            //Смесваме двата масива
            List<int> total = new List<int>(first.Count + second.Count);
            for (int i = 0; i < limit; i++)
            {
                total.Add(first[i]);
                total.Add(second[i]);
            }
            //Добавяме в интервала от двете числа
            List<int> result = new List<int>();
            for (int i = 0; i < total.Count; i++)
            {
                int up = range.Max();
                int down = range.Min();
                int currentNumber = total[i];
                if (currentNumber >= up || currentNumber <= down)
                {
                    continue;
                }
                else
                {
                    result.Add(currentNumber);
                }
            }
            //Сортираме във възходящ ред и изнасяме поредицата.
            result.Sort();
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
