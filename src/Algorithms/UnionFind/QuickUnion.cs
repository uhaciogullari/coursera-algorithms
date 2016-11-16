using System.Collections.Generic;
using System.Linq;

namespace Algorithms.UnionFind
{
    public class QuickUnion : IUnionFind
    {
        private readonly List<int> compounds;

        public QuickUnion(int n)
        {
            compounds = Enumerable.Range(0, n).ToList();
        }

        private int GetRoot(int i)
        {
            while (i != compounds[i])
            {
                i = compounds[i];
            }

            return i;
        }

        public void Union(int p, int q)
        {
            var rootP = GetRoot(p);
            var rootQ = GetRoot(q);
            compounds[rootP] = rootQ;
        }

        public bool IsConnected(int p, int q)
        {
            return GetRoot(p) == GetRoot(q);
        }
    }
}
