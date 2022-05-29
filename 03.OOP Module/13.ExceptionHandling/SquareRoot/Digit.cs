using System;
using System.Collections.Generic;
using System.Text;

namespace SquareRoot
{
    public class Digit 
    {
        private double digit;

        public Digit(double theDigit)
        {
            TheDigit = theDigit;
        }

        public double TheDigit
        {
            get => digit;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Invalid number");
                }
            }
        }
       
        public void Calculate()
        {
            Console.WriteLine(Math.Sqrt(TheDigit));
        }

    }
}
