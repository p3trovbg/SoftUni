using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ICommando : ISoldier
    {
        List<IMissions> Missions { get; set; }
        void CompleteMission(string nameCode);
    }
}
