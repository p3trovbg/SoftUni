namespace AVLTree
{
    using System;

    public class AVL<T> where T : IComparable<T>
    {
        public class Node
        {
            public Node(T value)
            {
                this.Value = value;
                Height = 1;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Height { get; set; }
        }
        public Node Root { get; private set; }
        public bool Contains(T element)
        {
            var findElement = Contains(Root, element);
            if(findElement != null)
            {
                return true;
            }
            return false;
        }
        public void Delete(T element)
        {
            if(Root == null)
            {
                return;
            }
            Root = Delete(Root, element);
        }
        public void DeleteMin()
        {
            if(Root == null)
            {
                return;
            }
            if(Root.Left == null)
            {
                Root = null;
                return;
            }
            Node temp = FindMinInRightSubtree(Root.Left);
            Delete(Root, temp.Value);
        }
        public void Insert(T element)
        {
            this.Root = Insert(Root, element);
        }
        public void EachInOrder(Action<T> action)
        {
            EachInOrder(Root, action);
        }

        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element);
            }

            if (node.Value.CompareTo(element) > 0)
            {
                node.Left = Insert(node.Left, element);
            }
            else
            {
                node.Right = Insert(node.Right, element);
            }

            node = BalanceTree(node);
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;

            return node;
        }
        private Node Delete(Node node, T element)
        {
            if (node.Value.CompareTo(element) > 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if (node.Value.CompareTo(element) < 0)
            {
                node.Right = Delete(node.Right, element);
            }
            //Here they are equals.
            else
            {
                if (node.Left == null && node.Right == null)
                {
                    return null;
                }
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }
                else
                {
                    var minNode = FindMinInRightSubtree(node.Right);
                    node.Value = minNode.Value;
                    node.Right = Delete(node.Right, minNode.Value);
                }
            }

            node = BalanceTree(node);
            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return node;
        }
        private Node FindMinInRightSubtree(Node right)
        {
            if (right.Left == null)
            {
                return right;
            }

            return FindMinInRightSubtree(right.Left);
        }
        private int Height(Node node)
        {
            if (node == null)
            {
                return 0;
            }

            return node.Height;
        }
        private Node BalanceTree(Node node)
        {
            var balanceFactor = Height(node.Left) - Height(node.Right);
            //If return > 1 - this means that left subtree is more weight.
            if (balanceFactor > 1) // left
            {
                var childBalance = Height(node.Left.Left) - Height(node.Left.Right);
                if (childBalance < 0)
                {
                    node.Left = RotateLeft(node.Left);
                }
                node = RotateRight(node);
            }
            //If return < -1 - this means that right subtree is more weight.
            else if (balanceFactor < -1)
            {
                var childBalance = Height(node.Right.Left) - Height(node.Right.Right);
                if (childBalance > 0)
                {
                    node.Right = RotateRight(node.Right);
                }
                node = RotateLeft(node);
            }

            return node;
        }
        private Node RotateRight(Node node)
        {
            var left = node.Left;
            node.Left = left.Right;
            left.Right = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return left;
        }
        private Node RotateLeft(Node node)
        {
            var right = node.Right;
            node.Right = right.Left;
            right.Left = node;

            node.Height = Math.Max(Height(node.Left), Height(node.Right)) + 1;
            return right;
        }
        private void EachInOrder(Node root, Action<T> action)
        {
            if (root == null)
            {
                return;
            }
            EachInOrder(root.Left, action);
            action(root.Value);
            EachInOrder(root.Right, action);
        }
        private Node Contains(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Value.Equals(element))
            {
                return node;
            }

            if (node.Value.CompareTo(element) > 0)
            {
                return Contains(node.Left, element);
            }
            else
            {
                return Contains(node.Right, element);
            }
        }
    }
}
