using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> numberOfStones;

        public Lake (params int[] numbers)
        {
            numberOfStones = numbers.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < numberOfStones.Count; i++)
            {
               if (i % 2 == 0)
                {
                    yield return numberOfStones[i];
                }
                    
            }
            for (int i = numberOfStones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return numberOfStones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
