using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;
        public Stack(params T[] stack)
        {
            this.stack = stack.ToList();
        }

        public void Push(T element)
        {
            stack.Add(element);
        }
        public void Pop()
        {
            if (stack.Count < 1)
            {
                Console.WriteLine("No elements");
            }
            else
            {
                stack.RemoveAt(stack.Count - 1);
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = stack.Count - 1; i >= 0; i--)
            {
                yield return stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
