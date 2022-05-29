﻿namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public ReversedList()
            : this(DEFAULT_CAPACITY)
        {
        }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            this._items = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                validateIndex(index);
                return this._items[(Count - 1) - index];
            }
            set
            {
                validateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (this._items.Length == this.Count)
            {
                Resize();
            }

            _items[Count++] = item;
            //Insert(0, item);
        }

        public bool Contains(T item)
        {
            var searchItem = item;
            foreach (var element in this._items)
            {
                if (element.Equals(searchItem))
                {
                    return true;
                }
            }
            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return (Count - 1) - i;
                }
            }
            return -1;
        }

        public void Insert(int index, T item)
        {
            validateIndex(index);
            if (this._items.Length == this.Count)
            {
                Resize();
            }

            for (int i = this.Count; i > this.Count - index; i--)
            {
                this._items[i] = this._items[i - 1];
            }
            this._items[this.Count- index] = item;
            Count++;
        }

        public bool Remove(T item)
        {
            var idx = this.IndexOf(item);
            if (idx == -1)
            {
                return false;
            }
            this.RemoveAt(idx);
            return true;
        }

        public void RemoveAt(int index)
        {
            validateIndex(index);
            var idx = (Count - 1) - index;
            for (int i = idx; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }
            this._items[this.Count - 1] = default;
            Count--;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();

        private void Resize()
        {
            var newArray = new T[this._items.Length * 2];
            for (int i = 0; i < this._items.Length; i++)
            {
                newArray[i] = this._items[i];
            }
            this._items = newArray;
        }
        private void validateIndex(int index)
        {
            if (Count <= index || index < 0)
            {
                throw new IndexOutOfRangeException("Index is out of range");
            }
        }
    }
}