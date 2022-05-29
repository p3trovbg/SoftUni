using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Bird
{
    public class Bird : Animal
    {
        public Bird(string name, double weight, double wingSize, double quantity) 
            : base(name, weight, quantity)
        {
            WingSize = wingSize;
        }

        public double WingSize { get; set; }
        public override string ToString()
        {
            if (GetType().Name == "Hen")
            {
                Weight = Weight + Quantity * 0.35;
            }
            else
            {
                Weight = Weight + Quantity * 0.25;
            }
            return $"{GetType().Name} [{Name}, {WingSize}, {Weight}, {Quantity}]";
        }
    }
}
