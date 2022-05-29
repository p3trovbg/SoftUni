using System;
using AA_Tree;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            var tree = new AATree<int>();

            tree.Insert(10);
            tree.Insert(3);
            tree.Insert(15);
            tree.Insert(12);
            tree.Insert(3);
            tree.Insert(20);
            tree.Insert(2);
            tree.Insert(5);


            tree.Delete(15);
        }
    }
}
