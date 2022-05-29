using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Mammal
{
    public class Mammal : Animal
    {
        public Mammal(string name, double weight, string livingRegion, double quantity)
            : base(name, weight, quantity)
        {
            LivingRegion = livingRegion;
        }

        public string LivingRegion { get; set; }

    }
}
