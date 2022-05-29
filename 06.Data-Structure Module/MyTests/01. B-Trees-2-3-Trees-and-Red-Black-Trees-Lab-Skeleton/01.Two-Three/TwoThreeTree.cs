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
            if(node == null)
            {
                return new TreeNode<T>(element);
            }

            if(node.IsLeaf())
            {
                return MergeNodes(node, new TreeNode<T>(element));
            }

            //Left side
            if (IsLesser(node.LeftKey, element))
            {
                //In left part on tree
                var newNode = Insert(node.LeftChild, element);
                return newNode == node.LeftChild ? node : MergeNodes(node, newNode);
            }
            //Middle side
            else if (node.IsTwoNode() || IsLesser(node.RightKey, element))
            {
                var newNode = Insert(node.MiddleChild, element);
                return newNode == node.MiddleChild ? node : MergeNodes(node, newNode);
            }
            //Right side
            else
            {
                var newNode = Insert(node.RightChild, element);
                return newNode == node.RightChild ? node : MergeNodes(node, newNode);
            }
        }

        //s1==s2 returns 0  
        //s1>s2 returns 1  
        //s1<s2 returns -1  
        private bool IsLesser(T keyValue, T newValue)
        {
            return newValue.CompareTo(keyValue) < 0;
        }

        private TreeNode<T> MergeNodes(TreeNode<T> node, TreeNode<T> newNode)
        {
            if (node.IsTwoNode())
            {
                //left, right
                if (IsLesser(newNode.LeftKey, node.LeftKey))
                {
                    //If current node is bigger than new node.
                    node.RightKey = newNode.LeftKey;
                    node.MiddleChild = newNode.LeftChild;
                    node.RightChild = newNode.MiddleChild;
                }
                else
                {
                    //If current node is smaller than new node
                    node.RightKey = node.LeftKey;
                    node.RightChild = node.MiddleChild;
                    node.MiddleChild = newNode.MiddleChild;
                    node.LeftChild = newNode.LeftChild;
                    node.LeftKey = newNode.LeftKey;
                }

                return node;
            }
            else if (IsLesser(node.LeftKey, newNode.LeftKey))
            {
                var newParent = new TreeNode<T>(node.LeftKey)
                {
                    LeftChild = newNode,
                    MiddleChild = node
                };

                node.LeftChild = node.MiddleChild;
                node.MiddleChild = node.RightChild;
                node.LeftKey = node.RightKey;
                node.RightKey = default;
                node.RightChild = null;

                return newParent;
            }
            else if (IsLesser(node.RightKey, newNode.LeftKey))
            {
                newNode.MiddleChild = new TreeNode<T>(node.RightKey)
                {
                    LeftChild = newNode.MiddleChild,
                    MiddleChild = node.RightChild
                };

                newNode.LeftChild = node;
                node.RightChild = null;
                node.RightKey = default;

                return newNode;
            }
            else
            {
                var newParent = new TreeNode<T>(node.RightKey)
                {
                    LeftChild = node,
                    MiddleChild = newNode
                };

                newNode.LeftChild = node.RightChild;
                node.RightKey = default;
                node.RightChild = null;

                return newParent;
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
