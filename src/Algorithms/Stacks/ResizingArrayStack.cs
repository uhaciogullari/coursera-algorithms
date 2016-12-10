using System;

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
    }
}
