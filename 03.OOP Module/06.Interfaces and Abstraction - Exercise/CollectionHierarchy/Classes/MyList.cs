using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public class MyList : List, IMyList
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
            string element = AbstractList[0];
            RemovedElements.Add(element);
            AbstractList.RemoveAt(0);
            
        }
    }
}
