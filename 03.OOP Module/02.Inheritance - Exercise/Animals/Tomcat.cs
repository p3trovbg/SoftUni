using System;
using System.Collections.Generic;
using System.Text;

namespace Animals
{
    public class Tomcat : Animal
    {
        public Tomcat(string name, int age)
            : base(name, age, "Male")
        {
        }
        public override string Type => "Tomcat";
        public override string ProduceSound() => "MEOW";
    }
}
