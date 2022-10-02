using System;
using System.Collections.Generic;
using System.Linq;

namespace _19._Battle_Points
{
    public class Enemy
    {
        public Enemy(int energy, int battlePoints)
        {
            Energy = energy;
            BattlePoints = battlePoints;
        }

        public int Energy { get; set; }

        public int BattlePoints { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var enemies = new List<Enemy>();

            var energy = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var battlePoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < energy.Length; i++)
            {
                var currentEnergy = energy[i];
                var currentBattlePoints = battlePoints[i];

                enemies.Add(new Enemy(currentEnergy, currentBattlePoints));
            }

            var initialEnergyPoints = int.Parse(Console.ReadLine());

            var table = new int[enemies.Count + 1, initialEnergyPoints + 1];

            for (int row = 1; row < table.GetLength(0); row++)
            {
                var enemy = enemies[row - 1];

                for (int capacity = 1; capacity < table.GetLength(1); capacity++)
                {
                    if (capacity < enemy.Energy)
                    {
                        table[row, capacity] = table[row - 1, capacity];
                    }
                    else
                    {
                        table[row, capacity] = Math.Max(table[row - 1, capacity],
                                                       table[row - 1, capacity - enemy.Energy] + enemy.BattlePoints);
                    }
                }
            }

            Console.WriteLine(table[enemies.Count, initialEnergyPoints]);
        }
    }
}
