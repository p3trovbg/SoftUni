using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    internal class Smartphone : ICallingOtherPhones, IBrowsingInTheWorldWideWeb
    {
        public void Browsing(string link)
        {
            Console.WriteLine($"Browsing: {link}!");

        }

        public void Calling(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
    }
}
