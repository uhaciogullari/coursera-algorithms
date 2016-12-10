using System;

namespace Algorithms.Queues
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private Node<T> first, last;

        public void Enqueue(T value)
        {
            if (IsEmpty)
            {
                first = new Node<T>(value, null);
                last = first;
            }
            else
            {
                last.Next = new Node<T>(value, null);
                last = last.Next;
            }
        }

        public T Dequeue()
        {
            if (first == null)
            {
                throw new InvalidOperationException();
            }

            var value = first.Value;

            first = first.Next;
            if (IsEmpty)
            {
                last = null;
            }
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