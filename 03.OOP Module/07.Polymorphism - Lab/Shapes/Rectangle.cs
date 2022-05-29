using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Shape
    {
        
        public Rectangle(int height, int width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; protected set; }
        public double Width { get; protected set; }

        public override double CalculateArea()
        { 
            return Height * Width;   
        }

        public override double CalculatePerimeter()
        {
            return (Height + Width) * 2;
        }
        public override string Draw()
        => CalculatePerimeter().ToString() +
            Environment.NewLine +
            CalculateArea().ToString();

    }
}
