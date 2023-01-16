namespace _01._Quicksort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[] result = Quicksort(input);

            Console.WriteLine(string.Join(" ", result));
        }

        private static int[] Quicksort(int[] input)
        {
            if (input.Length <= 1)
            {
                return input;
            }

            var length = input.Count();
            var pivotIndex = length / 2;
            var pivot = input[pivotIndex];

            var left = new List<int>();
            var right = new List<int>();

            for (int i = 0; i < pivotIndex; i++)
            {
                if (input[i] < pivot)
                {
                    left.Add(input[i]);
                }
                else
                {
                    right.Add(input[i]);
                }
            }

            for (int i = pivotIndex + 1; i < length; i++)
            {
                if (input[i] < pivot)
                {
                    left.Add(input[i]);
                }
                else
                {
                    right.Add(input[i]);
                }
            }

            var leftPart = Quicksort(left.ToArray());
            var rightPart = Quicksort(right.ToArray());

            var result = new List<int>();
            result.AddRange(leftPart);
            result.Add(pivot);
            result.AddRange(rightPart);

            return result.ToArray();
        }
    }
}