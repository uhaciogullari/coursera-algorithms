using System;

namespace Algorithms.Queues
{
    public class LinkedListQueue : IQueue
    {
        private Node first, last;

        public void Enqueue(string value)
        {
            if (IsEmpty)
            {
                first = new Node(value, null);
                last = first;
            }
            else
            {
                last.Next = new Node(value, null);
                last = last.Next;
            }
        }

        public string Dequeue()
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

        private class Node
        {
            public Node(string value, Node next)
            {
                Value = value;
                Next = next;
            }

            public string Value;
            public Node Next;
        }

    }
}