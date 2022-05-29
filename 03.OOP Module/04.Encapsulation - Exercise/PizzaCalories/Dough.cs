using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Dough
    {
        private string typeDough;
        private string bakingTechnique;
        private int weight;
        private double calories;
        
        private Dictionary<string, double> modifiers = new Dictionary<string, double>
        {
            {"white", 1.5 },
            {"wholegrain", 1.0 },
            {"crispy", 0.9 },
            {"chewy", 1.1 },
            {"homemade", 1.0 }
        };

        public Dough(string typeDough, string bakingTechnique ,int weight)
        {      
            TypeDough = typeDough;
            BakingTechnique = bakingTechnique;
            Weight = weight;
            
        }

        public string TypeDough 
        {
            get => typeDough;
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                typeDough = value;
            } 
        }
        public int Weight 
        { 
            get => weight; 
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }
       
        public string BakingTechnique 
        { 
            get => bakingTechnique;
            private set 
            {
                if (!modifiers.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value;
            } 
        }
        public double Calories
        {
            get => weight * 2 *(modifiers[bakingTechnique.ToLower()] * modifiers[typeDough.ToLower()]);
            private set => calories = value;
        }
    }
}
