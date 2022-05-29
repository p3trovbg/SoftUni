using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICitizen : IBirthdate
    {
        //: "{name} {age} {id}" 
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; set; }
    }
}
