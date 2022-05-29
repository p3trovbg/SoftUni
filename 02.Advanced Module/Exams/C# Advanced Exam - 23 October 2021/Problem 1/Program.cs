using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var vowelsCollection = new Queue<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());
            var consonantsCollection = new Stack<char>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(char.Parse)
                .ToArray());

            Dictionary<string, SortedSet<char>> foods = new Dictionary<string, SortedSet<char>>()
            {
                {"pear", new SortedSet<char>()},
                {"flour", new SortedSet<char>()},
                {"pork", new SortedSet<char>()},
                {"olive", new SortedSet<char>()}
            };
            List<string> findFood = new List<string>();           
            while (consonantsCollection.Count > 0)
            {
                char vowel = vowelsCollection.Dequeue();
                char cons = consonantsCollection.Pop();
                vowelsCollection.Enqueue(vowel);
                foreach (var food in foods)
                {
                    if (food.Key.Contains(vowel))
                    {
                        foods[food.Key].Add(vowel);
                    }
                    if (food.Key.Contains(cons))
                    {
                        foods[food.Key].Add(cons);
                    }
                    
                    if (food.Key == "pear" && foods[food.Key].Count == 4 && !findFood.Contains(food.Key))
                    {
                        findFood.Add(food.Key);
                    }
                    else if (food.Key == "flour" && foods[food.Key].Count == 5 && !findFood.Contains(food.Key))
                    {
                        findFood.Add(food.Key);
                    }
                    else if (food.Key == "pork" && foods[food.Key].Count == 4 && !findFood.Contains(food.Key))
                    {
                        findFood.Add(food.Key);
                    }
                    else if (food.Key == "olive" && foods[food.Key].Count == 5 && !findFood.Contains(food.Key))
                    {
                        findFood.Add(food.Key);
                    }

                }
            }          
             
            Console.WriteLine($"Words found: {findFood.Count}");
            foreach (var item in findFood)
            {
                Console.WriteLine(item);
            }
        }
    }
}
