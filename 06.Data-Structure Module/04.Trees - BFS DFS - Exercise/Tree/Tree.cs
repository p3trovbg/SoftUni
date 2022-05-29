namespace Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        public Tree(T key, params Tree<T>[] children)
        {
            this.Key = key;
            this._children = new List<Tree<T>>();
            foreach (var child in children)
            {
                this.AddChild(child);
                child.AddParent(this);
            }
        }

        public T Key { get; private set; }

        public Tree<T> Parent { get; private set; }


        public IReadOnlyCollection<Tree<T>> Children
            => this._children.AsReadOnly();

        public void AddChild(Tree<T> child)
        {
            this._children.Add(child);
        }

        public void AddParent(Tree<T> parent)
        {
            this.Parent = parent;
        }

        public string GetAsString()
        {
            return GetLikeString().TrimEnd();
        }

        public Tree<T> GetDeepestLeftomostNode()
        {
            var nodeStack = new Stack<Tree<T>>();
            var stack = new Stack<Tree<T>>();
            nodeStack.Push(this);
            while (nodeStack.Count > 0)
            {
                var node = nodeStack.Pop();
                if (node.Children.Count == 0)
                {
                    stack.Push(node);
                }
                else
                {
                    foreach (var child in node.Children)
                    {
                        nodeStack.Push(child);
                    }
                }
            }

            return stack.Pop();
        }

        public List<T> GetLeafKeys()
        {
            var liefs = getAllLiefs();


            return liefs.Select(x => x.Key).OrderBy(x => x).ToList();
        }

        public List<T> GetMiddleKeys()
        {
            var middleNodes = new List<T>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Children.Count > 0 && node.Parent != null)
                {
                    middleNodes.Add(node.Key);
                }
                else
                {
                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return middleNodes.OrderBy(x => x).ToList();
        }

        public List<T> GetLongestPath()
        {
            var result = new List<T>();

            var leafs = getAllLiefs();

            foreach (var leaf in leafs)
            {
                var node = leaf;
                var path = new List<T>();
                while (node != null)
                {
                    path.Add(node.Key);
                    node = node.Parent;
                }

                if (path.Count > result.Count)
                {
                    result = path;
                }
            }

            result.Reverse();
            return result;
        }

        public List<List<T>> PathsWithGivenSum(int sum)
        {
            var result = new List<List<T>>();

            var leafs = getAllLiefs();

            foreach (var leaf in leafs)
            {
                var currentSum = 0;
                var node = leaf;
                var path = new List<T>();
                while (node != null)
                {
                    path.Add(node.Key);
                    currentSum += int.Parse(node.Key.ToString());
                    node = node.Parent;
                }

                if(currentSum == sum)
                {
                    path.Reverse();
                    result.Add(path);
                }
            }

            return result;
        }

        public List<Tree<T>> SubTreesWithGivenSum(int sum)
        {
            var result = new List<Tree<T>>();
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Any())
            {
                var node = queue.Dequeue();
                if(node.Children.Any())
                {
                    var subtrees = new List<Tree<T>>();
                    var currentSum = 0;
                    currentSum += int.Parse(node.Key.ToString());
                    subtrees.Add(node);
                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                        currentSum += int.Parse(child.Key.ToString());
                    }

                    if (currentSum == sum) 
                    {
                        result = subtrees;
                    }
                }
            }

            return result;
        }

        private string GetLikeString(int space = 0)
        {
            var result = new string(' ', space) + this.Key + "\r\n";
            foreach (var child in this.Children)
            {
                result += child.GetLikeString(space + 2);
            }
            return result;
        }

        private List<Tree<T>> getAllLiefs()
        {
            var leafs = new List<Tree<T>>();

            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Children.Count == 0)
                {
                    leafs.Add(node);
                }
                else
                {
                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }

            return leafs;
        }

    }
}
