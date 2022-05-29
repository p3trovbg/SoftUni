using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        //name, dough and toppings 
        private string name;
        private List<Topping> toppings;
        private double totalCalories;

        public Pizza(string name)
        {
            Name = name;
            Toppings = new List<Topping>();
           
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 1 || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
    
        public List<Topping> Toppings
        {
            get => toppings;
            private set
            {              
                toppings = value;
            }
        }

        public double TotalCalories { get => totalCalories; private set => totalCalories = value; }

        public void AddCalories(double calories)
        {
            totalCalories += calories;
        }
        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }
    }
}
