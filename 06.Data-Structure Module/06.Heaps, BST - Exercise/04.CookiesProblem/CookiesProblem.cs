using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.CookiesProblem
{
    public class CookiesProblem
    {
        private List<int> _cookies;
        private int operations = 0;
        public int Solve(int k, int[] cookies)
        {
            _cookies = cookies.ToList();

            Solve(k);
            return operations == 0 ? -1 : operations;
        }

        private void Solve(int k, int sweetness = 0)
        {
            if (sweetness > k)
            {
                return;
            }

            var cookie = Dequeue();
            if(!_cookies.Any())
            {
                operations = 0;
                return;
            }
            sweetness = cookie + (2 * Peek());
            operations++;
            Solve(k, sweetness);
        }

        private int Dequeue()
        {
            var leastSweet = _cookies[0];
            _cookies[0] = _cookies[_cookies.Count - 1];
            _cookies.RemoveAt(_cookies.Count - 1);
            HeapifyDown(0);
            return leastSweet;
        }

        private int Peek()
        {
            return _cookies[0];
        }

        private void HeapifyDown(int parentIdx)
        {
            var leftChildIdx = parentIdx * 2 + 1;
            var rightChildIdx = parentIdx * 2 + 2;

            if (leftChildIdx > _cookies.Count - 1)
            {
                return;
            }

            if (_cookies[parentIdx].CompareTo(_cookies[leftChildIdx]) > 0)
            {
                var bigger = _cookies[parentIdx];
                _cookies[parentIdx] = _cookies[leftChildIdx];
                _cookies[leftChildIdx] = bigger;
                HeapifyDown(leftChildIdx);
            }

            if (rightChildIdx > _cookies.Count - 1)
            {
                return;
            }

            if (_cookies[parentIdx].CompareTo(_cookies[rightChildIdx]) > 0)
            {
                var bigger = _cookies[parentIdx];
                _cookies[parentIdx] = _cookies[rightChildIdx];
                _cookies[rightChildIdx] = bigger;
                HeapifyDown(rightChildIdx);
            }
        }
    }
}
