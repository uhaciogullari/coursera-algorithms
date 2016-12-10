namespace Algorithms.Common
{
    public class Node<TItem>
    {
        public Node(TItem value)
        {
            Value = value;
        }

        public Node(TItem value, Node<TItem> next)
        {
            Value = value;
            Next = next;
        }

        public TItem Value { get; }
        public Node<TItem> Next { get; set; }
    }
}