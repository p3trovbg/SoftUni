using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface IPrivate : ISoldier
    {
        public decimal Salary { get; set; }
    }
}
