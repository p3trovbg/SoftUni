namespace AA_Tree
{
    using System;

    public class AATree<T> : IBinarySearchTree<T>
        where T : IComparable<T>
    {
        private class Node
        {
            public Node(T element)
            {
                this.Value = element;
                Level = 1;
            }

            public T Value { get; set; }
            public Node Right { get; set; }
            public Node Left { get; set; }
            public int Level { get; set; }
        }

        private Node root;

        public int Count()
        {
            if (root == null)
            {
                return 0;
            }
            return Count(root);
        }
        public void Insert(T element)
        {
            root = Insert(root, element);
        }
        public void Delete(T element)
        {
            if (root == null)
            {
                throw new ArgumentNullException();
            }
            root = Delete(root, element);
        }

        private Node Delete(Node node, T element)
        {
            if (node.Value.CompareTo(element) > 0 && node.Value.CompareTo(element) != 0)
            {
                node.Left = Delete(node.Left, element);
            }
            else if(node.Value.CompareTo(element) < 0)
            {
                node.Right = Delete(node.Right, element);
            }
            else
            {
                if(node.Left == null && node.Right == null)
                {
                    node = null;
                }

            }

            return FixUp(node);
        }

        private Node FixUp(Node node)
        {
           if(node.Left.Level < node.Level - 1 || node.Right.Level < node.Level - 1)
            {
                if(node.Right.Level > --node.Level)
                {
                    node.Right.Level = node.Level;
                }

                Skew(node);
                node.Right = Skew(node.Right);
                node.Right.Right = Skew(node.Right.Right);
                node = Split(node);
                node.Right = Split(node.Right);
            }

            return node;
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

            node = Skew(node);
            node = Split(node);

            return node;
        }

        private Node Split(Node node)
        {
            if (node.Right == null || node.Right.Right == null)
            {
                return node;
            }
            else if (node.Right.Right.Level == node.Level)
            {
                node = RightRotation(node);
                node.Level++;
            }
            return node;
        }
        private Node Skew(Node node)
        {
            if (node.Left != null && node.Level == node.Left.Level)
            {
                return LeftRotation(node);
            }
            return node;
        }

        public bool Contains(T element)
        {
            var node = Contains(root, element);
            if (node != null)
            {
                return true;
            }
            return false;
        }
        public void InOrder(Action<T> action)
        {
            //Root is in middle
            if (root == null)
            {
                return;
            }
            InOrder(root, action);
        }
        public void PreOrder(Action<T> action)
        {
            if (root == null)
            {
                return;
            }
            PreOrder(root, action);

        }
        public void PostOrder(Action<T> action)
        {
            //Root is in end
            if (root == null)
            {
                return;
            }
            PostOrder(root, action);
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
        private int Count(Node node)
        {
            if (node == null)
            {
                return 0;
            }
            return 1 + Count(node.Left) + Count(node.Right);
        }
        private void InOrder(Node root, Action<T> action)
        {
            if (root == null)
            {
                return;
            }
            InOrder(root.Left, action);
            action(root.Value);
            InOrder(root.Right, action);
        }
        private void PreOrder(Node root, Action<T> action)
        {
            if (root == null)
            {
                return;
            }
            action(root.Value);
            PreOrder(root.Left, action);
            PreOrder(root.Right, action);
        }
        private void PostOrder(Node root, Action<T> action)
        {
            if (root == null)
            {
                return;
            }
            PostOrder(root.Left, action);
            PostOrder(root.Right, action);
            action(root.Value);
        }

        private Node LeftRotation(Node node)
        {
            var newNode = node.Left;
            node.Left = newNode.Right;
            newNode.Right = node;

            return newNode;
        }

        private Node RightRotation(Node node)
        {
            var newNode = node.Right;
            node.Right = newNode.Left;
            newNode.Left = node;

            return newNode;
        }
    }
}