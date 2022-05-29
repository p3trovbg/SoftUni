using System;
using System.Collections.Generic;

namespace CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split();
            IAddCollection addCollection = new AddCollection();
            IAddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            IMyList myList = new MyList();
            for (int j = 0; j < inputs.Length; j++)
            {
                addCollection.Add(inputs[j]);
                addRemoveCollection.Add(inputs[j]);
                myList.Add(inputs[j]);
            }
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                addRemoveCollection.Remove();
                myList.Remove();
            }
            Console.WriteLine(string.Join(" ", addCollection.AddedElements));
            Console.WriteLine(string.Join(" ", addRemoveCollection.AddedElements));
            Console.WriteLine(string.Join(" ", myList.AddedElements));
            Console.WriteLine(string.Join(" ", addRemoveCollection.RemovedElements));
            Console.WriteLine(string.Join(" ", myList.RemovedElements));
        }
    }
}
