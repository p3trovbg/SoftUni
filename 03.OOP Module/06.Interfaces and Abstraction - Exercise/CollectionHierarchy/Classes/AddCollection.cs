using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddCollection : List, IAddCollection
    {
        public List<int> AddedElements { get; set; } = new List<int>();

        public void Add(string element)
        {
            AbstractList.Add(element);
            AddedElements.Add(AbstractList.Count - 1);
        }
    }
}
