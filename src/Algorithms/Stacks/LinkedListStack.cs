using System;

namespace Algorithms.Stacks
{
    public class LinkedListStack : IStack
    {
        private Node first = null;

        public void Push(string item)
        {
            if (first == null)
            {
                first = new Node(item, null);
            }
            else
            {
                var node = new Node(item, first);
                first = node;
            }
        }

        public string Pop()
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