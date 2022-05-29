namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newFirst = new Node<T>(item);
            if(_head == null)
            {
                _head = newFirst;
                _last = newFirst;
            }
            else
            {
                _head.Next = newFirst;
                _head = newFirst;
            }
            
            Count++;
        }

        public void AddLast(T item)
        {
            var newLast = new Node<T>(item);
            if (_head == null)
            {
                _head = newLast;
                _last = newLast;
            }
            else
            {
                _last.Next = newLast;
                _last = newLast;
            }
            Count++;
        }

        public T GetFirst()
        {
            Any();
            return _head.Value;
        }


        public T GetLast()
        {
            Any();
            return _last.Value;
        }

        public T RemoveFirst()
        {
            Any();
            var oldHead = _head;
            _head = _head.Next;
            Count--;
            return oldHead.Value;
        }

        public T RemoveLast()
        {
            Any();
            var oldLast = _last;
            _last = _last.Next;
            Count--;
            return oldLast.Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currentHead = _head;
            while(currentHead != null)
            {
                yield return currentHead.Value;
                currentHead = currentHead.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
        private void Any()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }

}