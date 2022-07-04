using P01_StudentSystem.Data;
using System;

namespace _1._Student_System
{
    public class P01_StudentSystem
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.EnsureCreated();
        }
    }
}
