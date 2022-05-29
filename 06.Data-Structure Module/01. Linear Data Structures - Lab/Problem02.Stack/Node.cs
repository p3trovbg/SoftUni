namespace Problem02.Stack
{
    public class Node<T>
    {
        public Node(T value)
        {
            Value = value;
        }

        public Node<T> Next { get; set; }
        public T Value { get; set; }
    }
}