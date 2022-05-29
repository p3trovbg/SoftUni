namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] _items;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
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
                return this._items[index];
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
            this._items[Count] = item;
            this.Count++;
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
            for (int i = 0; i < this._items.Length; i++)
            {
                if (this._items[i].Equals(item))
                {
                    return i;
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

            for (int i = this.Count; i > index; i--)
            {
                this._items[i] = this._items[i - 1];
            }
            this._items[index] = item;

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
            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }
            this._items[this.Count - 1] = default;
            Count--;
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
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