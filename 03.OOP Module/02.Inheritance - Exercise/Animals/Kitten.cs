using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Kitten : Animal
    {
        public Kitten(string name, int age)
            : base(name, age, "Female")
        {
            
        }
        public override string Type => "Kitten";
        public override string ProduceSound() => "Meow";
    }
}
