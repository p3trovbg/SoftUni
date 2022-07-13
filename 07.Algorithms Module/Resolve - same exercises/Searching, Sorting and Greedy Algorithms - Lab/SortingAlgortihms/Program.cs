﻿using System;
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


            //Selection sort algorithm -> SelectionSort(elements);
            //Bubble sort algorithm -> BubbleSort(elements);
            //Insertion sort algorithm -> InsertionSort(elements);
            var sortArray = QuickSort(elements);
            Console.WriteLine(String.Join(" ", elements));
        }

        private static int[] QuickSort(int[] elements)
        {
            throw new NotImplementedException();
        }

        private static void InsertionSort(int[] elements)
        {
            for (int currentIdx = 1; currentIdx < elements.Length; currentIdx++)
            {
                var currentElement = elements[currentIdx];
                var previousIdx = currentIdx - 1;

                while (previousIdx >= 0 && elements[previousIdx] > currentElement)
                {
                    elements[previousIdx + 1] = elements[previousIdx--];
                }

                elements[previousIdx + 1] = currentElement;
            }
        }

        private static void BubbleSort(int[] elements)
        {
            bool isSorted = false;
            while (!isSorted)
            {
                isSorted = true;

                var count = 0;
                for (int i = 0; i < elements.Length - count - 1; i++)
                {
                    var currentElement = elements[i];
                    var nextElement = elements[i + 1];

                    if(currentElement > nextElement)
                    {
                        count++;
                        Swap(i, i + 1);
                        isSorted = false;
                    }
                }
            }
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
