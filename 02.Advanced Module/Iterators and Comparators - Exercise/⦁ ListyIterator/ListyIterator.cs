using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListIterator
{
    class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collection;
        private int currentIndx = 0;
        public IReadOnlyList<T> List { get; private set; }
        public ListyIterator(params T[]collection)
        {
            this.collection = collection.ToList();
        }
        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                currentIndx++;
            }

            return canMove;
        }

        public bool HasNext()
        {
            return currentIndx < collection.Count - 1;
        }

        public void Print()
        {
            if (collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            Console.WriteLine(collection[currentIndx]);
        }
        public void PrintAll()
        {
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < collection.Count; i++)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
