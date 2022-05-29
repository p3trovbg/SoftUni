using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidation
{
    public class ControlDigitFactory
    {
        public static string GetControlDigit(string egn)
        {
            long digit = long.Parse(egn);
            decimal sum = 0;
            for (int i = 9; i >= 1; i--)
            {
                int currentDigit = (int)digit % 10;
                digit /= 10;
                switch (i)
                {
                    case 1:
                        sum += currentDigit * 2;
                        break;
                    case 2:
                        sum += currentDigit * 4;
                        break;
                    case 3:
                        sum += currentDigit * 8;
                        break;
                    case 4:
                        sum += currentDigit * 5;
                        break;
                    case 5:
                        sum += currentDigit * 10;
                        break;
                    case 6:
                        sum += currentDigit * 9;
                        break;
                    case 7:
                        sum += currentDigit * 7;
                        break;
                    case 8:
                        sum += currentDigit * 3;
                        break;
                    case 9:
                        sum += currentDigit * 6;
                        break;
                }
            }
            decimal result = Math.Floor(sum / 11);
            sum -= result * 11;

            if (sum >= 10)
            {
                sum = 0;
            }
            return sum.ToString();
        }
    }
}
