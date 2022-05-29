namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var top = _top;
            while (top != null)
            {
                if (top.Value.Equals(item))
                {
                    return true;
                }
                top = top.Next;
            }
            return false;
        }

        public T Peek()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _top.Value;
        }

        public T Pop()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            var oldTop = _top;
            _top = _top.Next;
            Count--;
            return oldTop.Value;
        }

        public void Push(T item)
        {
            var newTop = new Node<T>(item);

            newTop.Next = _top;
            _top = newTop;
            Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = _top;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}