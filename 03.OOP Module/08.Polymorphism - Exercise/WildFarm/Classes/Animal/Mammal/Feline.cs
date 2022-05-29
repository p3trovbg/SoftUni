using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Mammal
{
    public class Feline : Mammal
    {
        public Feline(string name, double weight, string livingRegion, string breed, double quantity)
            : base(name, weight, livingRegion, quantity)
        {
            Breed = breed;
        }
        public string Breed { get; set; }
        public override string ToString()
        {
            if (GetType().Name == "Tiger")
            {
                Weight = Weight + 1 * Quantity;
            }
            else
            {
                Weight = Weight + 0.30 * Quantity;
            }
            return $"{GetType().Name} [{Name}, {Breed}, {Weight}, {LivingRegion}, {Quantity}]";

        }
    }
}
