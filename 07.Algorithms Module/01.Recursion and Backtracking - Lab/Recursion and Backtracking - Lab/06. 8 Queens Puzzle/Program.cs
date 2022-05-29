using System;
using System.Collections.Generic;

namespace _06._8_Queens_Puzzle
{
    class Program
    {
        private static HashSet<int> attackedRows = new HashSet<int>();
        private static HashSet<int> attackedCols = new HashSet<int>();
        private static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        private static HashSet<int> attackedRightDiagonals = new HashSet<int>();
        static void Main(string[] args)
        {
            var board = new bool[8, 8];

            FindAllQueens(board, 0);
        }

        private static void FindAllQueens(bool[,] board, int row)
        {
            if(row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPutQuuen(row, col))
                {
                    board[row, col] = true;
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attackedLeftDiagonals.Add(row - col);
                    attackedRightDiagonals.Add(row + col);
                    
                    FindAllQueens(board, row + 1);

                    board[row, col] = false;
                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attackedLeftDiagonals.Remove(row - col);
                    attackedRightDiagonals.Remove(row + col);
                }
            }
        }

        private static bool CanPutQuuen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
                   !attackedCols.Contains(col) &&
                   !attackedLeftDiagonals.Contains(row - col) &&
                   !attackedRightDiagonals.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");

                    }
                }

                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
