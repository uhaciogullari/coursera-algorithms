using System;
using Algorithms.Common;

namespace Algorithms.Stacks
{
    public class LinkedListStack<T> : IStack<T>
    {
        private Node<T> first;

        public void Push(T item)
        {
            if (first == null)
            {
                first = new Node<T>(item);
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
    }
}