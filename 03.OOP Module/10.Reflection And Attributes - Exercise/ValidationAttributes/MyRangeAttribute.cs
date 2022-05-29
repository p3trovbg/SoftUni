using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private int minValue;
        private int maxValue;
        public MyRangeAttribute(int minValue, int maxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        public int MinValue { get => minValue; set => minValue = value; }
        public int MaxValue { get => maxValue; set => maxValue = value; }

        public override bool isValid(object obj)
        {
            if ((int)obj < minValue || (int)obj > maxValue)
            {
                return false;
            }
            return true;
        }
    }
}
