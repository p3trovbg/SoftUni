namespace Hierarchy
{
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class Hierarchy<T> : IHierarchy<T>
    {
        private Node<T> root;
        private Dictionary<T, Node<T>> nodesByValue;
        public Hierarchy(T value)
        {
            root = new Node<T>(value);
            nodesByValue = new Dictionary<T, Node<T>>();
            nodesByValue.Add(value, root);
        }

        public int Count => nodesByValue.Count;

        public void Add(T element, T child)
        {
            if (!nodesByValue.ContainsKey(element) || nodesByValue.ContainsKey(child))
            {
                throw new ArgumentException();
            }

            var node = new Node<T>(child);
            node.Parent = nodesByValue[element];
            nodesByValue.Add(child, node);
            nodesByValue[element].Children.Add(node);

        }

        public bool Contains(T element)
        {
            return nodesByValue.ContainsKey(element);
        }

        public IEnumerable<T> GetChildren(T element)
        {
            if(!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            return nodesByValue[element].Children.Select(x => x.Value);
        }

        public IEnumerable<T> GetCommonElements(Hierarchy<T> other)
        {
            return nodesByValue.Keys.Intersect(other.nodesByValue.Keys);
        }

        public IEnumerator<T> GetEnumerator()
        {
            var queue = new Queue<Node<T>>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node.Value;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }

        public T GetParent(T element)
        {
            if(!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            if(nodesByValue[element].Parent == null)
            {
                return default;
            }

            return nodesByValue[element].Parent.Value;
        }

        public void Remove(T element)
        {
            if(!nodesByValue.ContainsKey(element))
            {
                throw new ArgumentException();
            }

            if(nodesByValue[element].Parent == null)
            {
                throw new InvalidOperationException();
            }

            var parent = nodesByValue[element].Parent;
            var currentNode = nodesByValue[element];

            parent.Children.Remove(currentNode);
            parent.Children.AddRange(currentNode.Children);

            foreach (var child in currentNode.Children)
            {
                nodesByValue[child.Value].Parent = parent;
            }
            nodesByValue.Remove(element);
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}