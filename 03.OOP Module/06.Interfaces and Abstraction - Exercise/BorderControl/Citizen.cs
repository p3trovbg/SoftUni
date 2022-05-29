using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Citizen : ICitizen, IBuyer
    {
        public Citizen(string name, int age, string id,string data)
        {
            Name = name;
            Age = age;
            Id = id;
            Data = data;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
        public string Data { get; set; }
        public int Food { get; set; } = 0;

        public void BuyFood()
        {
            Food += 10;
        }
    }
}
