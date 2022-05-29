using System;
using System.Collections.Generic;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {

            string input;
            List<Animal> animals = new List<Animal>();
            string name = string.Empty;
            int age = 0;
            string gender = string.Empty;
            while ((input = Console.ReadLine()) != "Beast!")
            {
                string info = Console.ReadLine();
                string[] commands = info.Split();
               
                name = commands[0];
                age = int.Parse(commands[1]);
                if (commands.Length == 3)
                {
                    gender = commands[2];
                }
                             
                if (input == "Dog")
                {
                    animals.Add(new Dog(name, age, gender));
                }
                else if (input == "Cat")
                {
                    animals.Add(new Cat(name, age, gender));
                }
                else if (input == "Frog")
                {
                    animals.Add(new Frog(name, age, gender));
                }
                else if (input == "Kittens")
                {
                    animals.Add(new Kitten(name, age));
                }
                else if (input == "Tomcat")
                {
                    animals.Add(new Tomcat(name, age));
                }
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Type);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}
