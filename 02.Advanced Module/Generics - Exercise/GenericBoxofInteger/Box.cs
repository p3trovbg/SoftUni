using System;
using System.Collections.Generic;
using System.Text;

namespace GenericBoxofInteger
{
    public class Box<T>
    {
        public T Digit { get; set; }

        public Box(T input)
        {
            Digit = input;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {Digit}";
        }
    }
}
