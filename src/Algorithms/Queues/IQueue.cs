namespace Algorithms.Queues
{
    public interface IQueue<T>
    {
        void Enqueue(T value);
        T Dequeue();
        bool IsEmpty { get; }
    }
}