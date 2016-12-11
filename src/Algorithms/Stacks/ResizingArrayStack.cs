using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Stacks
{
    public class ResizingArrayStack<T> : IStack<T>
    {
        private int index;
        private T[] array = new T[1];

        public void Push(T item)
        {
            if (index == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            array[index++] = item;
        }

        public T Pop()
        {
            if (index == 0)
            {
                throw new InvalidOperationException();
            }

            return array[--index];
        }

        public bool IsEmpty => index == 0;

        public IEnumerator<T> GetEnumerator()
        {
            if (IsEmpty)
            {
                return Enumerable.Empty<T>().GetEnumerator();
            }

            return new ResizingArrayStackEnumerator(index, array);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        class ResizingArrayStackEnumerator : IEnumerator<T>
        {
            private readonly int stackCurrentIndex;
            private int enumeratorIndex;
            private readonly T[] array;

            public ResizingArrayStackEnumerator(int stackCurrentIndex, T[] array)
            {
                this.stackCurrentIndex = stackCurrentIndex;
                enumeratorIndex = stackCurrentIndex;
                this.array = array;
            }

            public bool MoveNext()
            {
                return enumeratorIndex > 0;
            }

            public void Reset()
            {
                enumeratorIndex = stackCurrentIndex;
            }

            public T Current => array[--enumeratorIndex];

            object IEnumerator.Current => Current;

            public void Dispose()
            {
            }
        }
    }
}
