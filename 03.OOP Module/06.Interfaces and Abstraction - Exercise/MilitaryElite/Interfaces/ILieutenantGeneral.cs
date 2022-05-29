using System;
using System.Collections.Generic;
using System.Text;

namespace MilitaryElite
{
    public interface ILieutenantGeneral : ISoldier
    {
        List<IPrivate> Privates { get; set; }
    }
}
