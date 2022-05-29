using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace AuthorProblem
{
    public class Tracker
    {

        public void PrintMethodsByAuthor()
        {
            var type = typeof(StartUp);
            var info = type
                .GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => x.CustomAttributes.Any(x => x.AttributeType == typeof(AuthorAttribute)));
            foreach (var methodInfo in info)
            {
                var attributes = methodInfo.GetCustomAttributes(false);
                foreach (AuthorAttribute attribute in attributes)
                {
                    Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
                }
               
            }
        }
        
    }
}
