using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Bird
{
    public class Owl : Bird
    {
        public Owl(string name, double weight, double wingSize, double quantity)
            : base(name, weight, wingSize, quantity)
        {
        }
        //Owl – "Hoot Hoot"
        public override void ProducingSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
    }
}
