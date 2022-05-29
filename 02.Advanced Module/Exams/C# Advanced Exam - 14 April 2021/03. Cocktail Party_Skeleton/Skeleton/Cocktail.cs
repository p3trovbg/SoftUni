using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            collection = new List<Ingredient>();
        }
      
        public void Add(Ingredient ingredient)
        {
            if (!collection.Any(x => x.Name == ingredient.Name) && collection.Count < Capacity && MaxAlcoholLevel >= ingredient.Alcohol)
            {
                collection.Add(ingredient);
            }
        }
        public bool Remove(string name)
        {
            var coctail = collection.FirstOrDefault(x => x.Name == name);
            if (coctail != null)
            {
                collection.Remove(coctail);
                return true;
            }
            return false;
        }
        public Ingredient GetMostAlcoholicIngredient()
        {
            return collection.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public Ingredient FindIngredient(string name)
        {
            return collection.FirstOrDefault(x => x.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");
            foreach (var coctail in collection)
            {
                sb.AppendLine(coctail.ToString());
            }
            return sb.ToString().TrimEnd();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }
        private List<Ingredient> collection;
        public int CurrentAlcoholLevel => collection.Count();
    }
}
