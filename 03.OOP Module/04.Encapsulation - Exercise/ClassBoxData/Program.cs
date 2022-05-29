using System;

namespace ClassBoxData
{
    public class Program
    {
        static void Main(string[] args)
        {
            double firstParam = double.Parse(Console.ReadLine());
            double secondParam = double.Parse(Console.ReadLine());
            double thirdParam = double.Parse(Console.ReadLine());
            Box box;
            try
            {
                box = new Box(firstParam, secondParam, thirdParam);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
    }
}
