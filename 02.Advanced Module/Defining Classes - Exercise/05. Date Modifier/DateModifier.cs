using System;
using System.Collections.Generic;
using System.Text;

namespace DataModifier
{
    public class DateModifier
    {
        public static  int DateDifference(string firstDay, string secondDay)
        {
            var dataOne = DateTime.Parse(firstDay);
            var dataSecond = DateTime.Parse(secondDay);
            return (dataOne - dataSecond).Days;
        }
    }
}
