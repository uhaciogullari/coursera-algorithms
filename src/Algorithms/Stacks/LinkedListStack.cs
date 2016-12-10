using System;

namespace Algorithms.Stacks
{
    public class LinkedListStack<T> : IStack<T>
    {
        private Node<T> first;

        public void Push(T item)
        {
            if (first == null)
            {
                first = new Node<T>(item, null);
            }
            else
            {
                var node = new Node<T>(item, first);
                first = node;
            }
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException();
            }

            var value = first.Value;
            first = first.Next;
            return value;
        }

        public bool IsEmpty => first == null;

        private class Node<TItem>
        {
            public Node(TItem value, Node<TItem> next)
            {
                Value = value;
                Next = next;
            }

            public TItem Value;
            public Node<TItem> Next;
        }
    }
}