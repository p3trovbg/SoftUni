using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWork)
        {
            PartName = partName;
            HoursWork = hoursWork;
        }

        public string PartName { get; set; }
        public int HoursWork {get; set; }

        public override string ToString()
        {
            return $"  Part Name: {PartName} Hours Worked: {HoursWork}";
        }
    }
}
