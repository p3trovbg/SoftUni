using System;
using System.Linq;
namespace _04._Print_and_sum
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            string password = string.Concat(username.Reverse());         
            int counter = 0;
            bool flag = false;
            while (password != username && !flag)
            {
                string originalPassword = Console.ReadLine();
                if (originalPassword == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else
                {
                    counter++;                  
                    if (counter == 4)
                    {
                        Console.WriteLine($"User {username} blocked!");
                        flag = true;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect password. Try again.");                       
                    }                 
                }              
            }
        }
    }
}