using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Mammal
{
    public class Dog : Mammal
    {
        public Dog(string name, double weight, string livingRegion, double quantity)
            : base(name, weight, livingRegion, quantity)
        {
        }
        public override void ProducingSound()
        {
            Console.WriteLine("Woof!");
        }
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, {Weight + 0.40 * Quantity}, {LivingRegion}, {Quantity}]";
        }
    }
}
