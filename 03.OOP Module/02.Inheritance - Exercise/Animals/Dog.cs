using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Dog : Animal
    {
        private const string CurrentSound = "Woof!";
        public Dog(string name, int age, string gender)
            : base(name, age, gender)
        {
        }
        public override string Type => "Dog";
        public override string ProduceSound() => CurrentSound;
    }
}
