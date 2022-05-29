using System;
using System.Linq;

namespace _02.Survivor
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            char[][] beach = new char[rows][];
            for (int i = 0; i < beach.Length; i++)
            {
                char[] tokens = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[i] = tokens;
            }
            int meTokens = 0;
            int opponentTokens = 0;
            string input;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] operations = input.Split();
                string command = operations[0];
                if (command == "Find")
                {
                    int rowI = int.Parse(operations[1]);
                    int colI = int.Parse(operations[2]);
                    if (Exist(beach, rowI, colI))
                    {
                        beach[rowI][colI] = '-';
                        meTokens++;
                    }
                }
                else if (command == "Opponent")
                {
                    int rowOpponent = int.Parse(operations[1]);
                    int colOpponent = int.Parse(operations[2]);
                    string direction = operations[3];
                    if (Exist(beach, rowOpponent, colOpponent))
                    {
                        opponentTokens++;
                        beach[rowOpponent][colOpponent] = '-';
                        switch (direction)
                        {
                            case "up":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (Exist(beach, rowOpponent - i, colOpponent))
                                    {
                                        beach[rowOpponent - i][colOpponent] = '-';
                                        opponentTokens++;
                                    }
                                }
                                break;
                            case "down":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (Exist(beach, rowOpponent + i, colOpponent))
                                    {
                                        beach[rowOpponent + i][colOpponent] = '-';
                                        opponentTokens++;
                                    }
                                }
                                break;
                            case "left":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (Exist(beach, rowOpponent, colOpponent - i))
                                    {
                                        beach[rowOpponent][colOpponent - i] = '-';
                                        opponentTokens++;
                                    }
                                }
                                break;
                            case "right":
                                for (int i = 1; i <= 3; i++)
                                {
                                    if (Exist(beach, rowOpponent, colOpponent + i))
                                    {
                                        beach[rowOpponent][colOpponent + i] = '-';
                                        opponentTokens++;
                                    }
                                }
                                break;
                        }
                    }
                }               
            }


            for (int i = 0; i < beach.Length; i++)
            {
                Console.WriteLine(string.Join(' ', beach[i]));
            }
            Console.WriteLine($"Collected tokens: {meTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");
        }
        private static bool Exist(char[][] beach, int row, int col)
        {
            return row >= 0 && row < beach.Length &&
                   col >= 0 && col < beach[row].Length &&
                   beach[row][col] == 'T';
        }
    }
}
