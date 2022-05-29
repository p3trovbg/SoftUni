using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    class Program
    {
        static void Main(string[] args)
        {
            int priceBullet = int.Parse(Console.ReadLine());
            int sizeGunBarrel = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int firedCartridges = bullets.Length;

            int[] locks = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            int valueIntelligence = int.Parse(Console.ReadLine());

            var stackBullets = new Stack<int>(bullets);
            var stackLocks = new Stack<int>(locks);
            int count = 0;



            while (stackLocks.Count > 0 && stackBullets.Count > 0)
            {
                int currBullet = stackBullets.Pop();
                int currLock = stackLocks.Peek();
                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    stackLocks.Pop();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                count++;
                if (count == sizeGunBarrel)
                {
                    Console.WriteLine("Reloading!");
                    count = 0;
                }
            }

            if (stackBullets.Count >= 0)
            {
                int price = (firedCartridges - stackBullets.Count) * priceBullet;
                Console.WriteLine($"{stackBullets.Count} bullets left. Earned ${valueIntelligence - price}");
            }
            else if (stackLocks.Count > 0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {stackLocks.Count}");
            }

        }
    }
}
