using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Person> persons = new List<Person>();

            string[] inputPersons = Console.ReadLine()
                .Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
            string[] inputProducts = Console.ReadLine()
             .Split(new string[] { "=", ";" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < inputPersons.Length; i+= 2)
            {
                try
                {
                    persons.Add(new Person(inputPersons[i], decimal.Parse(inputPersons[i + 1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            for (int i = 0; i < inputProducts.Length; i+=2)
            {
                try
                {
                    products.Add(new Product(inputProducts[i], decimal.Parse(inputProducts[i + 1])));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var info = input.Split();
                var person = persons.FirstOrDefault(x => x.Name == info[0]);
                var product = products.FirstOrDefault(x => x.Name == info[1]);

                if (person.Money >= product.Cost)
                {
                    person.AddProduct(product.Name);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                    person.Money -= product.Cost;
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }                        
            }

            foreach (var person in persons)
            {
                if (person.BagOfProducts.Count == 0)
                {
                    Console.WriteLine($"{person.Name} - Nothing bought");
                }
                else
                {
                    Console.WriteLine($"{person.Name} - {string.Join(", ",person.BagOfProducts)}");
                }
            }
        }
    }
}
