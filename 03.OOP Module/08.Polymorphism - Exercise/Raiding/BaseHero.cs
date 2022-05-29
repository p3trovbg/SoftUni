using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public abstract class BaseHero : IBaseHero
    {
        protected BaseHero(string name)
        {
         Name = name;
        }

        public string Name { get; set; }
        public virtual int Power { get; set; }

        public virtual string CastAbility()
        {
            string type = GetType().Name;
            if (type == "Druid" || type == "Paladin")
            {
                return $"{type} - {Name} healed for {Power}";
            }
            else
            {
                return $"{type} - {Name} hit for {Power} damage";
            }
        }
    }
}
