using System;
using System.Collections.Generic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator
    { 
        public static T[] Create<T>(int length, T item)
        {
            T[] newArray = new T[length];
            for (int i = 0; i < length; i++)
            {
                newArray[i] = item;
            }

            return newArray;
        }
    }
}
