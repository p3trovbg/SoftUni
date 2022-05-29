using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;

namespace GenericBoxOfString
{
    public class Box<T>
    {

        public T Input { get; set; }

        public Box(T input)
        {
            Input = input;
        }
        public override string ToString()
        {
            return $"{typeof(T)}: {Input}";
        }
    }
}
