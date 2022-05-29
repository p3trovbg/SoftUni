using System;

namespace GenericArrayCreator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var newArray = ArrayCreator<string>.Create(5, "Pesho");
        }
    }
}
