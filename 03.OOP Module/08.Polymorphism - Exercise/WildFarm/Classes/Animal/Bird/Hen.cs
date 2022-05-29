using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Classes.Animal.Bird
{
    public class Hen : Bird
    {
        public Hen(string name, double weight, double wingSize, double quantity)
            : base(name, weight, wingSize, quantity)
        {
        }
        public override void ProducingSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
