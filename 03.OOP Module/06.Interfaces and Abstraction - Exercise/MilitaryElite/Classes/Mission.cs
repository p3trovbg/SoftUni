using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    internal class Mission : IMissions
    {
        public string CodeName { get; set; }
        public State State { get; set; }

        public void ComplateMission()
        {
            throw new NotImplementedException();
        }
    }
}
