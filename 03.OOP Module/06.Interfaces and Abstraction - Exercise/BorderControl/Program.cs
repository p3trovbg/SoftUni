using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                var buyers = new Dictionary<string, IBuyer>();
                int n = int.Parse(Console.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    string[] input = Console.ReadLine().Split();
                    string name = input[0];
                    int age = int.Parse(input[1]);
                    if (input.Length == 3)
                    {
                        string group = input[2];
                        buyers.Add(name, new Rebel(name, age, group));    
                    }
                    else if (input.Length == 4)
                    {
                        string id = input[2];
                        string birthdate = input[3];
                        buyers.Add(name, new Citizen(name, age, id, birthdate));
                    }
                }
                string nameBuyer;
                while ((nameBuyer = Console.ReadLine()) != "End")
                {                  
                    if (buyers.ContainsKey(nameBuyer))
                    {
                        buyers[nameBuyer].BuyFood();
                    }
                }
                int totalFood = buyers.Select(x => x.Value.Food).Sum();
                Console.WriteLine(totalFood);
            }

            //Birthdate celabrations
            //----------------------------------------------------------------------
            //string fakeIds = Console.ReadLine();
            //birthdates = birthdates.Where(x => x.Data.EndsWith(fakeIds)).ToList();
            //foreach (var birthdata in birthdates)
            //{
            //    Console.WriteLine(birthdata.Data);
            //}


            //List<IBirthdate> birthdates = new List<IBirthdate>();
            //string input;
            //while ((input = Console.ReadLine()) != "End")
            //{
            //    string[] info = input.Split();
            //    if (info[0] == "Robot")
            //    {
            //        string model = info[1];
            //        string id = info[2];

            //    }
            //    else if (info[0] == "Citizen")
            //    {
            //        string name = info[1];
            //        int age = int.Parse(info[2]);
            //        string id = info[3];
            //        string birthday = info[4];

            //        birthdates.Add(new Citizen(name, age, id, birthday));
            //    }
            //    else if (info[0] == "Pet")
            //    {
            //        //<name> <birthdate
            //        string name = info[1];
            //        string birthdate = info[2];
            //        birthdates.Add(new Pet(name, birthdate));

            //    }

            //}
            //string fakeIds = Console.ReadLine();
            //birthdates = birthdates.Where(x => x.Data.EndsWith(fakeIds)).ToList();
            //foreach (var birthdata in birthdates)
            //{
            //    Console.WriteLine(birthdata.Data);
            //}
        }
    }
}
