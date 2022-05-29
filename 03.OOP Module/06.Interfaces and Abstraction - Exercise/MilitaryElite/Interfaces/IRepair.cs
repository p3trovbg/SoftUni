using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IRepair
    {
        public string PartName { get; set; }
        public int HoursWork { get; set; }
        
    }
}
