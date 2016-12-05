using System;

namespace Algorithms.Stacks
{
    public class ResizingArrayStack : IStack
    {
        private int index;
        private string[] array = new string[1];

        public void Push(string item)
        {
            if (index == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }

            array[index++] = item;
        }

        public string Pop()
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
