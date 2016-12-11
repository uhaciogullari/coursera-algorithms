using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algorithms.Common;

namespace Algorithms.Stacks
{
    public class LinkedListStack<T> : IStack<T>
    {
        private Node<T> first;

        public void Push(T item)
        {
            if (IsEmpty)
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

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty)
            {
                return Enumerable.Empty<T>().GetEnumerator();
            }

            return new LinkedListStackEnumerator(first);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LinkedListStackEnumerator : IEnumerator<T>
        {
            private readonly Node<T> firstNode;
            private Node<T> currentNode;

            public LinkedListStackEnumerator(Node<T> first)
            {
                firstNode = first;
                currentNode = first;
            }

            public bool MoveNext()
            {
                return currentNode != null;
            }

            public void Reset()
            {
                currentNode = firstNode;
            }

            public T Current
            {
                get
                {
                    var value = currentNode.Value;
                    currentNode = currentNode.Next;
                    return value;
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}