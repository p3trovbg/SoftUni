using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Boxes
{
    public class Box
    {
        public Box(int[] box)
        {
            Width = box[0];
            Depth = box[1];
            Height = box[2];
        }

        public int Width { get; set; }

        public int Depth { get; set; }

        public int Height { get; set; }

        public bool IsUpper(Box previousBox)
        {
            return Width > previousBox.Width && Depth > previousBox.Depth && Height > previousBox.Height;
        }

        public override string ToString()
        {
            return $"{Width} {Depth} {Height}";
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            int boxesCount = int.Parse(Console.ReadLine());
            var boxes = new List<Box>();
            ReadBoxes(boxesCount, boxes);

            int[] len = new int[boxesCount];
            int[] prev = new int[boxesCount];

            int bestIdx = LIS(boxes, len, prev);

            var result = new Stack<Box>();
            while (bestIdx != -1)
            {
                result.Push(boxes[bestIdx]);
                bestIdx = prev[bestIdx];
            }
            foreach (var box in result)
            {
                Console.WriteLine(box.ToString());
            }
        }

        private static int LIS(List<Box> boxes, int[] len, int[] prev)
        {
            int bestLen = 0;
            var bestIdx = 0;
            for (int currIdx = 0; currIdx < boxes.Count; currIdx++)
            {
                var currentBox = boxes[currIdx];
                var currentPrev = -1;
                var currentLen = 1;

                for (int prevIdx = currIdx - 1; prevIdx >= 0; prevIdx--)
                {
                    var previousBox = boxes[prevIdx];
                    var prevLen = len[prevIdx] + 1;

                    if (currentBox.IsUpper(previousBox) &&
                        currentLen <= prevLen)
                    {
                        currentLen = prevLen;
                        currentPrev = prevIdx;
                    }
                }

                len[currIdx] = currentLen;
                prev[currIdx] = currentPrev;

                if (bestLen < currentLen)
                {
                    bestLen = currentLen;
                    bestIdx = currIdx;
                }
            }

            return bestIdx;
        }

        private static void ReadBoxes(int boxesCount, List<Box> boxes)
        {
            for (int i = 0; i < boxesCount; i++)
            {
                var boxData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                boxes.Add(new Box(boxData));
            }
        }
    }
}
