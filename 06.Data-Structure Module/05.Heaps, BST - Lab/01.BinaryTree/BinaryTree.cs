namespace _01.BinaryTree
{
    using System;
    using System.Collections.Generic;

    public class BinaryTree<T> : IAbstractBinaryTree<T>
    {
        public BinaryTree(T value
            , IAbstractBinaryTree<T> leftChild
            , IAbstractBinaryTree<T> rightChild)
        {
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }

        public T Value { get; private set; }

        public IAbstractBinaryTree<T> LeftChild { get; private set; }

        public IAbstractBinaryTree<T> RightChild { get; private set; }

        public string AsIndentedPreOrder(int indent)
        {
            string result = new string(' ', indent) + this.Value + "\r\n";

            if(this.LeftChild == null)
            {
                return result;
            }
            
            result += this.LeftChild.AsIndentedPreOrder(indent + 2);
            result += this.RightChild.AsIndentedPreOrder(indent + 2);

            return result;

        }

        public List<IAbstractBinaryTree<T>> InOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();
            var leftChild = this.LeftChild;
            var righChild = this.RightChild;

            while (leftChild != null)
            {
                list.Add(leftChild.LeftChild);
                list.Add(leftChild);
                list.Add(leftChild.RightChild);

                leftChild = leftChild.LeftChild.LeftChild;
            }

            list.Add(this);

            while (righChild != null)
            {
                list.Add(righChild.LeftChild);
                list.Add(righChild);
                list.Add(righChild.RightChild);

                righChild = righChild.RightChild.RightChild;
            }
            return list;
        }

        public List<IAbstractBinaryTree<T>> PostOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();
            var leftChild = this.LeftChild;
            var righChild = this.RightChild;

            while (leftChild != null)
            {
                list.Add(leftChild.LeftChild);
                list.Add(leftChild.RightChild);
                list.Add(leftChild);

                leftChild = leftChild.LeftChild.LeftChild;
            }

            while (righChild != null)
            {
                list.Add(righChild.LeftChild);
                list.Add(righChild.RightChild);
                list.Add(righChild);


                righChild = righChild.RightChild.RightChild;
            }
            list.Add(this);

            return list;
        }

        public List<IAbstractBinaryTree<T>> PreOrder()
        {
            var list = new List<IAbstractBinaryTree<T>>();
            var leftChild = this.LeftChild;
            var righChild = this.RightChild;

            list.Add(this);
            while (leftChild != null)
            {
                list.Add(leftChild);
                list.Add(leftChild.LeftChild);
                list.Add(leftChild.RightChild);

                leftChild = leftChild.LeftChild.LeftChild;
            }

            while (righChild != null)
            {
                list.Add(righChild);
                list.Add(righChild.LeftChild);
                list.Add(righChild.RightChild);

                righChild = righChild.RightChild.RightChild;
            }

            return list;
        }

        public void ForEachInOrder(Action<T> action)
        {
            var list = new List<T>();
            var leftChild = this.LeftChild;
            var righChild = this.RightChild;

            while (leftChild != null)
            {
                list.Add(leftChild.LeftChild.Value);
                list.Add(leftChild.Value);
                list.Add(leftChild.RightChild.Value);

                leftChild = leftChild.LeftChild.LeftChild;
            }

            list.Add(this.Value);

            while (righChild != null)
            {
                list.Add(righChild.LeftChild.Value);
                list.Add(righChild.Value);
                list.Add(righChild.RightChild.Value);

                righChild = righChild.RightChild.RightChild;
            }

            list.ForEach(delegate (T value)
            {
                action(value);
            });
        }

    }
}
