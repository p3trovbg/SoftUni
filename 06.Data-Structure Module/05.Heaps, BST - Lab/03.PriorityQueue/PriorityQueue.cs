namespace _03.PriorityQueue
{
    using System;
    using System.Collections.Generic;

    public class PriorityQueue<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> heap;

        public PriorityQueue()
        {
            heap = new List<T>();
        }
        public int Size { get { return heap.Count; } }

        public T Dequeue()
        {
            var removedItem = heap[0];
            heap[0] = heap[this.Size - 1];
            heap.RemoveAt(this.Size - 1);
            HeapifyDown(0);
            return removedItem;
        }

        public void Add(T element)
        {
            heap.Add(element);
            Heapify(this.Size - 1);
        }

        public T Peek()
        {
            return heap[0];
        }

        private void HeapifyDown(int idx)
        {
            var leftChildIdx = idx * 2 + 1;
            var rightChildIdx = idx * 2 + 2;

            var maxChildIdx = leftChildIdx;

            if (leftChildIdx >= this.Size) return;

            if((rightChildIdx < this.Size) && heap[leftChildIdx].CompareTo(heap[rightChildIdx]) < 0)
            {
                maxChildIdx = rightChildIdx;
            }

            if (heap[idx].CompareTo(heap[maxChildIdx]) < 0) 
            {
                var value = heap[idx];
                heap[idx] = heap[maxChildIdx];
                heap[maxChildIdx] = value;
                HeapifyDown(maxChildIdx);
            }
        }

        private void Heapify(int idx)
        {
            if (idx == 0)
            {
                return;
            }
            var parentIdx = (idx - 1) / 2;

            if (heap[idx].CompareTo(heap[parentIdx]) > 0)
            {
                var parent = heap[parentIdx];
                heap[parentIdx] = heap[idx];
                heap[idx] = parent;
                Heapify(parentIdx);
            }
        }
    }
}
