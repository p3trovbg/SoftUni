namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;
        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var head = _head;
            while (head != null)
            {
                if(head.Item.Equals(item))
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
            return oldHead.Item;
        }

        public void Enqueue(T item)
        {
            var newItem = new Node<T>
            {
                Item = item,
                Next = null
            };
            if(_tail == null)
            {
                _tail = newItem;
                _head = newItem;
            }
            else
            {
                _tail.Next = newItem;
                _tail= newItem;
            }
            Count++;
        }

        public T Peek()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
            return _head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var head = _head;
            while (head != null)
            {
                yield return head.Item;
                head = head.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
         => GetEnumerator();
    }
}