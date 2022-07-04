using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data;

namespace P01_StudentSystem 
{
    public class P01_StudentSystem
    {
        static void Main(string[] args)
        {
            var context = new StudentSystemContext();
            context.Database.Migrate();
        }
    }
}
