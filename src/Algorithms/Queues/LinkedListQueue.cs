using System;
using Algorithms.Common;

namespace Algorithms.Queues
{
    public class LinkedListQueue<T> : IQueue<T>
    {
        private Node<T> first, last;

        public void Enqueue(T value)
        {
            if (IsEmpty)
            {
                first = new Node<T>(value);
                last = first;
            }
            else
            {
                last.Next = new Node<T>(value);
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

    }
}