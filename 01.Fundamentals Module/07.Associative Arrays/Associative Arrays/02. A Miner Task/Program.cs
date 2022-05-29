using System;
using System.Collections.Generic;

namespace _02._A_Miner_Task
{
    class Program
    {
        static void Main(string[] args)
        {

            var res = new Dictionary<string, int>();
            while (true)
            {
                string resource = Console.ReadLine();
                if (resource == "stop")
                {
                    break;
                }
                int quantity = int.Parse(Console.ReadLine());

                if (res.ContainsKey(resource))
                {
                    res[resource] += quantity;
                }
                else
                {
                    res.Add(resource, quantity);
                }
            }

            foreach (var items in res)
            {
                Console.WriteLine($"{items.Key} -> {items.Value}");
            }
        }
    }
}
