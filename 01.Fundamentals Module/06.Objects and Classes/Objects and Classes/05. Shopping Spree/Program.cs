using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;

namespace _05._Shopping_Spree
{
    class Person
    {
        public Person(string name, double money)
        {
            Name = name;
            Money = money;
        }

        public string Name { get; set; }
        public double Money { get; set; }
        public List<string> Bag { get; set; }
    }

    class Product
    {
        public Product(string name, double cost)
        {
            NameProduct = name;
            Cost = cost;
        }
        public string NameProduct { get; set; }    
        public double Cost { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            char[] delimiters = { ';', '=' };
            List<string> person = Console.ReadLine().Split(delimiters,StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> product = Console.ReadLine().Split(delimiters,StringSplitOptions.RemoveEmptyEntries).ToList();
            List<Person> allPerson = new List<Person>();
            List<Product> products = new List<Product>();
            string name = "";
            double money = 0;
            for (int i = 0; i < person.Count; i++)
            {
                if (i % 2 == 0)
                {
                    name = person[i];
                }
                else
                {
                    money = double.Parse(person[i]);
                    Person currentPerson = new Person(name, money);
                    allPerson.Add(currentPerson);
                }
            }
            string nameProduct = "";
            double cost = 0;
            for (int i = 0; i < product.Count; i++)
            {
                if (i % 2 == 0)
                {
                    nameProduct = product[i];
                }
                else
                {
                    cost = double.Parse(product[i]);
                    Product currentProduct = new Product(nameProduct, cost);
                    products.Add(currentProduct);
                }
            }
    ;        


        }
    }
}
