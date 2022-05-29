using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy
{
    public interface IAddRemoveCollection :IList, IAddCollection
    {
        List<string> RemovedElements { get; set; }
        void Remove();
    }
}
