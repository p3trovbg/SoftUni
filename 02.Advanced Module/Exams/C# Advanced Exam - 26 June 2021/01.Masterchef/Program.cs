using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Masterchef
{
    class Program
    {
        static void Main(string[] args)
        {

            var ingredients = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            var freshness = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int dippingSauce = 0, greenSalad = 0, chocolateCake = 0, lobster = 0;
           
            while (ingredients.Count > 0 && freshness.Count > 0)
            {
                int currentIngredients = ingredients.Peek();
                int currentFreshness = freshness.Peek();
                if (currentIngredients == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                int totalFreshness = currentFreshness * currentIngredients;

                bool flag = false;
                switch (totalFreshness)
                {
                    case 150:
                        dippingSauce++;
                        flag = true;
                        break;
                    case 250:
                        greenSalad++;
                        flag = true;
                        break;
                    case 300:
                        chocolateCake++;
                        flag = true;
                        break;
                    case 400:
                        lobster++;
                        flag = true;
                        break;
                }
                if (flag)
                {
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else
                {
                    freshness.Pop();
                    ingredients.Dequeue();
                    ingredients.Enqueue(currentIngredients +=5);
                }
            }
            

            if (dippingSauce > 0 && greenSalad > 0 && chocolateCake > 0 && lobster > 0)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
                Result(dippingSauce, greenSalad, chocolateCake, lobster);
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");
                if (ingredients.Sum() > 0)
                {
                    Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
                }
                Result(dippingSauce, greenSalad, chocolateCake, lobster);
            }
        }

        private static void Result(int dippingSauce, int greenSalad, int chocolateCake, int lobster)
        {
            if (chocolateCake > 0)
            {
                Console.WriteLine($"# Chocolate cake --> {chocolateCake}");
            }
            if (dippingSauce > 0)
            {
                Console.WriteLine($"# Dipping sauce --> {dippingSauce}");
            }
            if (greenSalad > 0)
            {
                Console.WriteLine($"# Green salad --> {greenSalad}");
            }
            if (lobster > 0)
            {
                Console.WriteLine($"# Lobster --> {lobster}");
            }
        }
    }
}
