using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Channels;

namespace CarSalesman
{
    public class Car
    {
        //// /
        //•	Model
        //•	Engine
        //•	Weight 
        //•	Color
        public Car(string model, Engine engine)
        {
            Model = model;
            Engine = engine;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public string Weight { get; set; } = "n/a";
        public string Color { get; set; } = "n/a";

        public override string ToString()
        {
            string result = null;
            result = $"{Model}: {Environment.NewLine} " +
                     $"  {Engine.Model}: {Environment.NewLine} " +
                     $"    Power: {Engine.Power} {Environment.NewLine} " +
                     $"    Displacement: {Engine.Displacement} {Environment.NewLine} " +
                     $"    Efficiency: {Engine.Efficiency} {Environment.NewLine} " +
                     $"  Weight: {Weight} {Environment.NewLine} " +
                     $"  Color: {Color}";

            return result;
            //{ CarModel}:
            //{ EngineModel}:
            //Power: { EnginePower}
            //Displacement: { EngineDisplacement}
            //Efficiency: { EngineEfficiency}
            //Weight: { CarWeight}
            //Color: { CarColor}

        }
    }
}
