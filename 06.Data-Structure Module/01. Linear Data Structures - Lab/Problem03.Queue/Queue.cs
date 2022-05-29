namespace Problem03.Queue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Queue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> last;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var head = _head;
            while (head != null)
            {
                if(head.Value.Equals(item))
                {
                    return true;
                }
                head = head.Next;
            }
            return false;
        }

        public T Dequeue()
        {
            if(Count == 0)
            {
                throw new InvalidOperationException();
            }
            var oldHead = _head;
            _head = _head.Next;
            Count--;
            return oldHead.Value;
        }

        public void Enqueue(T item)
        {
            var newLast = new Node<T>(item);
            if(last == null)
            {
                last = newLast;
                _head = newLast;
            }
            else
            {
                last.Next = newLast;
                last = newLast;
            }
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _head.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var head = _head;
            while(head != null)
            {
                yield return head.Value;
                head = head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}