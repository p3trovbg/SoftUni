using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Car
    {
        //about model, engine, cargo and a collection of exactly 4 tires
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public Cargo Cargo { get; set; }
        public Tire[] Tire { get; set; }

        public Car(string model, Engine engine, Cargo cargo, Tire[] tire)
        {
            Model = model;
            Engine = engine;
            Cargo = cargo;
            Tire = tire;
        }
    }
}
