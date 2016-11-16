using System.Collections.Generic;
using System.Linq;

namespace Algorithms
{
    class WeightedQuickUnion : IUnionFind
    {
        private readonly List<int> compounds;
        private readonly List<int> sizes;

        public WeightedQuickUnion(int n)
        {
            compounds = Enumerable.Range(0, n).ToList();
            sizes = Enumerable.Repeat(1,n).ToList();
        }


        public void Union(int p, int q)
        {
            var pRoot = GetRoot(p);
            var qRoot = GetRoot(q);

            if (pRoot == qRoot)
            {
                return;
            }

            if (sizes[pRoot] < sizes[qRoot])
            {
                compounds[pRoot] = qRoot;
                sizes[qRoot] += sizes[pRoot];
            }
            else
            {
                compounds[qRoot] = pRoot;
                sizes[pRoot] = qRoot;
            }
        }

        private int GetRoot(int i)
        {
            while (i != compounds[i])
            {
                i = compounds[i];
            }

            return i;
        }

        public bool IsConnected(int p, int q)
        {
            return GetRoot(p) == GetRoot(q);
        }
    }

}