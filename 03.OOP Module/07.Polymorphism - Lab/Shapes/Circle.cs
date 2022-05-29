using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Shape
    {
        public int Radius { get; protected set; }
        public Circle(int radius) 
        {
            this.Radius = radius;
        }

        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(Radius, 2);
        }

        public override double CalculatePerimeter()
        {
            return Math.PI * (Radius * 2);
        }
        public override string Draw()
        => CalculatePerimeter().ToString() +
            Environment.NewLine +
            CalculateArea().ToString();
    }
}
