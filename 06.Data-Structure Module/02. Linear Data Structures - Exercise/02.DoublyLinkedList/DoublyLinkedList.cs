namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> last;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newHead = new Node<T>
            {
                Item = item,
                Next = null
            };

            if(head == null)
            {
                head = newHead;
                last = newHead;
            }
            else
            {
                head.Previous = newHead;
                newHead.Next = head;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(T item)
        {
            var newItem = new Node<T>
            {
                Item = item,
                Next = null
            };
            if (last == null)
            {
                last = newItem;
                head = newItem;
            }
            else
            {
                newItem.Previous = last;
                last.Next = newItem;
                last = newItem;
            }
            Count++;
        }

        public T GetFirst()
        {
            isAny();
            return head.Item;
        }


        public T GetLast()
        {
            isAny();
            return last.Item;
        }

        public T RemoveFirst()
        {
            isAny();
            var oldHead = head;
            head = head.Next;
            Count--;
            return oldHead.Item;
        }

        public T RemoveLast()
        {
            isAny();
            var oldLast = last;
            last = last.Previous;
            Count--;
            return oldLast.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Item;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        private void isAny()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

    }
}