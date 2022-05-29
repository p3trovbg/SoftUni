using System;
using System.Collections.Generic;
using System.Text;

namespace Tuples
{
    public class Tuple<T1, T2>
    {
        public T1 FirstItem { get; set; }
        public T2 SecondItem { get; set; }
        
         public Tuple(T1 firstItem, T2 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }
        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
