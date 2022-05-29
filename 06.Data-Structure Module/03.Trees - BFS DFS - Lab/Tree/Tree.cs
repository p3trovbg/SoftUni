namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;
        private bool isDeleteRoot = false;
        public Tree(T value)
        {
            Value = value;
            Parent = null;
            _children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (var child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }
        }

        public T Value { get; private set; }
        public Tree<T> Parent { get; private set; }
        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            var queue = new Queue<Tree<T>>();
            var result = new List<T>();
            if(isDeleteRoot)
            {
                return result;
            }
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                result.Add(node.Value);
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            //It can also with recursion but it is more slow.

            var stackNodes = new Stack<Tree<T>>();
            var result = new Stack<T>();
            stackNodes.Push(this);
            while (stackNodes.Count > 0)
            {
                var node = stackNodes.Pop();
                result.Push(node.Value);
                foreach (var child in node.Children)
                {
                    stackNodes.Push(child);
                }
            }

            return result.ToArray();
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var parent = findNode(parentKey);
            if(parent == null)
            {
                throw new ArgumentNullException();
            }
            parent._children.Add(child);
        }

        public void RemoveNode(T nodeKey)
        {
            var node = findNode(nodeKey);
            if (node == null)
            {
                throw new ArgumentNullException();
            }

            var parent = node.Parent;
            if(parent != null)
            {
                parent._children.Remove(node);
            }
            else 
            {
                node = null;
                isDeleteRoot = true;
            }
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstNode = findNode(firstKey);
            var secondNode = findNode(secondKey);

            if(firstNode == null || secondNode== null)
            {
                throw new ArgumentNullException();
            }

            var firstNodeParent = firstNode.Parent;
            var secondNodeParent = secondNode.Parent;

            if(firstNodeParent == null)
            {
                firstNode.Value = secondNode.Value;
                firstNode._children.Clear();
                foreach (var child in secondNode._children)
                {
                    firstNode._children.Add(child);
                }
                return;
            }
            else if(secondNodeParent == null)
            {
                secondNode.Value = firstNode.Value;
                secondNode._children.Clear();
                foreach (var child in firstNode._children)
                {
                    secondNode._children.Add(child);
                }
                return;
            }

            firstNode.Parent = secondNodeParent;
            secondNode.Parent = firstNodeParent;

            int firstIdx = firstNodeParent._children.IndexOf(firstNode);
            int secondIdx = secondNodeParent._children.IndexOf(secondNode);

            firstNodeParent._children[firstIdx] = secondNode;
            secondNodeParent._children[secondIdx] = firstNode;
            
        }

        private Tree<T> findNode(T parentKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Value.Equals(parentKey))
                {
                    return node;
                }
                 
                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }

            return null;
        }
    }
}
