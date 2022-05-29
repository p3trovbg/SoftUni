namespace _02.MaxHeap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;
        public MaxHeap()
        {
            this.heap = new List<T>();
        }
        public int Size { get { return this.heap.Count; } }

        public void Add(T element)
        {
            heap.Add(element);
            Heapify(heap.Count - 1);

        }

        public T Peek()
        {
            return heap[0];
        }

        private void Heapify(int idx)
        {
            if(idx == 0)
            {
                return;
            }
            var parentIdx = (idx - 1) / 2;

            if(heap[idx].CompareTo(heap[parentIdx]) > 0)
            {
                var parent = heap[parentIdx];
                heap[parentIdx] = heap[idx];
                heap[idx] = parent;
                Heapify(parentIdx);
            }
        }
    }
}
