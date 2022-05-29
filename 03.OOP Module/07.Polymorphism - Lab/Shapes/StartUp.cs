using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Shape circle = new Circle(6);         
            Shape rectangle = new Rectangle(3, 4);

            Console.WriteLine(circle.Draw());
            Console.WriteLine(rectangle.Draw());
           
            
        }
    }
}
