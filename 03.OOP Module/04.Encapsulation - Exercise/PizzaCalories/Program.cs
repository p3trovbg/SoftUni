using System;

namespace PizzaCalories
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Pizza pizza = null;
            try
            {
                string input;
                Dough dough = null;
                Topping topping = null;             
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] info = input.Split();
                    if (info[0] == "Pizza")
                    {
                        pizza = new Pizza(info[1]);
                        continue;
                    }
                     else if (info[0] == "Dough")
                    {
                        string typeDough = info[1];
                        string typeTech = info[2];
                        int weight = int.Parse(info[3]);
                        dough = new Dough(typeDough, typeTech, weight);
                        pizza.AddCalories(dough.Calories);
                    }    
                    else if (info[0] == "Topping")
                    {
                        string typeTopping = info[1];
                        double weightTopping = double.Parse(info[2]);
                        topping = new Topping(typeTopping, weightTopping);
                        pizza.AddTopping(topping);
                        pizza.AddCalories(topping.Calories);
                    }
                }              
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories:F2} Calories.");
        }
    }
}
