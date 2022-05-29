using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public abstract class List : IList
    {
        private const int Capacity = 100;
        public List<string> AbstractList { get; set; }
        protected List()
        {
            AbstractList = new List<string>(Capacity);
        }       
    }
}
