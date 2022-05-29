using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : IDrawable
    {
        private int radius;
        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void DrawShape()
        {

            for (int i = 0; i < radius * 2; i++)
            {
                for (int j = 0; j < radius * 2; j++)
                {                  
                    var distance = Math.Sqrt((radius - i) * (radius - i) + (radius - j) * (radius - j));
                    if (Math.Ceiling(distance) == radius)
                    {
                        Console.Write("*");
                        
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }

        }
    }
}
