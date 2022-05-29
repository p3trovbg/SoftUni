namespace _01.Two_Three
{
    using System;
    using System.Text;

    public class TwoThreeTree<T> where T : IComparable<T>
    {
        private TreeNode<T> root;

        public void Insert(T element)
        {
            root = Insert(root, element);
        }

        private TreeNode<T> Insert(TreeNode<T> node, T element)
        {
            if (node == null)
            {
                return new TreeNode<T>(element);
            }

            if (node.IsLeaf())
            {
                return MergeNodes(node, new TreeNode<T>(element));
            }
            else if (IsLesser(element, node.LeftKey))
            {
                var newNode = Insert(node.LeftChild, element);
                return node.LeftChild == newNode ? node : MergeNodes(node, newNode);

            }
            else if (node.IsTwoNode() || IsLesser(element, node.RightKey))
            {
                var newNode = Insert(node.MiddleChild, element);
                return node.MiddleChild == newNode ? node : MergeNodes(node, newNode);
            }
            else
            {
                var newNode = Insert(node.RightChild, element);
                return node.RightChild == newNode ? node : MergeNodes(node, newNode);
            }
        }

        private bool IsLesser(T element, T key)
        {
            return element.CompareTo(key) < 0;
        }

        private TreeNode<T> MergeNodes(TreeNode<T> currentNode, TreeNode<T> newNode)
        {
            if (currentNode.IsTwoNode())
            {
                if (IsLesser(currentNode.LeftKey, newNode.LeftKey))
                {
                    currentNode.RightKey = newNode.LeftKey;
                    currentNode.MiddleChild = newNode.LeftChild;
                    currentNode.RightChild = newNode.MiddleChild;
                }
                else
                {
                    currentNode.RightKey = currentNode.LeftKey;
                    currentNode.RightChild = currentNode.MiddleChild;
                    currentNode.MiddleChild = newNode.MiddleChild;
                    currentNode.LeftChild = newNode.LeftChild;
                    currentNode.LeftKey = newNode.LeftKey;
                }
                return currentNode;
            }
            else if (IsLesser(newNode.LeftKey, currentNode.LeftKey))
            {
                var newParentNode = new TreeNode<T>(currentNode.LeftKey)
                {
                    LeftChild = newNode,
                    MiddleChild = currentNode
                };

                currentNode.LeftChild = currentNode.MiddleChild;
                currentNode.MiddleChild = currentNode.RightChild;
                currentNode.LeftKey = currentNode.RightKey;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newParentNode;
            }
            else if (IsLesser(newNode.LeftKey, currentNode.RightKey))
            {
                newNode.MiddleChild = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = newNode.MiddleChild,
                    MiddleChild = currentNode.RightChild
                };
                newNode.LeftChild = currentNode;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newNode;
            }
            else
            {
                var newTreeNode = new TreeNode<T>(currentNode.RightKey)
                {
                    LeftChild = currentNode,
                    MiddleChild = newNode
                };

                newNode.LeftChild = currentNode.RightChild;
                currentNode.RightKey = default;
                currentNode.RightChild = null;

                return newTreeNode;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            RecursivePrint(this.root, sb);
            return sb.ToString();
        }

        private void RecursivePrint(TreeNode<T> node, StringBuilder sb)
        {
            if (node == null)
            {
                return;
            }

            if (node.LeftKey != null)
            {
                sb.Append(node.LeftKey).Append(" ");
            }

            if (node.RightKey != null)
            {
                sb.Append(node.RightKey).Append(Environment.NewLine);
            }
            else
            {
                sb.Append(Environment.NewLine);
            }

            if (node.IsTwoNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
            }
            else if (node.IsThreeNode())
            {
                RecursivePrint(node.LeftChild, sb);
                RecursivePrint(node.MiddleChild, sb);
                RecursivePrint(node.RightChild, sb);
            }
        }
    }
}
