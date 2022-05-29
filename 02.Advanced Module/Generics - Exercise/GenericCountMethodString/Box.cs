using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Linq;
namespace GenericCountMethodString
{
    public class Box<T>
    {
        public T Input { get; set; }
        public Box(T value)
        {
            Input = value;
        }
    }
}
