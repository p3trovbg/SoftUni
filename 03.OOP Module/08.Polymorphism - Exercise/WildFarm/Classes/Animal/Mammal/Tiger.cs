using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Mammal
{
    public class Tiger : Feline
    {
        public Tiger(string name, double weight, string livingRegion, string breed, double quantity)
            : base(name, weight, livingRegion, breed, quantity)
        {
        }
        public override void ProducingSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
