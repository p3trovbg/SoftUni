namespace _04.BinarySearchTree
{
    using System;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
            this.LeftChild = root.LeftChild;
            this.RightChild = root.RightChild;
        }

        public Node<T> Root { get; private set; }

        public Node<T> LeftChild { get; private set; }

        public Node<T> RightChild { get; private set; }

        public T Value => this.Root.Value;

        public bool Contains(T element)
        {
            return Contains(element, this.Root);
        }

        public void Insert(T element)
        {
            if(Root == null)
            {
                this.Root = new Node<T>(element);
                return;
            }
            Insert(element, Root);
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            if(this.Root == null)
            {
                return null;
            }
            return Search(element, this.Root);
        }


        private void Insert(T element, Node<T> node)
        {
            if (node.Value.CompareTo(element) > 0)
            {
                if (node.LeftChild == null)
                {
                    node.LeftChild = new Node<T>(element);
                    return;
                }
                Insert(element, node.LeftChild);
            }
            else
            {
                if (node.RightChild == null)
                {
                    node.RightChild = new Node<T>(element);
                    return;
                }
                Insert(element, node.RightChild);
            }
        }

        private IAbstractBinarySearchTree<T> Search(T element, Node<T> node)
        {
            if(element.Equals(node.Value))
            {
                return new BinarySearchTree<T>(node);
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return Search(element, node.LeftChild); 
            }
            else
            {
                return Search(element, node.RightChild);
            }
        }

        private bool Contains(T element, Node<T> node)
        {
            if (node == null)
            {
                return false;
            }

            if (element.Equals(node.Value))
            {
                return true;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return Contains(element, node.LeftChild);
            }
            else
            {
                return Contains(element, node.RightChild);
            }
        }
    }
}
