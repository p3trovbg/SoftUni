namespace _01.BSTOperations
{
    public class Node<T>
    {
        public Node<T> Parent { get; set; }
        public T Value { get; set; }

        public Node<T> LeftChild { get; set; }

        public Node<T> RightChild { get; set; }

        public Node(T value, Node<T> parent = null, Node<T> leftChild = null, Node<T> rightChild = null)
        {
            this.Parent = parent;
            this.Value = value;
            this.LeftChild = leftChild;
            this.RightChild = rightChild;
        }
    }
}
