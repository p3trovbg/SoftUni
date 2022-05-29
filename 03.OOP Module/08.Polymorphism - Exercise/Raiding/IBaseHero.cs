using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public interface IBaseHero
    {
        //string Name, int Power, string CastAbility()
        public string Name { get; set; }
        public int Power { get; set; }
        string CastAbility(); 

    }
}
