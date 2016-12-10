namespace Algorithms.Queues
{
    public interface IQueue
    {
        void Enqueue(string value);
        string Dequeue();
        bool IsEmpty { get; }
    }
}