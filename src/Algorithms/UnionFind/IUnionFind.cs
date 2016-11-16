namespace Algorithms.UnionFind
{
    public interface IUnionFind
    {
        void Union(int p, int q);

        bool IsConnected(int p, int q);
    }
}