namespace _02.LowestCommonAncestor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
        where T : IComparable<T>
    {
        public BinaryTree(
            T value,
            BinaryTree<T> leftChild,
            BinaryTree<T> rightChild)
        {
            Value = value;
            LeftChild = leftChild;
            if(this.LeftChild != null)
            {
                this.LeftChild.Parent = this;
            }
            RightChild = rightChild;
            if (this.RightChild != null)
            {
                this.RightChild.Parent = this;
            }
        }

        public T Value { get; set; }

        public BinaryTree<T> LeftChild { get; set; }

        public BinaryTree<T> RightChild { get; set; }

        public BinaryTree<T> Parent { get; set; }

        public T FindLowestCommonAncestor(T first, T second)
        {
            var firstList = GetAncestors(Search(first, this));
            var secondList = GetAncestors(Search(second, this));
            var commonParent = firstList.Intersect(secondList).ToArray()[0];

            return commonParent;
        }

        private List<T> GetAncestors(IAbstractBinaryTree<T> node)
        {
            var list = new List<T>();
            while (node.Parent != null)
            {
                list.Add(node.Parent.Value);
                node = node.Parent;
            }
            return list;
        }

        private IAbstractBinaryTree<T> Search(T element, BinaryTree<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (element.Equals(node.Value))
            {
                return node;
            }

            if (node.Value.CompareTo(element) > 0) //node.Value > element -> go on left side.
            {
                return Search(element, node.LeftChild);
            }
            else //node.Value < element -> go on right side.
            {
                return Search(element, node.RightChild);
            }
        }
    }
}
