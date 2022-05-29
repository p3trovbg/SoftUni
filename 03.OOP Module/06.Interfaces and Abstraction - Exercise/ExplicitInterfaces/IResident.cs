using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicitInterfaces
{
    public interface IResident
    {
        //name, country and a method GetName(). 
        public string Name { get; set; }
        public string Country { get; set; }

        void GetName();
    }
}
