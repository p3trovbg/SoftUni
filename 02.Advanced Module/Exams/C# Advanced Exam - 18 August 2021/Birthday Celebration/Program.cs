using System;
using System.Collections.Generic;
using System.Linq;

namespace Birthday_Celebration
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] guests = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int[] plates = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var stackPlates = new Stack<int>(plates);
            var queueGuests = new Queue<int>(guests);

            int wastedGrams = 0;
            while (stackPlates.Count > 0 && queueGuests.Count > 0)
            {
                int guest = queueGuests.Peek();
                int plate = stackPlates.Peek();

                if (plate < guest)
                {
                    while (guest > 0)
                    {
                        int bottle = stackPlates.Pop();
                        if (bottle >= guest)
                        {
                            wastedGrams += bottle - guest;
                            queueGuests.Dequeue();
                            break;
                        }
                        else
                        {
                            guest -= bottle;
                        }

                    }
                }
                else if (plate >= guest)
                {
                    wastedGrams += plate - guest;
                    queueGuests.Dequeue();
                    stackPlates.Pop();
                }
            }
            Result(queueGuests, stackPlates, wastedGrams) ;

        }
        private static void Result(Queue<int> queueGuests, Stack<int> stackPlates, int wastedLiters)
        {
            if (queueGuests.Count > 0)
            {
                queueGuests.ToArray();
                Console.WriteLine($"Guests: {string.Join(" ", queueGuests)}");
                Console.WriteLine($"Wasted grams of food: {wastedLiters}");
            }
            else
            {
                stackPlates.ToArray();
                Console.WriteLine($"Plates: {string.Join(" ", stackPlates)}");
                Console.WriteLine($"Wasted grams of food: {wastedLiters}");
            }
        }
    }
}
