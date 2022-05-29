using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace GenericArrayCreator
{
    public class ArrayCreator<T>
    {
        public static T[] Create(int length, T item)
        {
            T[] array = new T[length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = item;
            }

            return array;
        }

    }
}
