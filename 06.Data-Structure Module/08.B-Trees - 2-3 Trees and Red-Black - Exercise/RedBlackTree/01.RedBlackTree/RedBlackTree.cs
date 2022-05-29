namespace _01.RedBlackTree
{
    using System;

    public class RedBlackTree<T> where T : IComparable
    {
        private const bool Red = true;
        private const bool Black = false;
        public class Node
        {
            public Node(T value, bool color = Red)
            {
                this.Value = value;
                this.Color = color;
            }

            public T Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public bool Color { get; set; }
        }

        public Node root;

        public RedBlackTree()
        {

        }

        public RedBlackTree(Node node)
        {
            PreOrderCopy(node);
        }

        public void EachInOrder(Action<T> action)
        {
            EachInOrder(root, action);
        }

        public RedBlackTree<T> Search(T element)
        {
            var node = FindNode(root, element);
            return new RedBlackTree<T>(node);
        }


        public void Insert(T value)
        {
            root = Insert(root, value);
            root.Color = Black;
        }
        public void Delete(T key)
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            root = Delete(root, key);
            if(root == null)
            {
                return;
            }

            root.Color = Black;
        }
        public void DeleteMin()
        {
            if(root == null)
            {
                throw new InvalidOperationException();
            }
            root = DeleteMin(root);
            if(root == null)
            {
                return;
            }
            root.Color = Black;
        }
        public void DeleteMax()
        {
            if (root == null)
            {
                throw new InvalidOperationException();
            }
            root = DeleteMax(root);
            if (root == null)
            {
                return;
            }
            root.Color = Black;
        }
        private Node DeleteMax(Node node)
        {
            if (IsRed(node.Left))
            {
                node = RightRotate(node);
            }

            if (node.Right == null)
            {
                return null;
            }

            if (!IsRed(node.Right) && !IsRed(node.Right.Left))
            {
                node = MoveRedRight(node);
            }

            node.Right = DeleteMax(node.Right);

            return FixUp(node);
        }
        public int Count()
        {
            return Count(root);
        }
        private Node FindNode(Node node, T element)
        {
            if (node == null)
            {
                return null;
            }
            if (node.Value.Equals(element))
            {
                return node;
            }
            if (IsLesser(element, node.Value))
            {
                return FindNode(node.Left, element);
            }
            else
            {
                return FindNode(node.Right, element);
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
        private void EachInOrder(Node node, Action<T> action)
        {
            if (node == null)
            {
                return;
            }
            EachInOrder(node.Left, action);
            action(node.Value);
            EachInOrder(node.Right, action);
        }
        private Node Insert(Node node, T element)
        {
            if (node == null)
            {
                return new Node(element);
            }
            
            if(IsLesser(element, node.Value))
            {
                node.Left = Insert(node.Left, element);
            }
            else
            {
                node.Right = Insert(node.Right, element);
            }

            if(IsRed(node.Right))
            {
                node = LeftRotate(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RightRotate(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColor(node);
            }

            return node;
        }
        private Node Delete(Node node, T key)
        {
            if (IsLesser(key, node.Value))
            {
                if (!IsRed(node.Left) && !IsRed(node.Left.Left))
                {
                    node = MoveRedLeft(node);
                }

                node.Left = Delete(node.Left, key);
            }
            else
            {
                if (IsRed(node.Left))
                {
                    node = RightRotate(node);
                }
                if (node.Value.Equals(key) && node.Right == null)
                {
                    return null;
                }
                if ((!IsRed(node.Right)) && !IsRed(node.Right.Left))
                {
                    node = MoveRedRight(node);
                }

                if (node.Value.Equals(key))
                {
                    node.Value = FindMinValueInRightSubtree(node.Right);
                    node.Right = DeleteMin(node.Right);
                }
                else
                {
                    node.Right = Delete(node.Right, key);
                }
            }

            return FixUp(node);
        }
        private T FindMinValueInRightSubtree(Node node)
        {
            if (node.Left == null)
            {
                return node.Value;
            }

            return FindMinValueInRightSubtree(node.Left);
        }
        private bool IsLesser(T element, T nodeValue)
        {
            return nodeValue.CompareTo(element) > 0;
        }
        private Node LeftRotate(Node node)
        {
            var temp = node.Right;
            node.Right = temp.Left;
            temp.Left = node;

            temp.Color = temp.Left.Color;
            temp.Left.Color = Red;

            return temp;
        }
        private Node RightRotate(Node node)
        {
            var temp = node.Left;
            node.Left = temp.Right;
            temp.Right = node;

            temp.Color = temp.Right.Color;
            temp.Right.Color = Red;

            return temp;
        }
        private void FlipColor(Node node)
        {
            node.Color = !node.Color;
            node.Left.Color = !node.Left.Color;
            node.Right.Color = !node.Right.Color;
        }
        private bool IsRed(Node node)
        {
            if(node == null)
            {
                return false;
            }

            return node.Color == Red;
        }
        private void PreOrderCopy(Node node)
        {
            if (node == null)
            {
                return;
            }

            this.Insert(node.Value);
            PreOrderCopy(node.Left);
            PreOrderCopy(node.Right);
        }
        private Node FixUp(Node node)
        {
            if (IsRed(node.Right))
            {
                node = LeftRotate(node);
            }

            if (IsRed(node.Left) && IsRed(node.Left.Left))
            {
                node = RightRotate(node);
            }

            if (IsRed(node.Left) && IsRed(node.Right))
            {
                FlipColor(node);
            }

            return node;
        }
        private Node DeleteMin(Node node)
        {
            if (node.Left == null)
            {
                return null;
            }

            if (IsRed(node.Left.Left))
            {
                node = MoveRedLeft(node);
            }

            node.Left = DeleteMin(node.Left);

            return FixUp(node);
        }
        private Node MoveRedLeft(Node node)
        {
            FlipColor(node);
            if (IsRed(node.Right.Left))
            {
                node.Right = RightRotate(node.Right);
                node = LeftRotate(node);

                FlipColor(node);
            }

            return node;
        }
        private Node MoveRedRight(Node node)
        {
            FlipColor(node);
            if (IsRed(node.Left.Left))
            {
                node = RightRotate(node);

                FlipColor(node);
            }

            return node;
        }

    }
}