using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Product
    {
        private protected string name;
        private decimal cost;
        public Product(string name, decimal price)
        {
            Name = name;
            Cost = price;
        }

  
        public string Name
        {
            get { return name; }
            private set
            {
                if (value == String.Empty || value == " " || value == null)
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }
        public decimal Cost
        {
            get { return cost; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                cost = value;
            }
        }
    }
}
