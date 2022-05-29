using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        Dictionary<string, double> toppings = new Dictionary<string, double>
        {
            {"meat", 1.2},
            {"veggies", 0.8 },
            {"cheese", 1.1},
            {"sauce", 0.9 }
        };
        private string typeTopping;
        private double weight;
        private double calories;

        public Topping(string typeTopping, double weight)
        {
            TypeTopping = typeTopping;
            Weight = weight;
        }

        public string TypeTopping
        {
            get => typeTopping;
            private set
            {
                if (!toppings.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                typeTopping = value;
            }
        }
        public double Weight
        {
            get => weight;
            private set
            {
                if (value < 1 || value > 50)
                {                 
                    throw new ArgumentException($"{typeTopping} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double Calories
        {
            get => weight * toppings[typeTopping.ToLower()] * 2;
            private set
            {
                calories = value;
            }
        }
        
    }
}
