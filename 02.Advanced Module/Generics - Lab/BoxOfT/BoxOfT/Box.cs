using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace BoxOfT
{
    public class Box<T>
    {

        private Stack<T> store = new Stack<T>();

        public int Count { get => store.Count; }

        public Box()
        {
            store = new Stack<T>();
        }

        public void Add(T element)
        {
            store.Push(element);
        }

        public T Remove()
        {
            return store.Pop();
        }
    }
}
