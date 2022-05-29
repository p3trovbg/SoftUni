using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal
{
    public abstract class Animal
    {
        protected Animal(string name, double weight, double quantity)
        {
            Name = name;
            Weight = weight;
            Quantity = quantity;
        }

        //Animal – string Name, double Weight, int FoodEaten   
        public virtual void ProducingSound()
        {
        }
        public string Name { get; set; }
        public virtual double Weight { get; set; }
        public virtual double Quantity { get; set; }
        public int FoodEaten { get; set; }
    }
}
