using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Mammal
{
    public class Mouse : Mammal
    {
        public Mouse(string name, double weight, string livingRegion, double quantity)
            : base(name, weight, livingRegion, quantity)
        {
        }
        
  
        public override void ProducingSound()
        {
            Console.WriteLine("Squeak");
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight + 0.10 * Quantity}, {LivingRegion}, {Quantity}]";
        }
    }
}
