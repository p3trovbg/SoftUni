using System;

namespace _10._Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            //•	On the first input line - lost games count – integer in the range [0, 1000].
            //•	On the second line – headset price -floating point number in range[0, 1000].
            //•	On the third line – mouse price -floating point number in range[0, 1000].
            //•	On the fourth line – keyboard price -floating point number in range[0, 1000].
            //•	On the fifth line – display price -floating point number in range[0, 1000].
            int lostGame = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mouseprice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int trashedHeadset = 0;
            int trashedMouse = 0;
            int trashedKeyboard = 0;
            int trashedDisplay = 0;
            for (int i = 1; i <= lostGame; i++)
            {
                if (i % 2 == 0)
                {
                    trashedHeadset++;
                }
                if (i % 3 == 0)
                {
                    trashedMouse++;
                }
                if (i % 6 == 0)
                {
                    trashedKeyboard++;
                }
                if (i % 12 == 0)
                {
                    trashedDisplay++;
                }
            }
            double sum = trashedHeadset * headsetPrice +
                         trashedMouse * mouseprice +
                         trashedKeyboard * keyboardPrice +
                         trashedDisplay * displayPrice;

            Console.WriteLine($"Rage expenses: {sum:f2} lv.");
        }
    }
}
