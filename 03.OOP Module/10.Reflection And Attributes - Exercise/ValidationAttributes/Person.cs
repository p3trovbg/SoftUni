using System;
using System.Collections.Generic;
using System.Text;

namespace ValidationAttributes
{
    class Person
    {
        private string fullName;
        private int age;
        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }       
        [MyRequired]
        public string FullName
        {
            get => fullName;
            set => fullName = value;
        }

        [MyRange(12, 90)]
        public int Age
        {
            get => age;
            set => age = value;
        }
    }
}
