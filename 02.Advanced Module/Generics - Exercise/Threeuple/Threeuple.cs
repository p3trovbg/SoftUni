using System;
using System.Collections.Generic;
using System.Text;

namespace Threeuple
{
    class Threeuple<T1, T2, T3>
    {
        public T1 FirstElement { get; set; }
        public T2 SecondElement { get; set; }
        public T3 ThirdElement { get; set; }

        public Threeuple(T1 firstElement, T2 secondElement, T3 thirdElement)
        {
            FirstElement = firstElement;
            SecondElement = secondElement;
            ThirdElement = thirdElement;
        }

        public override string ToString()
        {
            return $"{FirstElement} -> {SecondElement} -> {ThirdElement}";
        }
    }
}
