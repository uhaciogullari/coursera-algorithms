namespace Algorithms
{
    public static class UnionFindExtensions
    {
        public static bool TryAdd(this IUnionFind unionFind, int p, int q)
        {
            if (unionFind.IsConnected(p, q))
            {
                return false;
            }

            unionFind.Union(p,q);
            return true;
        }
    }
}