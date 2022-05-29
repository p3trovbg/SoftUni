using System;
using System.Collections.Generic;
using WildFarm.Classes.Animal;
using WildFarm.Classes.Animal.Bird;
using WildFarm.Classes.Animal.Mammal;
namespace WildFarm
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Animal> animals  = new List<Animal>();
            string input;
            int counter = 0;
            Animal animal = null;
            string type = String.Empty;
            string name = String.Empty;
            double weight = 0;
            string livingRegion = String.Empty;
            string breed = String.Empty;
            double wingSize = 0;
            while ((input = Console.ReadLine()) != "End")
            {                
                string[] info = input.Split();
                //name, weight, foodEaten, livingRegion, breed
                if (counter % 2 == 0)
                {
                    type = info[0];
                    name = info[1];
                    weight = double.Parse(info[2]);

                    if (type == "Cat" || type == "Tiger")
                    {
                        livingRegion = info[3];
                        breed = info[4];
                    }
                    else if (type == "Owl" || type == "Hen")
                    {
                        wingSize = double.Parse(info[3]);
                    }
                    else if (type == "Mouse" || type == "Dog")
                    {
                        livingRegion = info[3];

                    }
                    counter++;
                    continue;
                }
                else
                {
                    string typeFood = info[0];
                    double quantity = double.Parse(info[1]);
                    switch (type)
                    {
                        case "Cat":
                            if (typeFood != "Vegetable" && typeFood != "Meat")
                            {
                                quantity = 0;
                                animal = (new Cat(name, weight, livingRegion, breed, quantity));
                                animal.ProducingSound();
                                Console.WriteLine($"{type} does not eat {typeFood}!");          
                            }
                            else
                            {
                                animal = (new Cat(name, weight, livingRegion, breed, quantity));
                                animal.ProducingSound();
                            }
                           
                            break;
                        case "Tiger":
                            if (typeFood != "Meat")
                            {
                                quantity = 0;
                                animal = (new Tiger(name, weight, livingRegion, breed, quantity));
                                animal.ProducingSound();
                                Console.WriteLine($"{type} does not eat {typeFood}!");
                            }
                            else
                            {
                                animal = (new Tiger(name, weight, livingRegion, breed, quantity));
                                animal.ProducingSound();
                            }
                            
                            break;
                        case "Owl":
                            if (typeFood != "Meat")
                            {
                                quantity = 0;
                                animal = (new Owl(name, weight, wingSize, quantity));
                                animal.ProducingSound();
                                Console.WriteLine($"{type} does not eat {typeFood}!");                              
                            }
                            else
                            {
                                animal = (new Owl(name, weight, wingSize, quantity));
                                animal.ProducingSound();
                            }                       
                            break;
                        case "Hen":
                            animal = (new Hen(name, weight, wingSize, quantity));
                            animal.ProducingSound();
                            break;
                        case "Mouse":
                            if (typeFood != "Vegetable" && typeFood != "Fruit")
                            {
                                quantity = 0;
                                animal = (new Mouse(name, weight, livingRegion, quantity));
                                animal.ProducingSound();
                                Console.WriteLine($"{type} does not eat {typeFood}!");
                            }
                            else
                            {
                                animal = (new Mouse(name, weight, livingRegion, quantity));
                                animal.ProducingSound();
                            }                          
                            break;
                        case "Dog":
                            if (typeFood != "Meat")
                            {
                                quantity = 0;
                                animal = (new Dog(name, weight, livingRegion, quantity));
                                animal.ProducingSound();
                                Console.WriteLine($"{type} does not eat {typeFood}!");
                            }
                            else
                            {
                                animal = (new Dog(name, weight, livingRegion, quantity));
                                animal.ProducingSound();
                            }
                           
                            break;
                    }
                }
                animals.Add(animal);
                counter++;
            }

            foreach (var currentAnimal in animals)
            {
                Console.WriteLine(currentAnimal.ToString());
            }
        }
    }
}
