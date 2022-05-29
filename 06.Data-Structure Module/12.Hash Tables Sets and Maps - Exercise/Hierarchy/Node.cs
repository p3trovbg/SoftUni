using System;
using System.Collections.Generic;
using System.Text;

namespace Hierarchy
{
    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Parent { get; set; }
        public List<Node<T>> Children { get; set; }
        public Node(T value)
        {
            this.Value = value;
            Children = new List<Node<T>>();
        }
    }
}
