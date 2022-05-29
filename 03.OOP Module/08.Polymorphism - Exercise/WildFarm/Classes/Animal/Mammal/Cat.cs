using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Mammal
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed, double quantity)
            : base(name, weight, livingRegion, breed, quantity)
        {
        }
        //public override double Weight => base.Weight += 0.30 * Quantity;
        public override void ProducingSound()
        {
            Console.WriteLine("Meow");
        }
    }
}
