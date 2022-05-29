using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    internal class Pet : IBirthdate
    {
        public Pet(string name, string data)
        {
            Name = name;
            Data = data;
        }

        public string Name { get; set; }
        public string Data { get; set; }
    }
}
