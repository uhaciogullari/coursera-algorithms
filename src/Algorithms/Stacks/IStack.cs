namespace Algorithms.Stacks
{
    public interface IStack
    {
        void Push(string item);

        string Pop();

        bool IsEmpty { get; }
    }
}