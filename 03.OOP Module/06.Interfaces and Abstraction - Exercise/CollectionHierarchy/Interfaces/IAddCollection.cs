using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddCollection : IList
    {
        public List<int> AddedElements { get; set; }
        void Add(string element);
    }
}
