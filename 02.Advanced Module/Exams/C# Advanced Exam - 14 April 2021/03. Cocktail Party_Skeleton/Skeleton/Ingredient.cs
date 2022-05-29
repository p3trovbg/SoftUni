using System;
using System.Collections.Generic;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        internal static bool any;

        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Ingredient: {Name}");
            sb.AppendLine($"Quantity: {Quantity}");
            sb.Append($"Alcohol: {Alcohol}");
            return sb.ToString();
        
        }

        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }
    }
}
