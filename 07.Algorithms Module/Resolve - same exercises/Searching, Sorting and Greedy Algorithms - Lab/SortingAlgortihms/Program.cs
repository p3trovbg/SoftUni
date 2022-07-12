using System;
using System.Linq;

namespace SortingAlgortihms
{
    public class Program
    {
        private static int[] elements;
        static void Main(string[] args)
        {
            elements = Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();


            //Selection sort -> SelectionSort(elements);
            BubbleSort(elements);
            Console.WriteLine(String.Join(" ", elements));
        }

        private static void BubbleSort(int[] elements)
        {
            throw new NotImplementedException();
        }

        private static void SelectionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length - 1; i++)
            {
                var minIdx = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    var minElement = elements[minIdx];
                    var nextElement = elements[j];

                    if (minElement > nextElement)
                    {
                        minIdx = j;
                    }
                }

                Swap(i, minIdx);
            }
        }

        private static void Swap(int firstIdx, int minIdx)
        {
            var temp = elements[minIdx];
            elements[minIdx] = elements[firstIdx];
            elements[firstIdx] = temp;
        }
    }
}
