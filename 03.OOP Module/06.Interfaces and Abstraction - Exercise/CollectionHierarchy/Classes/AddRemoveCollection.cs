using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class AddRemoveCollection : List, IAddRemoveCollection
    {
        public List<string> RemovedElements { get; set; } = new List<string>();
        public List<int> AddedElements { get; set; } = new List<int>();

        public void Add(string element)
        {
            AbstractList.Insert(0, element);
            AddedElements.Add(0);
        }

        public void Remove()
        {
            RemovedElements.Add(AbstractList[AbstractList.Count - 1]);
            AbstractList.RemoveAt(AbstractList.Count - 1);
        }
    }
}
