namespace HashTable
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class HashTable<TKey, TValue> : IEnumerable<KeyValue<TKey, TValue>>
    {
        private LinkedList<KeyValue<TKey, TValue>>[] slots;
        private const int DefaultCapacity = 4;
        private const float RecommendedSize = 0.75f;

        public int Count { get; private set; }

        public int Capacity => slots.Length;

        public HashTable(int capacity = DefaultCapacity)
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[capacity];
        }

        public void Add(TKey key, TValue value)
        {
            GrowIfNeeded();

            int index = Math.Abs(key.GetHashCode() % Capacity);
            if (slots[index] == null)
            {
                slots[index] = new LinkedList<KeyValue<TKey, TValue>>();
            }

            foreach (var item in slots[index])
            {
                if (item.Key.Equals(key))
                {
                    throw new ArgumentException("Duplicate key");
                }
            }

            var element = new KeyValue<TKey, TValue>(key, value);
            slots[index].AddLast(element);
            Count++;
        }

        public bool AddOrReplace(TKey key, TValue value)
        {
            try
            {
                Add(key, value);
            }
            catch (ArgumentException ex)
            {
                if (ex.Message == "Duplicate key")
                {
                    int index = Math.Abs(key.GetHashCode() % Capacity);

                    var keyValue = slots[index].FirstOrDefault(x => x.Key.Equals(key));
                    keyValue.Value = value;
                    return true;
                }
            }

            return false;
        }

        public TValue Get(TKey key)
        {
            var element = Find(key);
            if(element == null)
            {
                throw new KeyNotFoundException();
            }
            return element.Value;
        }

        public TValue this[TKey key]
        {
            get
            {
                var element = Find(key);
                if(element == null)
                {
                    throw new KeyNotFoundException();
                }
                return element.Value;
            }
            set
            {
                AddOrReplace(key, value);
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            var element = this.Find(key);

            if (element != null)
            {
                value = element.Value;
                return true;
            }

            value = default;
            return false;
        }

        public KeyValue<TKey, TValue> Find(TKey key)
        {
            int idx = Math.Abs(key.GetHashCode() % Capacity);

            if (slots[idx] == null)
            {
                return null;
            }
            return slots[idx].FirstOrDefault(x => x.Key.Equals(key));
        }

        public bool ContainsKey(TKey key)
        {
            return Find(key) != null; 
        }

        public bool Remove(TKey key)
        {
            int index = Math.Abs(key.GetHashCode() % Capacity);
            if(slots[index] != null)
            {
                foreach (var linkedNode in slots[index])
                {
                    if(linkedNode.Key.Equals(key))
                    {
                        slots[index].Remove(linkedNode);
                        Count--;
                        return true;
                    }
                }
            }

            return false;
        }

        public void Clear()
        {
            this.slots = new LinkedList<KeyValue<TKey, TValue>>[DefaultCapacity];
            this.Count = 0;
        }

        public IEnumerable<TKey> Keys => this.Select(x => x.Key);

        public IEnumerable<TValue> Values
        {
            get
            {
                var allValues = new List<TValue>();
                foreach (var slot in this.slots)
                {
                    if (slot != null)
                    {
                        foreach (var element in slot)
                        {
                            allValues.Add(element.Value);
                        }
                    }
                }
                return allValues;
            }
        }

        public IEnumerator<KeyValue<TKey, TValue>> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot != null)
                {
                    foreach (var element in slot)
                    {
                        yield return element;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void GrowIfNeeded()
        {
            if ((float)(Count + 1) / Capacity >= RecommendedSize)
            {
                var newTable = new HashTable<TKey, TValue>(Capacity * 2);
                foreach (var element in this)
                {
                    newTable.Add(element.Key, element.Value);
                }

                this.slots = newTable.slots;
            }
        }
    }
}
