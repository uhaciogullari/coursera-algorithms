using System.Collections.Generic;

namespace Algorithms.Stacks
{
    public interface IStack<T> : IEnumerable<T>
    {
        void Push(T item);

        T Pop();

        bool IsEmpty { get; }
    }
}