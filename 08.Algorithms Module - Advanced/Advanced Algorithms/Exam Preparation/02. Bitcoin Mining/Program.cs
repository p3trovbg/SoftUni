using System;
using System.Collections.Generic;

namespace _02._Bitcoin_Mining
{
    public class Transaction
    {
        public string Hash { get; set; }

        public int Size { get; set; }

        public int Fees { get; set; }

        public string From { get; set; }

        public string To { get; set; }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            int transactionCount = int.Parse(Console.ReadLine());
            var transactions = new List<Transaction>();

            double minCapacity = double.PositiveInfinity;
            for (int i = 0; i < transactionCount; i++)
            {
                var transactionData = Console.ReadLine().Split();
                transactions.Add(new Transaction
                {
                    Hash = transactionData[0],
                    Size = int.Parse(transactionData[1]),
                    Fees = int.Parse(transactionData[2]),
                    From = transactionData[3],
                    To = transactionData[4]
                });

                if (transactions[i].Size < minCapacity)
                {
                    minCapacity = transactions[i].Size;
                }
            }

            int maxCapacity = 1_000_000;


            var table = new int[transactions.Count + 1, maxCapacity + 1];

            for (int row = 1; row < table.GetLength(0); row++)
            {
                var currentTransaction = transactions[row - 1];

                //Here, we should start by the min capacity, which we find out above.
                //This will decrease the empty iterations.
                for (int capacity = (int)minCapacity; capacity < table.GetLength(1); capacity++)
                {
                    if(capacity < currentTransaction.Size)
                    {
                        table[row, capacity] = table[row - 1, capacity];
                    }
                    else
                    {
                        table[row, capacity] = Math.Max(table[row - 1, capacity],
                                                        table[row - 1, capacity - currentTransaction.Size] + currentTransaction.Fees);
                    }
                }
            }

            int currentRow = table.GetLength(0) - 1;
            int col = table.GetLength(1) - 1;
            var selectedItems = new List<string>();
            var totalSize = 0;

            while (currentRow > 0 && col > 0)
            {
                if (table[currentRow, col] != table[currentRow - 1, col])
                {
                    var transaction = transactions[currentRow - 1];

                    selectedItems.Add(transaction.Hash);
                    totalSize += transaction.Size;

                    col -= transaction.Size;
                }

                currentRow--;
            }

            Console.WriteLine($"Total Size: {totalSize}");
            Console.WriteLine($"Total Fees: {table[transactionCount, maxCapacity]}");
            foreach (var transaction in selectedItems)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
