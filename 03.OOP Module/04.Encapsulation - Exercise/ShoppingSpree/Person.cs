using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
    public class Person
    {
        //name, money and a bag of products
        private protected string name;
        private decimal money;
        private List<string> bagOfProducts;

        public List<string> BagOfProducts
        {
            get => bagOfProducts;
            private set => bagOfProducts = value;
        }
        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            BagOfProducts = new List<string>();
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
        public decimal Money
        {
            get { return money; }
            set 
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                money = value;
            }
        }

       public void AddProduct(string product)
        {
            BagOfProducts.Add(product);
        }
    }
}
