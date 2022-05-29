using System;
using System.Text.RegularExpressions;


namespace _06._Extract_Emails
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Regex reg = new Regex(
                @"(?<=\s)([a-z]+|\d+)(\d+|\w+|\.+|-+)([a-z]+|\d+)\@[a-z]+\-?[a-z]+\.[a-z]+(\.[a-z]+)?");
            MatchCollection mails = reg.Matches(text);

            foreach (Match mail in mails)
            {
                Console.WriteLine(mail.Value);
            }
            
        }
    }
}
