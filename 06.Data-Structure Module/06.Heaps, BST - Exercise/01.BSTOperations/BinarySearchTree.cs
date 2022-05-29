namespace _01.BSTOperations
{
    using System;
    using System.Collections.Generic;

    public class BinarySearchTree<T> : IAbstractBinarySearchTree<T>
        where T : IComparable<T>
    {
        private int nodesCount;
        public BinarySearchTree()
        {
        }

        public BinarySearchTree(Node<T> root)
        {
            this.Root = root;
        }

        public Node<T> Root { get; private set; }

        public int Count => nodesCount;

        public bool Contains(T element)
        {
            return Contains(element, this.Root);
        }

        public void Insert(T element)
        {
            if (this.Root == null)
            {
                this.Root = new Node<T>(element);
                nodesCount++;
                return;
            }

            var node = Root;
            while (true)
            {
                if (node.Value.CompareTo(element) > 0) // left
                {
                    if (node.LeftChild == null)
                    {
                        node.LeftChild = new Node<T>(element, node);
                        nodesCount++;
                        return;
                    }
                    node = node.LeftChild;
                    continue;
                }
                else //right
                {
                    if (node.RightChild == null)
                    {
                        node.RightChild = new Node<T>(element, node);
                        nodesCount++;
                        return;
                    }
                    node = node.RightChild;
                    continue;
                }
            }
        }

        public IAbstractBinarySearchTree<T> Search(T element)
        {
            return Search(element, Root);
        }

        public void EachInOrder(Action<T> action)
        {
            var list = new List<T>();
            var leftChild = this.Root.LeftChild;
            var righChild = this.Root.RightChild;

            while (leftChild != null)
            {
                list.Add(leftChild.LeftChild.Value);
                list.Add(leftChild.Value);
                list.Add(leftChild.RightChild.Value);

                leftChild = leftChild.LeftChild.LeftChild;
            }

            list.Add(this.Root.Value);

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

        public List<T> Range(T lower, T upper)
        {
            var nodes = new List<T>();
            ListRange(lower, upper, this.Root, nodes);
            return nodes;
        }

        private void ListRange(T lower, T upper, Node<T> node, List<T> nodes)
        {
            if(node == null)
            {
                return;
            }

            if(lower.CompareTo(node.Value) < 0)
            {
                ListRange(lower, upper, node.LeftChild, nodes);
            }

            if(lower.CompareTo(node.Value) <= 0 && upper.CompareTo(node.Value) >= 0)
            {
                nodes.Add(node.Value);
            }

            if(upper.CompareTo(node.Value) > 0)
            {
                ListRange(lower, upper, node.RightChild, nodes);
            }
        }

        public void DeleteMin()
        {
            DeleteMin(Root);
        }

        private void DeleteMin(Node<T> root)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            if (root.LeftChild == null)
            {
                if (root.RightChild != null)
                {
                    root.Parent.LeftChild = root.RightChild;
                    nodesCount--;
                    return;
                }
                root.Parent.LeftChild = null;
                nodesCount--;
                return;
            }

            DeleteMin(root.LeftChild);
        }

        public void DeleteMax()
        {
            DeleteMax(Root);
        }

        private void DeleteMax(Node<T> root)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }

            if (root.RightChild == null)
            {
                if(root.LeftChild != null)
                {
                    root.Parent.RightChild = root.LeftChild;
                    nodesCount--;

                    return;
                }
                root.Parent.RightChild = null;
                nodesCount--;

                return;
            }

            DeleteMax(root.RightChild);
        }

        public int GetRank(T element)
        {
            var list = new List<T>();
            CrossElements(element, Root, list);
            return list.Count;
        }

        private void CrossElements(T element, Node<T> node, List<T> list)
        {
            if(node == null)
            {
                return;
            }

            if(element.CompareTo(node.Value) >= 0)
            {
                list.Add(node.Value);
                CrossElements(element, node.LeftChild, list);
            }
            else
            {
                CrossElements(element, node.LeftChild, list);
            }
            
                CrossElements(element, node.RightChild, list);
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

            if (node.Value.CompareTo(element) > 0) //node.Value > element -> go on left side.
            {
                return Contains(element, node.LeftChild);
            }
            else //node.Value < element -> go on right side.
            {
                return Contains(element, node.RightChild);
            }
        }

        private IAbstractBinarySearchTree<T> Search(T element, Node<T> node)
        {
            if (node == null)
            {
                return null;
            }

            if (element.Equals(node.Value))
            {
                return new BinarySearchTree<T>(node);
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
