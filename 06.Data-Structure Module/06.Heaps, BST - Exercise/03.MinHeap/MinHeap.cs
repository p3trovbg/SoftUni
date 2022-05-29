namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => _elements.Count;

        public T Dequeue()
        {
            var removeElement = _elements[0];
            _elements[0] = _elements[Size - 1];
            _elements.RemoveAt(Size - 1);
            HeapifyDown(0);
            return removeElement;
        }

        public void Add(T element)
        {
            _elements.Add(element);
            Heapify(Size - 1);
        }

        public T Peek()
        {
            return _elements[0];
        }

        private void Heapify(int idx)
        {
            if(idx == 0)
            {
                return;
            }
            var parent = (idx - 1) / 2;
            if(_elements[idx].CompareTo(_elements[parent]) < 0)
            {
                var smaller = _elements[parent];
                _elements[parent] = _elements[idx];
                _elements[idx] = smaller;

                Heapify(parent);
            }
        }

        private void HeapifyDown(int parentIdx)
        {
            var leftChildIdx = parentIdx * 2 + 1;
            var rightChildIdx = parentIdx * 2 + 2;

            if(leftChildIdx > Size - 1)
            {
                return;
            }

            if(_elements[parentIdx].CompareTo(_elements[leftChildIdx]) > 0)
            {
                var bigger = _elements[parentIdx];
                _elements[parentIdx] = _elements[leftChildIdx];
                _elements[leftChildIdx] = bigger;
                HeapifyDown(leftChildIdx);
            }

            if (rightChildIdx > Size - 1)
            {
                return;
            }

            if (_elements[parentIdx].CompareTo(_elements[rightChildIdx]) > 0)
            {
                var bigger = _elements[parentIdx];
                _elements[parentIdx] = _elements[rightChildIdx];
                _elements[rightChildIdx] = bigger;
                HeapifyDown(rightChildIdx);
            }

        }
    }
}
